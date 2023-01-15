
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
                if (bank.AccountIndex == -1)
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

                                    bank.AccountIndex = Bank.FindIndexAccount(cpf);

                                    if (bank.AccountIndex != -1 || cpf == "0")
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
                        int optionMenuAccount = Menus.MenuAccount(Bank.AccountList[bank.AccountIndex].User.Name, Bank.AccountList[bank.AccountIndex].Balance);

                        switch (optionMenuAccount)
                        {
                            case 1:
                                Bank.AccountList[bank.AccountIndex].InfoAccount();
                                Console.Write("\n Aperte qualquer tecla para voltar ao menu anterior... ");
                                Console.ReadLine();
                                Console.Clear();
                                break;
                            case 2:
                                Console.Write(" Informe o valor que deseja depositar: ");
                                double valueDeposit = double.Parse(Console.ReadLine());

                                Console.Clear();

                                if (Bank.AccountList[bank.AccountIndex].Deposit(valueDeposit))
                                    Messages.MessageSuccess("Depósito efetuado com sucesso.");
                                else
                                    Messages.MessageError("Depósito não efetuado.");

                                break;
                            case 3:
                                Console.Write(" Informe o valor que deseja sacar: ");
                                double valueToWithdraw = double.Parse(Console.ReadLine());

                                Console.Clear();

                                if (Bank.AccountList[bank.AccountIndex].ToWithdraw(valueToWithdraw))
                                    Messages.MessageSuccess("Saque efetuado com sucesso.");
                                else
                                    Messages.MessageError("Saque não efetuado, saldo insuficiente");

                                break;
                            case 4:
                                Console.Write(" Informe o CPF do destinatário: ");
                                string recipientCPF = Console.ReadLine();

                                int recipientIndex = Bank.FindIndexAccount(recipientCPF);

                                if(recipientIndex != -1)
                                {
                                    Console.Write(" Informe o valor que deseja transferir: ");
                                    double transferAmount = double.Parse(Console.ReadLine());

                                    Console.Clear();

                                    if (Bank.AccountList[bank.AccountIndex].Transfer(transferAmount, Bank.AccountList[recipientIndex]))
                                        Messages.MessageSuccess("Transferência efetuada com sucesso!");
                                    else
                                        Messages.MessageError("Saldo insuficiente para transferir");
                                } else
                                {
                                    Console.Clear();
                                    Messages.MessageError("CPF do destinatário não encontrado.");
                                }

                                break;
                            case 5:
                                Bank.AccountList[bank.AccountIndex].ShowTransactions();
                                Console.Clear();

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

                    bank.AccountIndex = -1;
                }
            }
        }
    }
}
