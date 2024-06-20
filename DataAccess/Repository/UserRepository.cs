using DataAccess.Data;
using DataAccess.Entities;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }
        public User Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public void Delete(int id)
        {
            var dbUser= _context.Users.Where(u => u.Id == id).FirstOrDefault();
            _context.Users.Remove(dbUser);
            _context.SaveChanges();
           
        }

        public User Get(int id)
        {
            return _context.Users.Where(u => u.Id == id).FirstOrDefault();
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User GetUser(string username)
        {
            return _context.Users.Where(x => x.UserName == username).FirstOrDefault();
        }

        public User Update(User user)
        {
            var dbUser=_context.Users.Where(x=>x.Id == user.Id).FirstOrDefault();
            dbUser.UserName = user.UserName;
            dbUser.UserType = user.UserType;
            dbUser.PhoneNo= user.PhoneNo;
            dbUser.Email = user.Email;

            _context.Users.Update(dbUser);
            _context.SaveChanges();
            return dbUser;
        }
    }
}
