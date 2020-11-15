using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplyNow.API.DTOs;
using ApplyNow.API.Mapping;
using ApplyNow.API.Models.Request;
using ApplyNow.API.Models.Response;
using ApplyNow.Core.Models;
using ApplyNow.Core.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApplyNow.API.Controllers
{
    [Route("api/[controller]")]
    public class ApplysController : ControllerBase
    {
        private readonly IApplyService _applyService;
        private readonly IMapper _mapper;
        private readonly ILogger<ApplysController> _logger;

        public ApplysController(IApplyService applyService, IMapper mapper, ILogger<ApplysController> logger)
        {
            _applyService = applyService;
            _mapper = mapper;
            _logger = logger;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var apply = await _applyService.GetWithResumeAndAnnouncementAsync(id);
                return Ok(_mapper.Map<ApplyDto>(apply));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("announcements/{id}")]
        public async Task<IActionResult> GetWithAnnouncementById(int id)
        {
            try
            {
                var applys = await _applyService.GetWithAnnouncementById(id);
                AnnouncementGetListResponseModel announcementMappingModel = applys.ToAnnouncementGetListMappingModel();

                return Ok(announcementMappingModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] ApplyRequestModel apply)
        {
            try
            {
                var newApply = await _applyService.CreateApplyAsync(_mapper.Map<Apply>(apply));
                return Created(string.Empty, _mapper.Map<ApplyDto>(newApply));
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
            var apply = _applyService.GetByIdAsync(id).Result;
            _applyService.Remove(apply);

            return NoContent();
        }
    }
}
