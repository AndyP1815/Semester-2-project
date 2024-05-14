using System.ComponentModel.DataAnnotations;
using classes;

namespace WebApplication1
{
    public class BooksDTO: ProductDTO
{
        public bool Ebook { get; set; }
        [Required]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Please enter a valid integer.")]
        public int Pages { get; set; }

        public BooksDTO()
        {

        }
        public BooksDTO(Books books)
            : base(books)
        {
            this.Pages = books.Pages;
            this.Ebook = books.Ebook;
      
        }
    }
}
