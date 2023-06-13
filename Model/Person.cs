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

        protected Person(Guid id, string firstName, string lastName, string pesel, Address address)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Pesel = pesel;
            Address = address;
        }

        protected Person(Guid id, string firstName, string lastName, string pesel)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Pesel = pesel;
            Address = null;
        }
    }
}
