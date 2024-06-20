using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace eExamApp.Models
{
    public class UserVM
    {
        public string Name { get; set; }
        public string Password { get; set; }

        [DisplayName("User Type")]
        public string UserType { get; set; }
        public List<SelectListItem> UserTypes { get; set; }
    }
}
