
public class Account
{
    public readonly User User;
    public readonly double Balance;

    public Account(User user)
    {
        User = user;
        Balance = 0;
    }
}
