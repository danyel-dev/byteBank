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

        static void insertUser(List<string> cpfs, List<string> titulares, List<string> senhas, List<string> saldos)
        {
            Console.WriteLine();

            Console.Write("Informe o seu CPF: ");
            string cpf = Console.ReadLine();

            if(!cpfs.Contains(cpf))
            {
                cpfs.Add(cpf);
                Console.WriteLine();

                Console.Write("Agora, nós informe o nome do titular: ");
                titulares.Add(Console.ReadLine());

                Console.WriteLine();

                Console.Write("Para terminar, nos informe uma senha forte: ");
                senhas.Add(Console.ReadLine());

                Console.Write("\nUsuário cadastrado com sucesso!!");
            } 
            else
            {
                Console.WriteLine("\nEste CPF já está registrado!!");
            }
        }

        static void detailUser(List<string> cpfs, List<string> titulares, List<string> senhas, List<string> saldos) 
        {
            Console.WriteLine("Informe o cpf do usuário: ");
            string cpf = Console.ReadLine();

            if (cpfs.Contains(cpf))
            {
                string elemento = cpfs.Find(item => item == cpf);

                Console.WriteLine(elemento);
            } 
            else
            {
                Console.WriteLine("Número de CPF não encontrado!");
            }
        }

        static void Main(string[] args)
        {
            int option;

            List<string> cpfs = new();
            List<string> titulares = new();
            List<string> senhas = new();
            List<string> saldos = new();

            do {
                showMenu();
                option = int.Parse(Console.ReadLine());  

                switch(option)
                {
                    case 0:
                        Console.WriteLine("Obrigado por utilizar o programa, Bye Bye!!");
                        break;
                    case 1:
                        insertUser(cpfs, titulares, senhas, saldos);
                        break;
                    case 2:
                        Console.WriteLine("Opção 02");
                        break;
                    case 3:
                        Console.WriteLine("Opção 03");
                        break;
                    case 4:
                        detailUser(cpfs, titulares, senhas, saldos);
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