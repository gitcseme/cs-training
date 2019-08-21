using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQ_In_CSharp
{
    public class DriverClass
    {
        static void Main(string[] args)
        {
            //QueryStringArray();
            //QueryIntArray();
            //QueryArrayList();
            //QueryCollections();
            QueryAnimalData();
        }

        private static void QueryStringArray()
        {
            string[] dogs = {"K 9", "Brian Griffin",
            "Scooby Doo", "Old Yeller", "Rin Tin Tin",
            "Benji", "Charlie B. Barkin", "Lassie",
            "Snoopy"};

            var dogNameWithSpaces = from dog in dogs
                                    where dog.Contains(" ")
                                    select dog;

            foreach (var item in dogNameWithSpaces)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }

        static void QueryIntArray()
        {
            int[] nums = { 5, 10, 15, 20, 25, 30, 35 };
            var gt20 = from n in nums
                       where n > 20
                       orderby n
                       select n;

            nums[1] = 40;

            foreach (var item in gt20)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }

        static void QueryArrayList()
        {
            ArrayList famAnimals = new ArrayList()
            {
                new Animal{
                    Name = "Heidi",
                    Height = .8,
                    Weight = 18
                },

                new Animal
                {
                    Name = "Shrek",
                    Height = 4,
                    Weight = 130
                },

                new Animal
                {
                    Name = "Congo",
                    Height = 3.8,
                    Weight = 90
                }
            };

            // You have to convert the ArrayList into 
            // an IEnumerable
            var famAnimalEnum = famAnimals.OfType<Animal>();

            var smAnimals = from animal in famAnimalEnum
                            where animal.Weight <= 90
                            orderby animal.Name
                            select animal;

            foreach (var animal in smAnimals)
            {
                Console.WriteLine("{0} weighs {1}lbs", animal.Name, animal.Weight);
            }
            Console.WriteLine();
        }

        static void QueryCollections()
        {
            var animalList = new List<Animal>()
            {
                new Animal{Name = "German Shepherd",
                Height = 25,
                Weight = 77},
                new Animal{Name = "Chihuahua",
                Height = 7,
                Weight = 4.4},
                new Animal{Name = "Saint Bernard",
                Height = 30,
                Weight = 200}
            };

            var bigDogs = from dog in animalList
                          where (dog.Weight > 70) && (dog.Height > 25)
                          orderby dog.Name
                          select dog;

            foreach (var dog in bigDogs)
            {
                Console.WriteLine("{0} weights {1} lbs", dog.Name, dog.Weight);
            }
            Console.WriteLine();
        }

        static void QueryAnimalData()
        {
            Animal[] animals = new[]
            {
                new Animal{Name = "German Shepherd",
                Height = 25,
                Weight = 77,
                OwnerId = 1},
                new Animal{Name = "Chihuahua",
                Height = 7,
                Weight = 4.4,
                OwnerId = 2},
                new Animal{Name = "Saint Bernard",
                Height = 30,
                Weight = 200,
                OwnerId = 3},
                new Animal{Name = "Pug",
                Height = 12,
                Weight = 16,
                OwnerId = 1},
                new Animal{Name = "Beagle",
                Height = 15,
                Weight = 23,
                OwnerId = 2}
            };

            Owner[] owners = new[]
            {
                new Owner{Name = "Doug Parks", OwnerId = 1},
                new Owner{Name = "Sally Smith", OwnerId = 2},
                new Owner{Name = "Paul Brooks", OwnerId = 3}
            };

            //Take some property to create new type
            var NameHeight = from a in animals
                             select new
                             {
                                 a.Name,
                                 a.Height
                             };

            foreach (var a in NameHeight)
            {
                Console.WriteLine("Name: {0}, Height: {1}", a.Name, a.Height);
            }

            var innerJoin = from a in animals // Outer loop
                            join o in owners // inner loop
                            on a.OwnerId equals o.OwnerId
                            select new
                            {
                                OwnerName = o.Name,
                                AnimalName = a.Name
                            };

            foreach (var item in innerJoin)
            {
                Console.WriteLine("{0} has {1}", item.OwnerName, item.AnimalName);
            }
            Console.WriteLine();

            // Group join.
            var groupJoin = from owner in owners // Outer for loop
                            join animal in animals // Inner for loop
                            on owner.OwnerId equals animal.OwnerId
                            into AnimalGroup /*Collection of the inner table objects*/
                            select new
                            {
                                OwnerName = owner.Name,
                                AnimalNames = from animal in AnimalGroup
                                              select animal
                            };

            foreach (var item in groupJoin)
            {
                Console.WriteLine(item.OwnerName);
                foreach (var animal in item.AnimalNames)
                {
                    Console.WriteLine(" * {0}", animal);
                }
            }
        }
    }
}
