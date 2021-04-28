using System.ComponentModel.DataAnnotations;

namespace MovieTracker.Models
{
    public class MovieCreateViewModel 
    {
        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        public string Image { get; set; }
    }
}