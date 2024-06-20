using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eExam.Core.Interfaces
{
    public interface IAccountService
    {
        string UserRegistration(string username, string password,string userType);
        string UserLogin(string username, string password);
    }
}
