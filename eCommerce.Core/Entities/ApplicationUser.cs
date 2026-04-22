using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserService.Core.Entities
{
    /// <summary>
    /// Define the ApplicationUser class, which acts as a data model for representing users in the application. 
    /// This class includes properties such as UserId, Email, Password,PersonName, Gender.
    /// </summary>
    public class ApplicationUser
    {
        public Guid UserId { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? PersonName { get; set; }
        public string? Gender { get; set; }
    }
}
