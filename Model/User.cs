using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Model
{
    public class User : Person
    {
        [MaxLength(30)]
        public string Login { get; set; }
        [MaxLength(30)]
        public string Password { get; set; }
        public List<UserPermission> Permissions { get; set; }

        /// <summary>
        /// Constructor for EF
        /// </summary>
        private User(){}

        public User(Person person, string login, string password) : base(person.Id,person.FirstName, person.LastName, person.Pesel)
        {
            Login = login;
            Password = password;
            Permissions = new List<UserPermission>();
        }
    }

    public enum UserPermission
    {
        Admin = 1,
        OfficeWorker = 2,
        Mechanics = 3
    }
}
