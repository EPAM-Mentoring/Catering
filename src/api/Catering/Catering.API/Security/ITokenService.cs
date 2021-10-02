using Catering.DAL.Entities.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catering.API.Security
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
