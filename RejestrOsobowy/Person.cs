using System;
using System.Collections.Generic;
using System.Text;

namespace RejestrOsobowy
{
    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Sex { get; set; }
        public string Zipcode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string ApartmentNumber { get; set; }

        public Person()
        {

        }

        public Person(string name, string surname, DateTime birthdateyear, int sex, string zipcode, string city, string street, string housenumer, string apartmentnumber)
        {
            this.Name = name;
            this.Surname = surname;
            this.DateOfBirth = birthdateyear;
            this.Sex = sex;
            this.Zipcode = zipcode;
            this.City = city;
            this.Street = street;
            this.HouseNumber = housenumer;
            this.ApartmentNumber = apartmentnumber;
        }

    }
}
