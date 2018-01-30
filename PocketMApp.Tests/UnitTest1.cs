using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using PocketDAL;
using PocketModel.People;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using PocketModel.Expertise;


namespace PocketMApp.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            IQueryable<User> query;
            using (var ctx = new PocketContext())
            {
                //ctx.Database.Initialize(false);
                if (ctx.Expertises.FirstOrDefault(x=>x.Name == "Language") == null)
                {
                    ctx.Expertises.Add(new Expertise{ Name = "Language" });
                    ctx.SaveChanges();
                    int eId = ctx.Expertises.FirstOrDefault(x=>x.Name == "Language").ExpertiseId;
                    ctx.Specifications.Add(new Specification{ Name = "English", ExpertiseId = eId});
                    ctx.Specifications.Add(new Specification{ Name = "Portuguese", ExpertiseId = eId});
                    ctx.SaveChanges();
                }
            }
            
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
