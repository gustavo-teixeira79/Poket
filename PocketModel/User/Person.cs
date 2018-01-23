using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PocketModel.User
{
    [Table("T_People")]
    public abstract class Person
    {
        [Key]
        public int PersonId { get; set; }
        public string FisrtName { get; set; }
        public string LastName { get; set; }
        protected string FullName { get { return FisrtName + " " + LastName; } }
        public string Email { get; set; }
        public string Password { get; set; }
    }


    public class PersonMap : EntityTypeConfiguration<Person>
    {
        public PersonMap()
        {
            Property(x => x.FisrtName).HasMaxLength(50).IsRequired();
            Property(x => x.LastName).HasMaxLength(50).IsRequired();
            Property(x => x.Email).HasMaxLength(255).IsRequired();
            Property(x => x.Password).HasMaxLength(16).IsRequired();
        }
    }
}