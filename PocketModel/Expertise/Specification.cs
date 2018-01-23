using PocketModel.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketModel.Expertise
{
    [Table("T_Specification")]
    public class Specification
    {
        public Specification()
        {
            Status = CommonStatus.Active;
        }

        public int SpecificationId { get; set; }
        public string Name { get; set; }
        public int ExpertiseId { get; set; }
        public CommonStatus Status { get; set; }
    }

    public class SpecificationMap : EntityTypeConfiguration<Specification>
    {
        public SpecificationMap()
        {
            Property(x => x.Name).HasMaxLength(50).IsRequired();
        }
    }

}
