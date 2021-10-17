using System.ComponentModel.DataAnnotations;

namespace ListBookApp.Models.Book
{
    public class DeleteBook
    {
        public int IdBook { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "ISNB")]
        public string ISBN { get; set; }   
    }
}