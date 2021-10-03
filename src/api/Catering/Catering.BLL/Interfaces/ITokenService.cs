using Catering.DAL.Entities.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.BLL.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
