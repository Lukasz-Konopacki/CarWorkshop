namespace CarWorkshop.Model
{
    public abstract class Person 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Pesel { get; set; }
        public Address? Address { get; set; }

        protected Person(string firstName, string lastName, string pesel, Address address)
        {
            FirstName = firstName;
            LastName = lastName;
            Pesel = pesel;
            Address = address;
        }

        protected Person(string firstName, string lastName, string pesel)
        {
            FirstName = firstName;
            LastName = lastName;
            Pesel = pesel;
            Address = null;
        }
    }
}
