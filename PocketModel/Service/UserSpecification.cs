using PocketModel.Expertise;
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
    [Table("T_UserSpecification")]
    public class UserSpecification
    {
        public int UserSpecificationId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("Specification")]
        public int SpecificationId { get; set; }

        public Boolean ProvideService { get; set; }

        public Double Rate { get; set; }

        public virtual User User { get; set; }
        public virtual Specification Specification { get; set; }

    }

    public class UserSpecificationMap : EntityTypeConfiguration<UserSpecification>
    {
        public UserSpecificationMap()
        {
            Property(x => x.UserId).IsRequired();
            Property(x => x.SpecificationId).IsRequired();
        }
    }
}
