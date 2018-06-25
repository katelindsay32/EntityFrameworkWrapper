using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkWrapper.Entities
{
    public class Entity3
    {
        public long EntityId { get; set; }
        public long Name { get; set; }

        public long Entity3Id { get; set; }
        public virtual Entity3 Entity3Entity { get; set; }
    }
}
