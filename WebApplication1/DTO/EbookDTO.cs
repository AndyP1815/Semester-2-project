using System.ComponentModel.DataAnnotations;
using classes;

namespace WebApplication1
{
    public class EbookDTO : BooksDTO
{
        [Required]
        public string Downloadlink { get; set; }

        public EbookDTO()
        {


        }
        public EbookDTO(Ebook ebook):
            base(ebook)
        {
            this.Downloadlink = ebook.DownloadLink;
        }

    }
}
