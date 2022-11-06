using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokecrud.Entities
{
    public class Species
    {
        public string name { get; set; }
        public string url { get; set; }

        public Species(string name)
        {
            this.name = name;
        }

        public Species()
        {
        }
    }
}
