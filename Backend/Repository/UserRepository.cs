using AutoMapper;
using Backend.Data;
using Backend.Dto;
using Backend.Helpers;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace Backend.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly APIContext _context;


        public UserRepository(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, APIContext context, IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _context = context;
            _mapper = mapper;
        }

        public Task AddRoleToUserAsync(string userId, string roleName)
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> AuthenticateAsync(string username, string password)
        {
            throw new NotImplementedException();
        }

        public async Task ChangePasswordAsync(string userId, string newPassword)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                
                 throw new Exception($"User with id {userId} not found.");
                
            }

            // Sử dụng UserManager để thay đổi mật khẩu của người dùng
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, token, newPassword);

            
            if (!result.Succeeded)
            {
                 throw new Exception($"Failed to change password: {string.Join(",", result.Errors.Select(e => e.Description))}");
            }
        }

        public async Task DeleteUserAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                throw new Exception($"User with id {userId} not found.");
                
            }
            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                 throw new Exception($"Failed to delete user: {string.Join(",", result.Errors.Select(e => e.Description))}");
            }
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _context.Users.ToListAsync();
            var usersDto = _mapper.Map<IEnumerable<UserDto>>(users);

            return usersDto;
        }


        public async Task<User> GetUserByIdAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            return user;

        }

        public async Task<IActionResult> Login([Bind(new[] { "Username,Password" })] LoginModel loginModel)
        {
            var user = await _userManager.FindByNameAsync(loginModel.Username);
            var passwordCheck = await _userManager.CheckPasswordAsync(user,loginModel.Password);
            if (user == null||!passwordCheck)
            {
                return new UnauthorizedResult();
            }
            //if (await _userManager.CheckPasswordAsync(user, loginModel.Password) == false)
            //{
            //    return new UnauthorizedResult();
            //}
            var userRoles = await _userManager.GetRolesAsync(user);
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                //new Claim(ClaimTypes.Role,"Admin")
            };
            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );
            var userDto = _mapper.Map<UserDto>(user);
            return new OkObjectResult(new
            {
                userDto,
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            });
        }

        public async Task<IActionResult> Register(string Username, string Password, string Email,string Firstname,string Lastname,string Phonenumber)
        {
            var userExist = await _userManager.FindByNameAsync(Username);
            if (userExist != null)
            {
                var errorResponse = new { Message = "User already exists" };
                return new BadRequestObjectResult(errorResponse);
            }
            User user = new User()
            {
                
                UserName = Username,
                SecurityStamp = Guid.NewGuid().ToString(),
                Email = Email,
                FirstName=Firstname,
                LastName=Lastname,
                PhoneNumber=Phonenumber
                
            };
            var result = await _userManager.CreateAsync(user, Password);
            //if (!result.Succeeded)
            //{
            //    var errorResponse = new { Message = "Something went wrong!" };
            //    return new BadRequestObjectResult(errorResponse);
            //}
            //if (await _roleManager.RoleExistsAsync("User"))
            //{
            //    await _userManager.AddToRoleAsync(user, "User");
            //}
            if (result.Succeeded)
            {
                if(!await _roleManager.RoleExistsAsync(ApplicationRole.User))
                {
                    await _roleManager.CreateAsync(new IdentityRole(ApplicationRole.User));
                }
                await _userManager.AddToRoleAsync(user, ApplicationRole.User);
            }
            return new OkResult();
        }

        public async Task<IActionResult> RegisterAdmin(string Username, string Password, string Email, string Firstname, string Lastname, string Phonenumber)
        {
            var userExist = await _userManager.FindByNameAsync(Username);
            if (userExist != null)
            {
                var errorResponse = new { Message = "User already exists" };
                return new BadRequestObjectResult(errorResponse);
            }
            var user = new User()
            {
                UserName = Username,
                SecurityStamp = Guid.NewGuid().ToString(),
                Email = Email,
                FirstName = Firstname,
                LastName = Lastname,
                PhoneNumber = Phonenumber
            };
            var result=await _userManager.CreateAsync(user, Password);
            if (!result.Succeeded)
            {
                var errorResponse = new { Message = "User already exists" };
                return new BadRequestObjectResult(errorResponse);
            }
            if (!await _roleManager.RoleExistsAsync(ApplicationRole.Admin))
            {
                await _roleManager.CreateAsync(new IdentityRole(ApplicationRole.Admin));
            }
            if (!await _roleManager.RoleExistsAsync(ApplicationRole.User))
            {
                await _roleManager.CreateAsync(new IdentityRole(ApplicationRole.User));
            }
            if (await _roleManager.RoleExistsAsync(ApplicationRole.Admin))
            {
                await _userManager.AddToRoleAsync(user, ApplicationRole.Admin);
            }
            return new OkResult();

        }

        public Task RemoveRoleFromUserAsync(string userId, string roleName)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateUserAsync(string userId, UserDto userDto)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {

                throw new Exception($"User with id {userId} not found.");

            }
            _mapper.Map(userDto, user);
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {

                throw new Exception($"Failed to update user: {string.Join(",", result.Errors.Select(e => e.Description))}");
            }
        }
    }
}
