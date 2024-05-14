using classes;

namespace WebApplication1
{
    public class ClothingDTO: ProductDTO
{
        public string? clothsize;
        public ClothingDTO(Clothing clothing)
            : base(clothing)
        {
            this.clothsize = clothing.Clothsize;
        }
        public ClothingDTO()
        {

        }
    }
}
