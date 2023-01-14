
public class Bank
{
    public static List<Account> AccountList { get; private set; }

    public int AccountIndex { get; set; }

    public Bank()
    {
        AccountList = new List<Account>();
        AccountIndex = -1;
    }

    public static void AddAccount(Account account)
    {
        AccountList.Add(account);
    }

    public bool Deposit(double value)
    {
        if (AccountIndex == -1)
            return false;

        AccountList[AccountIndex].Balance += value;
        return true;
    }

    public static int FindIndexAccount(string cpf)
    {
        return AccountList.FindIndex(account => account.User.CPF == cpf);
    }
}
