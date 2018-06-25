using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkWrapper.Entities.EntityConfiguration
{
    public class Entity1Configuration : EntityTypeConfiguration<Entity1>
    {
        public Entity1Configuration()
        {
            this.HasKey(f => f.EntityId);
            this.Property(f => f.Name).HasMaxLength(50);
        }
    }
}
