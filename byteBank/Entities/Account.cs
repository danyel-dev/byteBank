
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

    public void AddTransaction(string transaction)
    {
        Historic.Add(transaction);
    }

    public void showTransactions()
    {
        Historic.ForEach(historic => Console.WriteLine(historic));
    }
}
