using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.CustomValidation
{
    public class CustomUserValidator : IUserValidator<AppUser>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user)
        {

            List<IdentityError> errors = new List<IdentityError>();
              if (user.UserName.ToString() != user.Email.Split("@")[0])
            {
                errors.Add(new IdentityError()
                {
                    Code = "UserNameMustContainTheBegginingOfTheMail",
                    Description = "Kullanıcı adınız, Emailinizde ki @ işaretinden önceki kısım olmalıdır."
                });
            }
            if (errors.Count == 0)
            {
                return Task.FromResult(IdentityResult.Success);
            }

            else
            {
                return Task.FromResult(IdentityResult.Failed(errors.ToArray()));
            }

        }
    }
}
