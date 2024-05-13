using Backend.Dto;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Interfaces
{
    public interface IUserRepository
    {
        Task<IActionResult> Login([Bind("Username,Password")] LoginModel loginModel);
        Task<IActionResult> Register(string Username, string Password, string Email,string Firstname,string Lastname,string Phonenumber);
        Task<IActionResult> RegisterAdmin(string Username, string Password, string Email, string Firstname, string Lastname, string Phonenumber);
        Task<User> GetUserByIdAsync(string id);
        Task UpdateUserAsync(string userId, UserDto userDto);
        Task DeleteUserAsync(string userId);
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task ChangePasswordAsync(string userId, string newPassword);
        Task AddRoleToUserAsync(string userId, string roleName);
        Task RemoveRoleFromUserAsync(string userId, string roleName);
        Task<UserDto> AuthenticateAsync(string username, string password);

    }
}
