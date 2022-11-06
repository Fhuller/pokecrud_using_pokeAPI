using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokecrud.Entities
{
    public class ApiResults
    {
        public int count { get; set; }
        public string next { get; set; }
        public string previous { get; set; }
        public List<PokeURL> results { get; set; }

    }
}
