using AuthenticationDLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2VG
{
    public interface IAuthenticationModel
    {
        Authentication.UserRole AuthenticateUser(string username, string password);
     
       
    }
}
