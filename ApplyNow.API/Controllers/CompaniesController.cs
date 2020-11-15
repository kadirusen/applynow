using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplyNow.API.DTOs;
using ApplyNow.API.Mapping;
using ApplyNow.API.Models.Request;
using ApplyNow.Core.Models;
using ApplyNow.Core.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApplyNow.API.Controllers
{
    [Route("api/[controller]")]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;
        private readonly IDistributedCache _distributedCache;
        private readonly ILogger<CompaniesController> _logger;

        public CompaniesController(ICompanyService companyService, IMapper mapper, IDistributedCache distributedCache, ILogger<CompaniesController> logger)
        {
            _companyService = companyService;
            _mapper = mapper;
            _distributedCache = distributedCache;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var cacheKey = "companies";
            IEnumerable<Company> companies;
            string json;

            var companiesFromCache = await _distributedCache.GetAsync(cacheKey);
            if (companiesFromCache != null)
            {
                json = Encoding.UTF8.GetString(companiesFromCache);
                companies = JsonConvert.DeserializeObject<List<Company>>(json);
            }
            else
            {
                companies = await _companyService.GetAllAsync();
                json = JsonConvert.SerializeObject(companies);
                companiesFromCache = Encoding.UTF8.GetBytes(json);
                var options = new DistributedCacheEntryOptions()
                                .SetSlidingExpiration(TimeSpan.FromDays(1))
                                .SetAbsoluteExpiration(DateTime.Now.AddMonths(1));
                await _distributedCache.SetAsync(cacheKey, companiesFromCache, options);

            }

            return Ok(_mapper.Map<IEnumerable<CompanyDto>>(companies));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cacheKey = "company-" + id.ToString();
            Company company;
            string json;

            var companyFromCache = await _distributedCache.GetAsync(cacheKey);
            if (companyFromCache != null)
            {
                json = Encoding.UTF8.GetString(companyFromCache);
                company = JsonConvert.DeserializeObject<Company>(json);
            }
            else
            {
                company = await _companyService.GetByIdAsync(id);
                json = JsonConvert.SerializeObject(company);
                companyFromCache = Encoding.UTF8.GetBytes(json);
                var options = new DistributedCacheEntryOptions()
                                .SetSlidingExpiration(TimeSpan.FromDays(1))
                                .SetAbsoluteExpiration(DateTime.Now.AddMonths(1));
                await _distributedCache.SetAsync(cacheKey, companyFromCache, options);
            }

            return Ok(_mapper.Map<CompanyDto>(company));
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] CompanyDto companyDto)
        {
            try
            {
                var newCompany = await _companyService.AddAsync(_mapper.Map<Company>(companyDto));
                await _distributedCache.RemoveAsync("companies");
                return Created(string.Empty, _mapper.Map<CompanyDto>(newCompany));

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            _companyService.RemoveWithAnnouncement(id);

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] CompanyDto companyDto)
        {
            var category = _companyService.UpdateCompany(id, _mapper.Map<Company>(companyDto));
            return NoContent();
        }

        [HttpGet("{id}/announcements")]
        public async Task<IActionResult> GetWithAnnouncementById(int id)
        {
            var company = await _companyService.GetWithAnnouncementByIdAsync(id);
            return Ok(_mapper.Map<CompanyWithAnnouncementDto>(company));
        }


        [HttpPost("{id}/announcements")]
        public async Task<IActionResult> SaveWithAnnouncementById(int id, [FromBody] AnnouncementCreateRequestDto announcement)
        {
            try
            {
                List<Announcement> announcementMappingModel = announcement.ToCompanyWithAnnouncementMappingModel();

                var newAnnouncements = await _companyService.CreateAnnouncementAsync(id, announcementMappingModel);
                return Created(string.Empty, _mapper.Map<List<AnnouncementDto>>(newAnnouncements));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}/announcements/{announcementId}")]
        public IActionResult UpdateWithAnnouncementById(int id, int announcementId, [FromBody] AnnouncementUpdateRequestDto announcement)
        {
            Announcement announcementMappingModel = announcement.ToAnnouncementUpdateMappingModel();

            var updateResume = _companyService.UpdateAnnouncementAsync(id, announcementId, announcementMappingModel);
            return NoContent();
        }

        [HttpDelete("{id}/announcements/{announcementId}")]
        public IActionResult RemoveWithAnnouncementById(int id, int announcementId)
        {
            _companyService.RemoveWithAnnouncementById(id,announcementId);
            return NoContent();
        }

    }
}
