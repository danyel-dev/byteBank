
public class Bank
{
    public static List<Account> AccountList { get; private set; }
    public int AccountIndex { get; set; }
    public List<string> Historic { get; private set; }

    public Bank()
    {
        AccountList = new List<Account>();
        Historic = new List<string>();
        AccountIndex = -1;
    }

    public static void AddAccount(Account account)
    {
        AccountList.Add(account);
    }

    public static int FindIndexAccount(string cpf)
    {
        return AccountList.FindIndex(account => account.User.CPF == cpf);
    }

    public bool Deposit(double value)
    {
        AccountList[AccountIndex].Balance += value;

        AccountList[AccountIndex].AddTransaction($"Depósito no valor de R${value:F2}.");
        return true;
    }

    public bool ToWithdraw(double value)
    {
        if (!(AccountList[AccountIndex].Balance >= value))
            return false;

        AccountList[AccountIndex].Balance -= value;

        AccountList[AccountIndex].AddTransaction($"Saque no valor de R${value:F2}");
        return true;
    }

    public bool Transfer(double value, int recipientIndex)
    {
        if (ToWithdraw(value))
        {
            AccountList[recipientIndex].Balance += value;

            AccountList[AccountIndex].AddTransaction($"Transferência no valor de R${value:F2} para o usuário {AccountList[recipientIndex].User.Name}.");
            AccountList[recipientIndex].AddTransaction($"Transferência no valor de R${value:F2} recebida do usuário {AccountList[recipientIndex].User.Name}.");
            return true;
        }

        return false;
    }
}
