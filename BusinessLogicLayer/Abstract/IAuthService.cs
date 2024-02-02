using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Abstract
{
    public interface IAuthService
    {
        public String GenerateToken(string username, string email, string secretRaw);

    }
}