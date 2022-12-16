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
           
        }

        static void insertUser(List<string> cpfs, List<string> titulares, List<string> senhas, List<double> saldos)
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

                Console.Write("Para terminar, cadastre uma senha forte: ");
                senhas.Add(Console.ReadLine());
                saldos.Add(0);

                Console.Clear();
                Console.WriteLine("\nUsuário cadastrado com sucesso!!\n");
            } 
            else
            {
                Console.Clear();
                Console.WriteLine("\nEste CPF já está registrado!!\n");
            }
        }

        static void deleteUser(List<string> cpfs, List<string> titulares, List<string> senhas, List<double> saldos)
        {
            Console.WriteLine();

            Console.Write("Informe o CPF para deletar: ");
            string cpf = Console.ReadLine();

            if (!cpfs.Contains(cpf))
            {
                Console.Clear();
                Console.WriteLine("Esse CPF não está cadastrado!!\n");
            }
            else
            {
                var index = cpfs.FindIndex(item_cpf => item_cpf == cpf);

                cpfs.RemoveAt(index);
                titulares.RemoveAt(index);
                senhas.RemoveAt(index);
                saldos.RemoveAt(index);

                Console.Clear();
                Console.WriteLine("Conta deletada com sucesso!!\n");
            }
        }

        static void listAllCounts(List<string> cpfs, List<string> titulares, List<string> senhas, List<double> saldos)
        {
            for(int i = 0; i < cpfs.Count; i++)
            {
                Console.WriteLine($"Conta {i + 1}");
                Console.WriteLine($"Nome do titular do cartão: {titulares[i]}");
                Console.WriteLine($"CPF do titular do cartão: {cpfs[i]}");
                Console.WriteLine($"Saldo em conta: {saldos[i]}");
                Console.WriteLine("--------------------------------------");
            }

            Console.Write("\nPressione enter para voltar ao menu...");
            Console.ReadLine();
            Console.Clear();
        }

        static void detailUser(List<string> cpfs, List<string> titulares, List<double> saldos) 
        {
            Console.Write("Informe o cpf do usuário: ");
            string cpf = Console.ReadLine();

            if (cpfs.Contains(cpf))
            {
                var index = cpfs.FindIndex(item_cpf => item_cpf == cpf);

                Console.WriteLine();
                Console.WriteLine("--------------------------------");
                Console.WriteLine($"Nome do titular do cartão: {titulares[index]}");
                Console.WriteLine($"CPF do titular do cartão: {cpfs[index]}");
                Console.WriteLine($"Saldo em conta: {saldos[index]}");

                Console.Write("\nPressione enter para voltar ao menu...");
                Console.ReadLine();
                Console.Clear();
            } 
            else
            {
                Console.Clear();
                Console.WriteLine("Número de CPF não encontrado!\n");
            }

        }

        static void valueInBank(List<double> saldos) 
        {
            Console.WriteLine($"Quantia total armazenada no banco: {saldos.Sum(saldo => saldo)}");
            Console.Write("\nPressione enter para voltar ao menu...");
            Console.ReadLine();
            Console.Clear();
        }

        static void Main(string[] args)
        {
            int option;

            List<string> cpfs = new();
            List<string> titulares = new();
            List<string> senhas = new();
            List<double> saldos = new();

            do {
                showMenu();
                option = int.Parse(Console.ReadLine());

                Console.Clear();

                switch(option)
                {
                    case 0:
                        Console.WriteLine("Obrigado por utilizar este programa, Bye Bye!!");
                        break;
                    case 1:
                        insertUser(cpfs, titulares, senhas, saldos);
                        break;
                    case 2:
                        deleteUser(cpfs, titulares, senhas, saldos);
                        break;
                    case 3:
                        listAllCounts(cpfs, titulares, senhas, saldos);
                        break;
                    case 4:
                        detailUser(cpfs, titulares, saldos);
                        break;
                    case 5:
                        valueInBank(saldos);
                        Console.WriteLine("Opção 05");
                        break;
                    case 6:
                        Console.WriteLine("Opção 06");
                        break;
                    default:
                        Console.WriteLine("Opção inválida\n");
                        break;
                }
            } while(option != 0);
        }
    }
}
