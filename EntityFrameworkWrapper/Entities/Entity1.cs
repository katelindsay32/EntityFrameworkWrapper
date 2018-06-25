using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkWrapper.Entities
{
    public class Entity1
    {
        public long EntityId { get; set; }
        public string Name { get; set; }

        List<Entity2> Entity2Entities { get; set; }
    }
}
