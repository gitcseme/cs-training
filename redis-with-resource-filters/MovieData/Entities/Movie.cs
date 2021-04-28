using System;
using System.Collections.Generic;

namespace MovieData.Entities
{
    public class Movie 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }

        public List<Actor> Actors { get; set; } = new List<Actor>();
    }
}