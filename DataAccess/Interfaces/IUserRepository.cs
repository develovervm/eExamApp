using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IUserRepository
    {
        User Add(User user);
        User Update(User user);
        void Delete(int id);
        User Get(int id);
        User GetUser(string username);
        List<User> GetAll();
    }
}
