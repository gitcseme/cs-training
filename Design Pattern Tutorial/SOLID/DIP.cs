using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID
{
    public enum Relationship
    {
        Parent,
        Chield,
        Sibling
    }

    public class Person
    {
        public string Name { get; set; }
    }

    public interface IRelationshipBrowser
    {
        IEnumerable<Person> FindChildren(string name);
    }

    // Lower lavel module
    public class Relationships : IRelationshipBrowser
    {
        private List<(Person, Relationship, Person)> relations 
            = new List<(Person, Relationship, Person)>();

        public void AddParentChield(Person parent, Person child)
        {
            relations.Add((parent, Relationship.Parent, child));
            relations.Add((child, Relationship.Chield, parent));
        }

        public IEnumerable<Person> FindChildren(string name)
        {
            return relations.Where(
                x => x.Item1.Name == name &&
                     x.Item2 == Relationship.Parent)
                .Select(r => r.Item3);
        }

        //public List<(Person, Relationship, Person)> Relations => relations;
    }

    // High lavel module
    // This high level module should not need to know internal DS of low lavel module.
    // Solution: Now we interecting with an Interface contract.
    public class Research
    {
        public Research(IRelationshipBrowser relationships)
        {
            var relations = relationships.FindChildren("Jhon");
            foreach (var p in relations)
            {
                Console.WriteLine($"John is father of {p.Name}");
            }
        }
    }

    public class DIP
    {
        static void Main(string[] args)
        {
            var parent = new Person { Name = "Jhon" };
            var child1 = new Person { Name = "Chris" };
            var child2 = new Person { Name = "Mary" };

            var relationships = new Relationships();
            relationships.AddParentChield(parent, child1);
            relationships.AddParentChield(parent, child2);

            new Research(relationships);
        }
    }
}
