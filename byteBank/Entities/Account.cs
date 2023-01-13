
public class Account
{
    public readonly User User;
    public readonly double Balance;

    public Account(User user)
    {
        User = user;
        Balance = 0;
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
}
