using System;


namespace byteBank
{
    class Program
    {
        static void showMenu()
        {
            Console.WriteLine("-------------------------------");
            Console.WriteLine(" 1 - Inserir um novo usuário");
            Console.WriteLine(" 2 - Deletar um usuário");
            Console.WriteLine(" 3 - Listar todas as contas registradas");
            Console.WriteLine(" 4 - Detalhes de um usuário");
            Console.WriteLine(" 5 - Quantia armazenada no banco");
            Console.WriteLine(" 6 - Manipular a conta");
            Console.WriteLine(" 0 - Sair do programa");
            Console.WriteLine();
            Console.Write(" Digite a opção desejada: ");
            Console.WriteLine();
            Console.WriteLine("-------------------------------");
        }

        static void Main(string[] args)
        {
            showMenu();
        }
    }
}