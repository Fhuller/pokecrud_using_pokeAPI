using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokecrud.Entities
{
    public class Tela
    {

        public Tela()
        {

        }

        public void MostrarEscolhas()
        {
            Console.Clear();
            Console.WriteLine("1 - Mostra todos os pokemons criados!");
            Console.WriteLine("2 - Seleciona um pokemon para editar!");
            Console.WriteLine("3 - Mostra tela de criação de pokemon!");
            Console.WriteLine("4 - Excluir pokemon!");
            Console.WriteLine("0 - Fecha o programa!");
            Console.WriteLine();
            Console.Write("Digite sua opção: ");

        }

        public void Wait()
        {
            Console.WriteLine();
            Console.WriteLine("Aperte enter para continuar");
            Console.ReadLine();
        }

    }
}
