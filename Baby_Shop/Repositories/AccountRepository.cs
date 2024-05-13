using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Baby_Shop.Data;
using Baby_Shop.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Baby_Shop.Model;
using Baby_Shop.Helpers;
using Baby_Shop.Interface;

namespace Baby_Shop.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IConfiguration configuration;
        private readonly RoleManager<IdentityRole> roleManager;

        public AccountRepository(UserManager<User> userManager, SignInManager<User> signInManager,IConfiguration configuration,RoleManager<IdentityRole>roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
            this.roleManager = roleManager;
        }
        public async Task<string> SignInAsync(SignInModel model)
        {
            var user= await userManager.FindByEmailAsync(model.Email);
            var passwordValid=await userManager.CheckPasswordAsync(user, model.Password);
            if(user == null||passwordValid)
            {
                return String.Empty;
            }
             

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, model.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var userRole=await userManager.GetRolesAsync(user);
            foreach(var role in userRole)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role.ToString()));
            }

            var authenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: configuration["JWT:ValidIssuer"],
                audience: configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddMinutes(20),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authenKey, SecurityAlgorithms.HmacSha512Signature)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public async Task<IdentityResult> SignUpAsync(SignUpModel model)
        {
            var user = new User
            {
                FirstName=model.Firstname,
                LastName=model.Lastname,
                UserName = model.Email,
                Email = model.Email,
                PhoneNumber=model.PhoneNumber
            };
             var kq=  await userManager.CreateAsync(user, model.Password);
            if (kq.Succeeded)
            {
                if(!await roleManager.RoleExistsAsync(ApplicationRole.Customer))
                {
                    await roleManager.CreateAsync(new IdentityRole(ApplicationRole.Customer));
                }

                await userManager.AddToRoleAsync(user, ApplicationRole.Customer);
            }
            return kq;
        }
    }
}
