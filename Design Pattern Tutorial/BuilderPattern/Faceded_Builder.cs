using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    /*
     * Used 2 partial builder to provide seperate API
     */

    public class Person
    {
        // Test property
        public int exist;

        // Address
        public string StreetAddress, PostCode, City;

        // Employee
        public string CompanyName, Position;
        public int AnnualIncome;

        public override string ToString()
        {
            return $"Street Address: {StreetAddress}\n Post Code: {PostCode}\n City: {City}\n\nCompany Name: {CompanyName}\n Position: {Position}\n Annual Income: {AnnualIncome}\n";
        }
    }

    public class PersonBuilder // Facade
    {
        // This reference is used in Works and Lives.
        protected Person person = new Person { exist = 999 }; 

        public PersonJobBuilder Works => new PersonJobBuilder(person);
        public PersonAddressBuilder Lives => new PersonAddressBuilder(person);

        public Person GetPerson => person;
    }

    public class PersonAddressBuilder : PersonBuilder
    {
        public PersonAddressBuilder(Person person)
        {
            this.person = person;
        }

        public PersonAddressBuilder At(string streetAddress)
        {
            this.person.StreetAddress = streetAddress;
            return this;
        }

        public PersonAddressBuilder WithPostCode(string postCode)
        {
            this.person.PostCode = postCode;
            return this;
        }

        public PersonAddressBuilder In(string city)
        {
            this.person.City = city;
            return this;
        }
    }

    public class PersonJobBuilder : PersonBuilder
    {
        public PersonJobBuilder(Person person)
        {
            this.person = person;
        }

        public PersonJobBuilder At(string companyName)
        {
            person.CompanyName = companyName;
            return this;
        }

        public PersonJobBuilder AsA(string position)
        {
            person.Position = position;
            return this;
        }

        public PersonJobBuilder Earning(int amount)
        {
            person.AnnualIncome = amount;
            return this;
        }
    }

    public class Faceded_Builder
    {
        static void Main(string[] args)
        {
            PersonBuilder pb = new PersonBuilder();
            var person = pb
                .Lives.At("23/1 power house road")
                      .In("Berlin")
                      .WithPostCode("SWE5568-9985")
                .Works.At("Grab")
                      .AsA("Software Engineer")
                      .Earning(123000);

            Console.WriteLine(person.GetPerson);
        }
    }
}
