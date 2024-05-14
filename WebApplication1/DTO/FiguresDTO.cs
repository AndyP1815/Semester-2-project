using System.ComponentModel.DataAnnotations;
using classes;

namespace WebApplication1
{
    public class FiguresDTO: ProductDTO
    {
        [Required]
        public string Dimensions { get; set; }
       
        public bool? Colored { get; set; }

        public FiguresDTO() 
        {
            
        }
        public FiguresDTO(Figures figures)
            : base(figures)
        {
            this.Dimensions = figures.Dimensions;
            this.Colored = figures.Colored;

        }
    }
}
