
public class Account
{
    public readonly User User;
    public double Balance { get; set; }
    public List<string> Historic { get; private set; }

    public Account(User user)
    {
        User = user;
        Balance = 0;
        Historic = new List<string>();
    }

    public void InfoAccount()
    {
        Console.WriteLine($" Nome completo: {User.Name}");
        Console.WriteLine($" Nome de usuário: {User.Username}");
        Console.WriteLine($" Email: {User.Email}");
        Console.WriteLine($" CPF: {User.CPF}");
        Console.WriteLine($" Data de nascimento: {User.BirthDate}");
        Console.WriteLine($" Senha: {User.Password}");
    }

    public bool Deposit(double value)
    {
        Balance += value;

        AddTransaction($"Depósito no valor de R$ {value:F2} realizado.");
        return true;
    }

    public bool ToWithdraw(double value)
    {
        if (!(Balance >= value))
            return false;

        Balance -= value;

        AddTransaction($"Saque no valor de R$ {value:F2} realizado.");
        return true;
    }

    public bool Transfer(double value, Account recipientAccount)
    {
        if (Balance >= value)
        {
            Balance -= value;
            AddTransaction($"Transferência no valor de R$ {value:F2} realizado para o usuário {recipientAccount.User.Name}.");

            recipientAccount.Balance += value;
            recipientAccount.AddTransaction($"Transferência no valor de R$ {value:F2} recebida do usuário {User.Name}.");
            
            return true;
        }

        return false;
    }

    public void AddTransaction(string transaction)
    {
        Historic.Add(transaction);
    }

    public void ShowTransactions()
    {
        Historic.ForEach(historic => {
            Console.WriteLine($" {historic}");
        });

        Console.Write("\n Digite qualquer tecla para voltar ao menu... ");
        Console.ReadLine();
    }
}
