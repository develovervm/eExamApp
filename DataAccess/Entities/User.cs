using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string UserType {  get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
