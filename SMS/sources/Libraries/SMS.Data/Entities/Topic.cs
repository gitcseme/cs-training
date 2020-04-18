using System;
using System.ComponentModel.DataAnnotations;

namespace SMS.Data.Entities
{
    public class Topic : EntityBase<Guid>
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        public Guid CourseId { get; set; }
        public virtual Course Course { get; set; }
    }
}