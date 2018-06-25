using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkWrapper.Entities
{
    public interface IEntityContextWrapper
    {
        EntityContext GetDbContext();
    }

    public class EntityContextWrapper : IEntityContextWrapper
    {
        public EntityContext GetDbContext()
        {
            return new EntityContext();

        }
    }

    public class EntityContext : DbContext
    {
        public DbSet<Entity1> Entity1 { get; set; }
        public DbSet<Entity2> Entity2 { get; set; }
        public DbSet<Entity3> Entity3 { get; set; }

    }
}
