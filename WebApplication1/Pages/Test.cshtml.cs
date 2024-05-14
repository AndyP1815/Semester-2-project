using System.Security.Cryptography.X509Certificates;
using classes;
using classes.Managers;
using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1
{
    public class TestModel : PageModel
    {
        private Usermanager usermanager;
        public List<UserDTO> UsersList;
        private const string PageUrl = "/User";
        private UserRepo userRepo = new UserRepo();
        public TestModel()
        {

            //this.usermanager = new Usermanager(userRepo);
            this.UsersList = new List<UserDTO>();
            foreach (User u in usermanager.Users)
            {
                UsersList.Add(new UserDTO(u));
            }
        }
        
        public void OnGet()
        {
          
        }
    }
}
