using classes;

namespace WebApplication1
{
    public class FavoriteListDTO
{
        public string Name { get; set; }
        public int ID { get; set; }

        public List<ProductDTO> Product = new List<ProductDTO>();
        public bool Selected { get; set; }
        public FavoriteListDTO() 
        {

        }
        public FavoriteListDTO(FavoriteList favoriteList,List<ProductDTO>productDTOs)
        {
            this.Name = favoriteList.GetName();
            this.ID = favoriteList.GetFavoriteListid();
            this.Product = productDTOs;
        }

    }
}
