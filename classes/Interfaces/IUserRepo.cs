using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace classes.Interfaces
{
     public interface IUserRepo
    {
        List<User> GetUsers();
        List<User> GetAllUsers();
        List<Seller> GetSellers();
        void UpdateUser(int id,User user);
        void RemoveUser(int id);
        User GetUserByid(int id);
        void CreateUser(User user);
        void CreateSeller(Seller seller);
        int GetUserId();
        List<User> GetUserByName(string name);
        List<string> GetProductIdsFromSeller(int Seller_id);

    }
}
