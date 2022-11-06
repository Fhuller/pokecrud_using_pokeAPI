namespace pokecrud.Entities
{
    public class Type
    {

        public string name { get; set; }
        public string url { get; set; }

        public Type(string name)
        {
            this.name = name;
        }

        public Type()
        {
        }
    }
}
