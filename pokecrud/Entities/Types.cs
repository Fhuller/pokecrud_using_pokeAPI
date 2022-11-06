using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokecrud.Entities
{
    public class Types
    {
        public int slot { get; set; }
        public Type type { get; set; }

        public Types(int slot, Type type)
        {
            this.slot = slot;
            this.type = type;
        }

        public Types()
        {
        }
    }
}
