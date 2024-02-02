using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Abstract
{
    public interface IAuthService
    {
        public String GenerateToken(string? username, string? email, string secretRaw, TimeSpan tokenExpiration);
        public bool Authenticate(string username, string password);
        public String Register(string username, string email, string password);
    }
}