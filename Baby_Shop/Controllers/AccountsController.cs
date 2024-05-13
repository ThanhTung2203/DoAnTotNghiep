using Baby_Shop.Interface;
using Baby_Shop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace Baby_Shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountRepository accountRepo;
        public AccountsController(IAccountRepository repo)
        {
            accountRepo = repo;
        }
        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(SignUpModel model)
        {
            var kq = await accountRepo.SignUpAsync(model);
            if (kq.Succeeded)
            {
                return Ok(kq.Succeeded);
            }
            return Unauthorized(new { error = "Sign-up failed", details = kq.Errors });
        }
        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(SignInModel model)
        {
            var kq = await accountRepo.SignInAsync(model);
            if (string.IsNullOrEmpty(kq))
            {
                return Unauthorized();
            }
            return Ok(kq);
        }
    }
}
