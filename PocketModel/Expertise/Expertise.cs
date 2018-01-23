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
    [Table("T_Expertise")]
    public class Expertise
    {
        public Expertise()
        {
            Status = CommonStatus.Active;
        }
        public int ExpertiseId { get; set; }
        public string Name { get; set; }
        public CommonStatus Status { get; set; }
    }

    public class ExpertiseMap : EntityTypeConfiguration<Expertise>
    {
        public ExpertiseMap()
        {
            Property(x => x.Name).HasMaxLength(50).IsRequired();
        }
    }

}
