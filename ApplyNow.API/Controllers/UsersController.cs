using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplyNow.API.DTOs;
using ApplyNow.API.Models.Request;
using ApplyNow.Core.Models;
using ApplyNow.Core.Repositories;
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
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IDistributedCache _distributedCache;
        private readonly ILogger<UsersController> _logger;


        public UsersController(IUserService userService, IMapper mapper, IDistributedCache distributedCache, ILogger<UsersController> logger)
        {
            _userService = userService;
            _mapper = mapper;
            _distributedCache = distributedCache;
            _logger = logger;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var cacheKey = "users";
            IEnumerable<User> users;
            string json;

            var usersFromCache = await _distributedCache.GetAsync(cacheKey);
            if (usersFromCache != null)
            {
                json = Encoding.UTF8.GetString(usersFromCache);
                users = JsonConvert.DeserializeObject<List<User>>(json);
            }
            else
            {
                //Todo: Redis Service Layer

                users = await _userService.GetAllAsync();
                json = JsonConvert.SerializeObject(users);
                usersFromCache = Encoding.UTF8.GetBytes(json);
                var options = new DistributedCacheEntryOptions()
                                .SetSlidingExpiration(TimeSpan.FromDays(1)) 
                                .SetAbsoluteExpiration(DateTime.Now.AddMonths(1));
                await _distributedCache.SetAsync(cacheKey, usersFromCache, options);

            }

            return Ok(_mapper.Map<IEnumerable<UserDto>>(users));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cacheKey = "user-"+ id.ToString();
            User user;
            string json;

            var usersFromCache = await _distributedCache.GetAsync(cacheKey);
            if (usersFromCache != null)
            {
                json = Encoding.UTF8.GetString(usersFromCache);
                user = JsonConvert.DeserializeObject<User>(json);
            }
            else
            {
                user = await _userService.GetByIdAsync(id);
                json = JsonConvert.SerializeObject(user);
                usersFromCache = Encoding.UTF8.GetBytes(json);
                var options = new DistributedCacheEntryOptions()
                                .SetSlidingExpiration(TimeSpan.FromDays(1))
                                .SetAbsoluteExpiration(DateTime.Now.AddMonths(1));
                await _distributedCache.SetAsync(cacheKey, usersFromCache, options);

            }

            return Ok(_mapper.Map<UserDto>(user));
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] UserDto userDto)
        {
            try
            {
                var newUser = await _userService.AddAsync(_mapper.Map<User>(userDto));
                await _distributedCache.RemoveAsync("users");

                return Created(string.Empty, _mapper.Map<UserDto>(newUser));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UserDto userDto)
        {
            var category = _userService.UpdateUser(id, _mapper.Map<User>(userDto));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            _userService.RemoveWithResume(id);

            return NoContent();
        }

        [HttpGet("{userId}/resume")]
        public async Task<IActionResult> GetWithResumesById(int userId)
        {
            var user = await _userService.GetWithResumeByIdAsync(userId);
            return Ok(_mapper.Map<UserWithResumesDto>(user));
        }

        [HttpPost("{userId}/resume")]
        public async Task<IActionResult> SaveWithResumeById(int userId, [FromBody]ResumeCreateRequestDto resume)
        {
            var newResume = await _userService.CreateResumeAsync(userId, _mapper.Map<Resume>(resume));
            return Created(string.Empty, _mapper.Map<ResumeDto>(newResume));
        }

        [HttpPut("{userId}/resume")]
        public IActionResult UpdateWithResumeById(int userId, [FromBody] ResumeCreateRequestDto resume)
        {
            var updateResume = _userService.UpdateResumeAsync(userId, _mapper.Map<Resume>(resume));
            return NoContent();
        }

        [HttpDelete("{userId}/resume")]
        public IActionResult RemoveResumeWithUserById(int userId)
        {
            _userService.RemoveResumeWithUserById(userId);
            return NoContent();
        }
    }
}
