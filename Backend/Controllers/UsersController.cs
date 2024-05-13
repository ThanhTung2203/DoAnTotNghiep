using AutoMapper;
using Backend.Interfaces;
using Backend.Models;
using Backend.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Principal;
using Backend.Dto;
using System.Reflection.Metadata;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IUserRepository _userRepo;
        private readonly IMapper _mapper;
        public UsersController(IUserRepository userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(string Username, string Password, string Email, string Firstname, string Lastname,string Phonenumber)
        {
            var result= await _userRepo.Register(Username, Password, Email,Firstname,Lastname,Phonenumber);
            return Ok(result);
        }
        [HttpPost]
        [Route("registerAdmin")]
        public async Task<IActionResult> RegisterAdmin(string Username, string Password, string Email, string Firstname, string Lastname, string Phonenumber)
        {
            var result = await _userRepo.RegisterAdmin(Username, Password, Email, Firstname, Lastname, Phonenumber);
            return Ok(result);
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([Bind(new[] { "Username,Password" })] LoginModel loginModel)
        {
            var result= await _userRepo.Login(loginModel);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            return await _userRepo.GetAllUsersAsync();
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<User> GetUserByIdAsync(string id)
        {
           return await _userRepo.GetUserByIdAsync(id);
        }
        [HttpPut]
        public async Task UpdateUserAsync(string userId, UserDto userDto)
        {
            await _userRepo.UpdateUserAsync(userId, userDto);
        }
        [HttpDelete]
        public async Task DeleteUserAsync(string userId)
        {
            await _userRepo.DeleteUserAsync(userId);
        }
        [HttpPut]
        [Route("ChangePassword")]
        public async Task ChangePasswordAsync(string userId, string newPassword)
        {
              await _userRepo.ChangePasswordAsync(userId, newPassword);
        }
    }
}
