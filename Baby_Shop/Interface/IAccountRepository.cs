using Baby_Shop.Models;
using Microsoft.AspNetCore.Identity;

namespace Baby_Shop.Interface
{
    public interface IAccountRepository
    {
        public Task<IdentityResult> SignUpAsync(SignUpModel model);

        public Task<string> SignInAsync(SignInModel model);
    }
}
