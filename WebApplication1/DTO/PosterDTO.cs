using System.ComponentModel.DataAnnotations;
using classes;

namespace WebApplication1
{
    public class PosterDTO : ProductDTO
    {
       
        public bool? Frame { get; set; }
        public string? Size { get; set; }
        [Required]
        public string Direction { get; set; }

        public PosterDTO()
        {
        }

        public PosterDTO(Poster poster) : base(poster)
        {
            Frame = poster.Frame;
            Size = poster.Size;
            Direction = poster.PosterDirection;
        }
    }
}
