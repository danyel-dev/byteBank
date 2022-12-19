using System;
using System.Diagnostics.Tracing;

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
            Console.WriteLine(" 6 - Editar conta");
            Console.WriteLine(" 7 - Manipular conta");
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

        static void listAllCounts(List<string> cpfs, List<string> titulares, List<double> saldos, List<string> senhas)
        {
            for(int i = 0; i < cpfs.Count; i++)
            {
                Console.WriteLine($"Conta {i + 1}");
                Console.WriteLine($"Nome do titular do cartão: {titulares[i]}");
                Console.WriteLine($"CPF do titular do cartão: {cpfs[i]}");
                Console.WriteLine($"Senha do titular do cartão: {senhas[i]}");
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

        static void updateAccount(List<string> cpfs, List<string> titulares, List<string> senhas)
        {
            Console.Write("Informe o CPF do titular da conta: ");
            string cpfTitular = Console.ReadLine();

            int cpfIndex = cpfs.IndexOf(cpfTitular);

            Console.WriteLine();

            if(cpfIndex != -1) {
                int option;

                do {
                    Console.WriteLine(" 1 - Alterar nome\n 2 - Alterar senha\n 0 - Voltar ao menu principal");
                    Console.Write("\n Informe uma das opções acima: ");

                    option = int.Parse(Console.ReadLine());

                    switch (option) {
                        case 1:
                            updateName(titulares, cpfIndex);
                            break;
                        case 2:
                            updatePassword(senhas, cpfIndex);
                            break;
                    }
                } while(option != 0);

                Console.Clear();
            }
            else {
                Console.Clear();
                Console.WriteLine("Número de CPF não encontrado!\n");
            }
        }
        static void updateName(List<string> titulares, int cpfIndex)
        {
            Console.Clear();
            Console.Write("Informe o novo nome: ");
            string newHolder = Console.ReadLine();

            titulares[cpfIndex] = newHolder;

            Console.WriteLine("\nNome Alterado com sucesso!!\n");
        }

        static void updatePassword(List<string> senhas, int cpfIndex)
        {
            Console.Clear();
            Console.Write("Informe a nova senha: ");
            string newPassword = Console.ReadLine();

            senhas[cpfIndex] = newPassword;
            Console.WriteLine("\nSenha Alterada com sucesso!!\n");
        }

        static void sacar(List<double> saldos, int cpfIndex)
        {
            Console.Write("Informe o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());

            if(valorSaque > saldos[cpfIndex])
            {
                Console.WriteLine("Saldo insuficiente!");
            } else
            {
                saldos[cpfIndex] -= valorSaque;
                Console.WriteLine("Saque efetuada com sucesso!");
            }
        }

        static void manipulateAccount(List<string> cpfs, List<double> saldos)
        {
            Console.Write("Informe o CPF do titular da conta: ");
            string cpfTitular = Console.ReadLine();

            int cpfIndex = cpfs.IndexOf(cpfTitular);

            if (cpfIndex != -1)
            {
                int option;

                do
                {
                    Console.WriteLine();

                    Console.WriteLine(" 1 - Sacar");
                    Console.WriteLine(" 2 - Depositar");
                    Console.WriteLine(" 3 - Transferir");
                    Console.WriteLine(" 0 - Sair");
                    Console.Write("\n Informe a opção desejada: ");

                    option = int.Parse(Console.ReadLine());

                    switch (option)
                    {
                        case 1:
                            Console.Clear();
                            sacar(saldos, cpfIndex);
                            break;
                        case 2:
                            Console.WriteLine("Depositar");
                            break;
                        case 3:
                            Console.WriteLine("Transferir");
                            break;
                    }

                } while (option != 0);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("\nNúmero de CPF não encontrado!\n");
            }
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
                        listAllCounts(cpfs, titulares, saldos, senhas);
                        break;
                    case 4:
                        detailUser(cpfs, titulares, saldos);
                        break;
                    case 5:
                        valueInBank(saldos);
                        break;
                    case 6:
                        updateAccount(cpfs, titulares, senhas);
                        break;
                    case 7:
                        manipulateAccount(cpfs, saldos);
                        break;
                    default:
                        Console.WriteLine("Opção inválida\n");
                        break;
                }
            } while(option != 0);
        }
    }
}
