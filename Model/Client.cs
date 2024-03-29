﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarWorkshop.Model
{
    public class Client :Person
    {
        [MaxLength(11)]
        public string ContactNumber { get; set; }
        [MaxLength(20)]
        public string? NipNumber { get; set; }
        public List<Car> Cars { get; set; }

        /// <summary>
        /// Constructor for EF
        /// </summary>
        private Client() { }

        public Client(Guid id, string firstName, string lastName, string pesel, string contactNumber, string nipNumber, Address? address = null) : base(id, firstName, lastName, pesel, address)
        {
            ContactNumber = contactNumber;
            NipNumber = nipNumber;
            Cars = new List<Car>();
        }
    }
}
