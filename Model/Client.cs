namespace CarWorkshop.Model
{
    public class Client :Person
    {
        public string ContactNumber { get; set; }
        public string NipNumber { get; set; }

        public Client(string firstName, string lastName, string pesel, string contactNumber, string nipNumber, Address address) : base(firstName, lastName, pesel, address)
        {
            ContactNumber = contactNumber;
            NipNumber = nipNumber;
        }
    }
}
