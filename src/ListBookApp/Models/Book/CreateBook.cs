using System.ComponentModel.DataAnnotations;

namespace ListBookApp.Models.Book
{
    public class CreateBook
    {
        [Display(Name = "Name")]
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        [Display(Name = "ISNB")]
        [Required]
        [MaxLength(16)]
        public string ISBN { get; set; }   
    }
}