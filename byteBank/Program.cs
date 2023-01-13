
namespace byteBank
{
    class Program
    {
        static void Main()
        {
            Bank bank = new();
            bool flag = false;

            while (flag == false)
            {
                if (bank.ActiveAccount == null)
                {
                    int optionMenuInitial;

                    do
                    {
                        Console.WriteLine(" 1 - Criar conta");
                        Console.WriteLine(" 2 - Logar");
                        Console.WriteLine(" 0 - Sair do programa\n");
                        Console.Write(" Informe uma das opções acima: ");

                        optionMenuInitial = int.Parse(Console.ReadLine());

                        Console.Clear();

                        switch (optionMenuInitial)
                        {
                            case 0:
                                Console.WriteLine(" Saindo do programa...");
                                flag = true;

                                break;
                            case 1:
                                Console.WriteLine(" Olá, seja bem-vindo. para criar uma conta, nos informe seus dados corretamente^^\n");

                                Console.Write(" Nome: ");
                                string name = Console.ReadLine();

                                Console.Write(" Nome de usuário: ");
                                string username = Console.ReadLine();

                                Console.Write(" Data de nascimento: ");
                                string birthDate = Console.ReadLine();

                                Console.Write(" CPF: ");
                                string cpf = Console.ReadLine();

                                Console.Write(" Email: ");
                                string email = Console.ReadLine();

                                Console.Write(" Senha: ");
                                string password = Console.ReadLine();

                                Console.Write(" Confirmar senha: ");
                                string passwordConfirm = Console.ReadLine();

                                User user = new(name, username, cpf, birthDate, email, password, passwordConfirm);

                                Account account = new Account(user);
                                Bank.AddAccount(account);

                                Console.Clear();
                                break;
                            case 2:
                                while (true)
                                {
                                    Console.Write(" Digite seu CPF (Ou 0 para voltar ao menu anterior): ");

                                    cpf = Console.ReadLine();

                                    bank.ActiveAccount = Bank.FindAccount(cpf);

                                    if (bank.ActiveAccount != null || cpf == "0")
                                    {
                                        optionMenuInitial = 0;
                                        break;
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine(" CPF não encontrado! Informe-o corretamente.\n");
                                        Console.ResetColor();
                                    }
                                }

                                Console.Clear();
                                break;
                            default:
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(" Opção não encontrada!\n");
                                Console.ResetColor();

                                break;
                        }
                    } while (optionMenuInitial != 0);
                }
                else
                {
                    bool flagMenuAccount = false;

                    while (true)
                    {
                        Console.WriteLine($" Olá {bank.ActiveAccount.User.Name}!");
                        Console.WriteLine($" Saldo em conta: R$ {bank.ActiveAccount.Balance:F2}\n");

                        Console.WriteLine(" [1] - Informações da conta");
                        Console.WriteLine(" [2] - Sacar");
                        Console.WriteLine(" [3] - Depositar");
                        Console.WriteLine(" [4] - Transferir");
                        Console.WriteLine(" [5] - Histórico de transações");
                        Console.WriteLine(" [6] - Editar conta");
                        Console.WriteLine(" [7] - Deletar conta");
                        Console.WriteLine(" [0] - Logout\n");

                        Console.Write(" Selecione a opção desejada: ");
                        int optionMenuAccount = int.Parse(Console.ReadLine());

                        Console.Clear();

                        switch (optionMenuAccount)
                        {
                            case 1:
                                Console.WriteLine(" Opção 01 digitada\n");
                                break;
                            case 2:
                                Console.WriteLine(" Opção 02 digitada\n");
                                break;
                            case 3:
                                Console.WriteLine(" Opção 03 digitada\n");
                                break;
                            case 4:
                                Console.WriteLine(" Opção 04 digitada\n");
                                break;
                            case 5:
                                Console.WriteLine(" Opção 05 digitada\n");
                                break;
                            case 6:
                                Console.WriteLine(" Opção 06 digitada\n");
                                break;
                            case 7:
                                Console.WriteLine(" Opção 07 digitada\n");
                                break;
                            case 0:
                                flagMenuAccount = true;
                                break;
                            default:
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(" Opção incorreta! informe um número válido.\n");
                                Console.ResetColor();
                                break;
                        }

                        if (flagMenuAccount)
                            break;
                    }

                    bank.ActiveAccount = null;
                }
            }
        }
    }
}
