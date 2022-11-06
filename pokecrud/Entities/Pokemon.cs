using System.Text;

namespace pokecrud.Entities
{
    public class Pokemon
    {

        public int id { get; set; }
        public Species species { get; set; }
        public string name { get; set; }
        public List<Types> types { get; set; }
        public int base_experience { get; set; }

        public Pokemon(int id, Species species, string name, List<Types> types)
        {
            this.id = id + 1;
            this.species = species;
            this.name = name;
            this.types = types;
            this.base_experience = 0;
        }

        public Pokemon(int id, Species species, string name, List<Types> types, int exp)
        {
            this.id = id + 1;
            this.species = species;
            this.name = name;
            this.types = types;
            this.base_experience = exp;
        }

        public Pokemon()
        {
        }

        public string mostraTipo()
        {
            StringBuilder sb = new StringBuilder();

            foreach (Types tipo in types)
            {
                sb.Append($"{tipo.type.name} ");
            }

            return sb.ToString();
        }

    }
}
