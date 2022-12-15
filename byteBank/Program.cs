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
            int option;

            do {
                showMenu();
                option = int.Parse(Console.ReadLine());  

                switch(option)
                {
                    case 0:
                        Console.WriteLine("Obrigado por utilizar esse programa");
                        break;
                    case 1:
                        Console.WriteLine("Opção 01");
                        break;
                    case 2:
                        Console.WriteLine("Opção 02");
                        break;
                    case 3:
                        Console.WriteLine("Opção 03");
                        break;
                    case 4:
                        Console.WriteLine("Opção 04");
                        break;
                    case 5:
                        Console.WriteLine("Opção 05");
                        break;
                    case 6:
                        Console.WriteLine("Opção 06");
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
            } while(option != 0);
        }
    }
}