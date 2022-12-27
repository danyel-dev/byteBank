using System;
using System.Diagnostics.Tracing;
using System.Security.Cryptography;

namespace byteBank
{
    class Program
    {
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

        static bool sacar(List<double> saldos, int cpfIndex, double valorSaque)
        {
            if (valorSaque < saldos[cpfIndex]) {
                saldos[cpfIndex] -= valorSaque;
                return true;
            }
            
            return false;
        }

        static bool depositar(List<double> saldos, int cpfIndex, double valorDeposito)
        {
            saldos[cpfIndex] += valorDeposito;
            return true;
        }

        static void transferencia(List<double> saldos, List<string> cpfs, int indexCpfOrigem)
        {
            Console.Write("Informe o valor da transferência: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            Console.Write("Agora informe o CPF de destino: ");
            string cpfDestino = Console.ReadLine();

            int indexCpfDestino = cpfs.IndexOf(cpfDestino);

            if (indexCpfDestino != -1)
            {
                if (sacar(saldos, indexCpfOrigem, valorTransferencia)) {
                    depositar(saldos, indexCpfDestino, valorTransferencia);
                    Console.WriteLine("\nTransferência efetuada com sucesso!");
                }
                else 
                    Console.WriteLine("\nSaldo insuficiente para transferir!");
            } 
            else
            {
                Console.WriteLine("\nCPF de destino não encontrado!!");
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

                            Console.Write("Informe o valor a ser sacado: ");
                            double valorSaque = double.Parse(Console.ReadLine());
                            
                            if(sacar(saldos, cpfIndex, valorSaque))
                                Console.WriteLine("\nSaque efetuado com sucesso!");
                            else
                                Console.WriteLine("\nSaldo insuficiente!");
                            
                            break;
                        case 2:
                            Console.Clear();
                            Console.Write("Informe o valor do depósito: ");
                            double valorDeposito = double.Parse(Console.ReadLine());

                            depositar(saldos, cpfIndex, valorDeposito);
                            Console.WriteLine("\nDepósito efetuado com sucesso!");

                            break;
                        case 3:
                            Console.Clear();
                            transferencia(saldos, cpfs, cpfIndex);
                            break;
                    }

                } while (option != 0);

                Console.Clear();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("\nNúmero de CPF não encontrado!\n");
            }
        }





























        static void showMenu()
        {
            Console.WriteLine("-------------------------------");
            Console.WriteLine(" 1 - Detalhes da conta");
            Console.WriteLine(" 2 - Ver Saldo");
            Console.WriteLine(" 3 - Editar conta");
            Console.WriteLine(" 4 - Manipular conta");
            Console.WriteLine(" 0 - Logout");
            Console.WriteLine();
            Console.Write(" Digite a opção desejada: ");
        }

        static int login(List<string> cpfs, List<string> senhas)
        {
            Console.Write("Informe o seu CPF: ");
            string cpf_user = Console.ReadLine();

            Console.Write("Agora nos informe sua senha: ");
            string password_user = Console.ReadLine();
            
            if(cpfs.Contains(cpf_user) && senhas.Contains(password_user))
                return cpfs.IndexOf(cpf_user);
            
            return -1;
        }

        static int createAccount(List<string> cpfs, List<string> titulares, List<string> senhas, List<double> saldos)
        {
            Console.Write("Informe o seu CPF: ");
            string cpf = Console.ReadLine();

            if (!cpfs.Contains(cpf))
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
                return cpfs.IndexOf(cpf);
            }

            Console.Clear();
            Console.WriteLine("\nEste CPF já está registrado!!\n");
            return -1;
        }

        static void detailUser(List<string> cpfs, List<string> titulares, List<double> saldos, int indexCPFLogado)
        {
                Console.WriteLine();
                Console.WriteLine("--------------------------------");
                Console.WriteLine($"Nome do titular do cartão: {titulares[indexCPFLogado]}");
                Console.WriteLine($"CPF do titular do cartão: {cpfs[indexCPFLogado]}");
                Console.WriteLine($"Saldo em conta: {saldos[indexCPFLogado]}");

                Console.Write("\nPressione enter para voltar ao menu...");
                Console.ReadLine();
                Console.Clear();

        }

        static void Main(string[] args)
        {
            int optionWelcome;

            int indexCpfLogado;

            List<string> cpfs = new();
            List<string> titulares = new();
            List<string> senhas = new();
            List<double> saldos = new();

            Console.WriteLine("Olá, Bem vindo ao byteBank\n");
            
            while (true)
            {
                Console.WriteLine("1 - Logar\n2 - Criar conta\n");
                Console.Write("Informe um opção: ");
                
                optionWelcome = int.Parse(Console.ReadLine());

                if (optionWelcome != 1 && optionWelcome != 2)
                {
                    Console.Clear();
                    Console.WriteLine("Opção não encontrada, por favor digite uma opção válida!\n");
                }

                if(optionWelcome == 1)
                {
                    Console.Clear();
                    indexCpfLogado = login(cpfs, senhas);

                    Console.WriteLine();

                    if(indexCpfLogado != -1) 
                    {
                        Console.Clear();
                        Console.WriteLine($"Olá {titulares[indexCpfLogado]}, seja bem vindo!\n");
                        break;
                    }

                    Console.WriteLine("CPF ou senha incorretos!\n");
                }

                if(optionWelcome == 2)
                {
                    Console.Clear();
                    indexCpfLogado = createAccount(cpfs, titulares, senhas, saldos);
                    break;
                }
            }

            int option;

            do
            {
                showMenu();
                option = int.Parse(Console.ReadLine());

                Console.Clear();

                switch (option)
                {
                    case 0:
                        Console.WriteLine("Saindo da conta, Bye Bye!!");
                        break;
                    case 1:
                        detailUser(cpfs, titulares, saldos, indexCpfLogado);
                        break;
                    case 2:
                        deleteUser(cpfs, titulares, senhas, saldos);
                        break;
                    case 3:
                        listAllCounts(cpfs, titulares, saldos, senhas);
                        break;
                    case 4:
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
            } while (option != 0);
        }
    }
}
