using Catering.DAL.Entities.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Catering.API.Extensions
{
    public static class UserManagerExtensions
    {
        public static async Task<User> FindByEmailFromClaimsPrinciple(this UserManager<User> input, ClaimsPrincipal user)
        {
            var email = user.FindFirstValue(ClaimTypes.Email);

            return await input.Users.SingleOrDefaultAsync(x => x.Email == email);
        }
    }
}
