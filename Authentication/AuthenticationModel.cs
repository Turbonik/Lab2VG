using AuthenticationDLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Lab2VG
{
    public class AuthenticationModel : IAuthenticationModel
    {
       
        private readonly Authentication _authentication;

        public AuthenticationModel(string usersFilePath)
        {
            _authentication = new Authentication(usersFilePath);
        }

        public Authentication.UserRole AuthenticateUser(string username, string password)
        {
            Authentication.UserRole userRole = Authentication.AuthenticateUser(username, password);
            return userRole;
        }
    }
}
