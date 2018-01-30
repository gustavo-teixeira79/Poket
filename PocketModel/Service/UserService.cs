using PocketModel.People;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketModel.Service
{
    [Table("T_UserService")]
    public class UserService
    {
        public int UserServiceId { get; set; }

        //person contracting the service
        [ForeignKey("User")]
        public int UserId { get; set; } 

        //person providing the service
        [ForeignKey("UserSpecification")]
        public int UserSpecificationId { get; set; }

        public double Duration { get; set; }

        public DateTime StartTime { get; set; }

        public virtual User User { get; set; }
        public virtual UserSpecification UserSpecification { get; set; }
    }

    public class UserServiceMap : EntityTypeConfiguration<UserService>
    {
        public UserServiceMap()
        {
            Property(x => x.UserId).IsRequired();
            Property(x => x.UserSpecificationId).IsRequired();
            Property(x => x.Duration).IsRequired();
            Property(x => x.StartTime).IsRequired();

        }
    }

}
