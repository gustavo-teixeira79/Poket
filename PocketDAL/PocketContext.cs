using PocketModel.Expertise;
using PocketModel.People;
using PocketModel.Service;
using System.Data.Entity;

namespace PocketDAL
{
    public class PocketContext: DbContext 
    {
        public PocketContext() : base("Name=PocketDBConn")
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Expertise> Expertises { get; set; }
        public DbSet<Specification> Specifications { get; set; }
        public DbSet<UserSpecification> UserSpecifications { get; set; }
        public DbSet<UserService> UserServices { get; set; }
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new PersonMap());
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new ExpertiseMap());
            modelBuilder.Configurations.Add(new SpecificationMap());
            modelBuilder.Configurations.Add(new UserSpecificationMap());
            modelBuilder.Configurations.Add(new UserServiceMap());
        }
    }
}