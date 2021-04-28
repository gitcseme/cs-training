using System;

namespace MovieData.Entities
{
    public class Actor {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Movie Movie { get; set; }
        public Guid MovieId { get; set; }
    }
}