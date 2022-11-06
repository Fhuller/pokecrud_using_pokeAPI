using BetterConsoleTables;
using pokecrud.Entities;
using RestSharp;
using RestSharp.Deserializers;

namespace pokecrud
{
    static class Program
    {
        static void Main(string[] args)
        {
            
            List<Pokemon> pokemons = new List<Pokemon>();
            Tela tela = new Tela();

            pokemons = GetPokemons();

            Table table = new Table("ID", "Espécie", "Nome", "Tipo", "Experiência");
            table.Config = TableConfiguration.Unicode();

            Console.WriteLine("POKEMON ESCRITO GRANDÃO");
            Console.WriteLine();
            tela.Wait();

            bool rodando = true;

            while (rodando)
            {
                tela.MostrarEscolhas();

                var a = int.TryParse(Console.ReadLine(), out int choice);

                switch (choice)
                {
                    case 0:
                        rodando = false;
                        break;
                    case 1:
                        ShowAllPokemon(pokemons, table);
                        tela.Wait();
                        break;
                    case 2:
                        pokemons = EditPokemon(pokemons);
                        Console.WriteLine("Pokemon Editado com sucesso!");
                        tela.Wait();
                        break;
                    case 3:
                        pokemons.Add(CreatePokemon(pokemons));
                        Console.WriteLine("Pokemon criado com sucesso!");
                        tela.Wait();
                        break;
                    case 4:
                        pokemons = ExcluirPokemon(pokemons);
                        tela.Wait();
                        break;
                    default:
                        tela.Wait();
                        break;
                }
            }
        }

        public static string FirstLetterToUpper(string str)
        {
            if (str == null)
                return null;

            if (str.Length > 1)
                return char.ToUpper(str[0]) + str.Substring(1);

            return str.ToUpper();
        }

        public static Pokemon CreatePokemon(List<Pokemon> pokemons)
        {
            int x;
            Console.Clear();

            Console.Write("Digite a Espécie: ");
            string especie = Console.ReadLine();

            Species species = new Species(especie);

            Console.Write("Digite o Nome: ");
            string name = Console.ReadLine();

            Console.Write("Digite a quantidade de Tipos: ");
            int i = int.Parse(Console.ReadLine());

            List<Types> tipos = new List<Types>();

            for (x=1; x<=i; x++)
            {
                Console.Write($"Digite o Tipo #{x}: ");
                Entities.Type type = new Entities.Type(Console.ReadLine());
                Types tipo = new Types(x-1, type);

                tipos.Add(tipo);
            }

            Pokemon pokemon = new Pokemon(pokemons.Count, species, name, tipos);

            return pokemon;
        }

        public static List<Pokemon> EditPokemon(List<Pokemon> pokemons)
        {
            Console.Clear();
            Console.Write("Digite o ID do pokemon que deseja editar: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Digite o novo nome do pokemon: ");
            string name = Console.ReadLine();

            Console.Write("Digite a nova quantidade de Experiência: ");
            int exp = int.Parse(Console.ReadLine());

            Species species = pokemons.Find(pokemon => pokemon.id == id).species;
            List<Types> types = pokemons.Find(pokemon => pokemon.id == id).types;

            //Console.WriteLine($"ID: {id}, Especie: {species}, Nome: {name}, Tipo: {types.ToString()}, Experiencia: {exp}");

            Pokemon pokemon = new Pokemon(id, species, name, types, exp);

            List<Pokemon> pokemonList = DelPokemon(pokemons, id);

            pokemonList.Add(pokemon);

            return pokemonList;
        }

        public static List<Pokemon> ExcluirPokemon(List<Pokemon> pokemons)
        {
            Console.Clear();
            Console.Write("Digite o Id do pokemon que deseja exculir: ");
            int id = int.Parse(Console.ReadLine());

            List<Pokemon> pokemonList = DelPokemon(pokemons, id);

            return pokemonList;
        }

        public static List<Pokemon> DelPokemon(List<Pokemon> pokemons, int id)
        {
            List<Pokemon> pokemonList = pokemons.Where(pokemon => pokemon.id != id).ToList();

            return pokemonList;
        }

        public static void ShowAllPokemon(List<Pokemon> pokemons, Table table)
        {
            Console.Clear();

            foreach (Pokemon pokemon in pokemons)
            {
                table.AddRow(pokemon.id, FirstLetterToUpper(pokemon.species.name), FirstLetterToUpper(pokemon.name), pokemon.mostraTipo(), pokemon.base_experience);
            }
            Console.Write(table.ToString());

        }

        public static List<Pokemon> GetPokemons()
        {

            List<Pokemon> pokemons = new List<Pokemon>();

            RestClient client = new RestClient("https://pokeapi.co/api/v2/pokemon?limit=25");
            RestRequest request = new RestRequest(Method.GET);

            IRestResponse response = client.Execute(request);

            ApiResults results = new JsonDeserializer().Deserialize<ApiResults>(response);

            foreach (PokeURL pokeURL in results.results)
            {
                RestClient pokeApi = new RestClient(pokeURL.url);
                RestRequest pokeRequest = new RestRequest(Method.GET);

                IRestResponse pokeJson = pokeApi.Execute(pokeRequest);

                Pokemon pokemon = new JsonDeserializer().Deserialize<Pokemon>(pokeJson);

                pokemons.Add(pokemon);
            }

            return pokemons;
        }
    }
}