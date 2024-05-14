using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using classes;
using classes.Interfaces;
using classes.Managers;
using DAL;
using FakeDAL;

namespace TestProject
{
    [TestClass]
    public class UserTesting
    {
        private IUserRepo userRepo;
        private Usermanager usermanager;
        public UserTesting()
        {
            this.userRepo = new FakeUserRepository();
            this.usermanager = new Usermanager(userRepo, new FakeCartRepositroy(), new FakeProductRepository());
        }
        [TestMethod]
        public void UserByname()
        {
            string name = "123456";
            User user = usermanager.GetUserByName(name);
            Assert.AreEqual(name, user.Username.Trim());
        }
        [TestMethod]
        public void TestHashing()
        {
            string password = "123456";

            string Hash = usermanager.HashPassword(password, out var salt);

            Assert.IsNotNull(salt);
            Assert.IsFalse(string.IsNullOrWhiteSpace(Hash));

        }
        [TestMethod]
        public void VerifyPassword()
        {
           var e = usermanager.VerifyPassword("123456","123456");
           Assert.AreEqual(true, e);
        }

        public void CreateUserSeller()
        {
            User u = new User("Name","pw","Adress","Salt",2);
            User s = new Seller("Name", "pw", "Adress", "Salt", 2);
            usermanager.CreateUser(u);
            usermanager.CreateUser(s);

            User TestUser = usermanager.GetUserByName(u.Username);
            User TestSeller = usermanager.GetUserByName(s.Username);

            Assert.IsInstanceOfType(TestUser, typeof(User));
            Assert.IsInstanceOfType(TestSeller, typeof(Seller));
        }
    

    }
}
