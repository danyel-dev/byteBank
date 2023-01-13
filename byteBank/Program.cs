
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
                        optionMenuInitial = Menus.MenuInitial();

                        switch (optionMenuInitial)
                        {
                            case 0:
                                Console.WriteLine(" Saindo do programa...");
                                flag = true;

                                break;
                            case 1:
                                Console.WriteLine(" Olá, seja bem-vindo. para criar uma conta, nos informe seus dados corretamente^^\n");

                                Console.Write(" Nome completo: ");
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
                                        Messages.MessageError("CPF não encontrado! Informe - o corretamente.");
                                    }
                                }

                                Console.Clear();
                                break;
                            default:
                                Messages.MessageError("Opção não encontrada!");
                                break;
                        }
                    } while (optionMenuInitial != 0);
                }
                else
                {
                    bool flagMenuAccount = false;

                    while (true)
                    {
                        int optionMenuAccount = Menus.MenuAccount(bank.ActiveAccount.User.Name, bank.ActiveAccount.Balance);

                        switch (optionMenuAccount)
                        {
                            case 1:
                                bank.ActiveAccount.InfoAccount();
                                Console.Write("\n Aperte qualquer tecla para voltar ao menu anterior... ");
                                Console.ReadLine();
                                Console.Clear();
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
                                Messages.MessageError("Opção incorreta! informe um número válido.");
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
