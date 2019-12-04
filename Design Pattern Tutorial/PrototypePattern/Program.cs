using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace PrototypePattern
{
    /*
     * Using copy constructor
     * Using Clone method
     * Serialiation & Deserialization
     */

    // Prototype builder -- clone for any object -- Deep copy
    public static class ExtensionMethod
    {
        // BinarySerializer needs [Serializable] attribute
        public static T DeepCopy<T>(this T Self)
        {
            var stream = new MemoryStream();
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, Self);

            stream.Seek(0, SeekOrigin.Begin);
            object copy = formatter.Deserialize(stream);
            stream.Close();
            return (T) copy;
        }

        // XmlSerializer does not need [Serializable] attribute but needs empty constructor
        public static T DeepCopyXml<T>(this T Self)
        {
            using(var stream = new MemoryStream())
            {
                var xmlSerializer = new XmlSerializer(typeof(T));
                xmlSerializer.Serialize(stream, Self);
                stream.Position = 0;

                object copy = xmlSerializer.Deserialize(stream);
                return (T) copy;
            }
        }
    }

    [Serializable]
    public class Person
    {
        public string[] Names;
        public Address Address;

        public Person() {}

        public Person(string[] names, Address address)
        {
            Names = names;
            Address = address;
        }

        public override string ToString()
        {
            return $"Name: {string.Join(' ', Names)} Address: {Address}";
        }
    }

    [Serializable]
    public class Address
    {
        public Address(string StreetName, int HouseNumber)
        {
            this.StreetName = StreetName;
            this.HouseNumber = HouseNumber;
        }

        public Address() {}

        public string StreetName { get; set; }
        public int HouseNumber { get; set; }

        public override string ToString()
        {
            return $"Street: {StreetName}, House: {HouseNumber}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Person john = new Person(new[] { "John", "Smith" }, new Address("London Road", 12354));

            Person roney = john.DeepCopyXml();
            roney.Names[0] = "Roney";
            roney.Names[1] = "Padukon";
            roney.Address.HouseNumber = 321;

            Console.WriteLine(john);
            Console.WriteLine(roney);
        }
    }
}
