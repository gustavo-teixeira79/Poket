using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using PocketDAL;
using PocketModel.User;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;

namespace PocketMApp.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //IQueryable<User> query;
            //using (var ctx = new PocketContext())
            //{
            //    ctx.Database.Initialize(false);
            //}
            
        }

        [TestMethod]
        public void AddAdminUser()
        {
            using (var ctx = new PocketContext())
            {
                if (ctx.Users.FirstOrDefault(x => x.Email == "admin@pocket.com") == null)
                {
                    ctx.Users.Add(new User { FisrtName = "ADMIN", LastName = "ADMIN", Password = "Welcome1", Email = "admin@pocket.com" });
                    ctx.SaveChanges();
                }
            }
        }

    }
}
