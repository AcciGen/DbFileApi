using DbFileApi.API.ExternalServices;
using DbFileApi.Application.Services.UserProfileServices;
using DbFileApi.Domain.Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace DbFileApi.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;
        private readonly IUserProfileService _userService;

        public UserController(IUserProfileService userProfileService, IWebHostEnvironment env)
        {
            _userService = userProfileService;
            _env = env;

        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<ActionResult<string>> CreateUser([FromForm] UserProfileDTO userProfileDTO, IFormFile picture)
        {
            UserProfileExternalService service = new UserProfileExternalService(_env);

            string picturePath = await service.AddPictureAndGetPath(picture);

            var result = await _userService.CreateUserProfileAsync(userProfileDTO, picturePath);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            try
            {
                var result = await _userService.GetAllUserProfileAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetUserByIdAsync(int id)
        {
            try
            {
                var result = await _userService.GetByIdUserProfileAsync(id);

                if (result is null)
                {
                    return NotFound("404 Not Found");
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMovieAsync(int id, UserProfileDTO model)
        {
            try
            {
                var result = await _userService.UpdateUserProfileAsync(id, model);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMovieAsync(int id)
        {
            try
            {
                await _userService.DeleteUserProfileAsync(id);

                return Ok("Successfully deleted!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
