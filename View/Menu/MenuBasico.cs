using System;

namespace DIO.Series.View.Menu
{
    public class MenuBasico
    {
        public string ObterOpcaoUsuario()
        {
            GeraMenu();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

        private void GeraMenu()
        {
            Console.WriteLine();
            Console.WriteLine("APP cadastro de filmes a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar séries");
            Console.WriteLine("2- Inserir nova série");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Excluir série");
            Console.WriteLine("5- Visualizar série");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();
        }
    }
}