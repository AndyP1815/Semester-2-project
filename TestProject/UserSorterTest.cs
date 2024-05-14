using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using classes.Managers;
using classes;
using classes.Interfaces;
using FakeDAL;

namespace TestProject
{
    [TestClass]
    public class UserSorterTest
    {
        private IUserRepo userRepo;
        private Usermanager usermanager;
        private UserSorter userSorter;
        public UserSorterTest()
        {
            this.userRepo = new FakeUserRepository();
            this.usermanager = new Usermanager(userRepo, new FakeCartRepositroy(), new FakeProductRepository());
            this.userSorter = new UserSorter(userRepo, new FakeCartRepositroy(), new FakeProductRepository());
        }

        [TestMethod]
        public void NameFilter()
        {
            User user = userSorter.GetUserByName(usermanager.Users, "123456");
            
            Assert.IsNotNull(user);
            

        }
        [TestMethod]
        public void NameFilterFail()
        {
            User userFail = userSorter.GetUserByName(usermanager.GetAllUser(), "fail");
            Assert.IsNull(userFail);
        }
        [TestMethod]
        public void UserSorter()
        {
            Assert.IsInstanceOfType(userSorter.FilterUser(1)[0], typeof(User));
            Assert.IsInstanceOfType(userSorter.FilterUser(2)[0], typeof(Seller));
        }
        [TestMethod]
        public void UserSorterOutOfIndex()
        {            
            int index = 3;

            Assert.ThrowsException<IndexOutOfRangeException>(() => userSorter.FilterUser(3));
        }
        [TestMethod]
        public void SortByName()
        {
           
            List<User> users= usermanager.GetAllUser();

            userSorter.SortUserByName(users);

            Assert.AreEqual("123456", users[0].Username);
            Assert.AreEqual("Seller", users[1].Username);

        }
        public void SoryByID()
        {
            List<User> users = usermanager.Users;

            users.Sort();
            Assert.AreEqual(1, users[0].ID);
            Assert.AreEqual(2, users[1].ID);
        }

    }
}
