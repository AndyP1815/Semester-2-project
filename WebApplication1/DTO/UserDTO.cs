using System.ComponentModel.DataAnnotations;
using classes;
using classes.classes;

namespace WebApplication1
{
    public class UserDTO
{
        public UserDTO(User user)
        {
            this.Username = user.Username;
            this.Password = user.Password;
            this.ID = user.ID;
            this.salt = user.Salt;
            this.Adress = user.Adress;
   

        }
        public UserDTO()
        {

        }
     

        public Cart Cart;
       
        public FavoriteList FavoriteList;
        public List<Order> Orders;
        [Required]
        public string Username { get;set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Adress { get; set; }
		public int ID { get; set; }
        public string salt;
        
}
}
