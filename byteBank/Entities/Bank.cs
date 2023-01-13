
public class Bank
{
    public static List<Account>? AccountList { get; private set; }

    private Account? _ActiveAccount;

    public Bank()
    {
        AccountList = new List<Account>();
    }

    public static void AddAccount(Account account)
    {
        AccountList.Add(account);
    }

    public Account? ActiveAccount
    {
        get { return _ActiveAccount; }
        set { _ActiveAccount = value; }
    }

    public static Account? FindAccount(string cpf)
    {
        Account account = AccountList.Find(account => account.User.CPF == cpf);

        if (account != null)
            return account;

        return null;
    }
}
