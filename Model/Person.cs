using System;
using System.ComponentModel.DataAnnotations;

namespace CarWorkshop.Model
{
    public abstract class Person
    {
        [Key]
        public Guid Id  {get; set;}
        [MaxLength(30)]
        public string FirstName { get; set; }
        [MaxLength(30)]
        public string LastName { get; set; }
        [MaxLength(11)]
        public string Pesel { get; set; }
        public Address? Address { get; set; }

        /// <summary>
        /// Constructor for EF
        /// </summary>
        protected Person() { }

        public Person(Guid id, string firstName, string lastName, string pesel, Address? address = null)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Pesel = pesel;
            Address = address;
        }
    }
}
