public class Menus
{
    public static int MenuInitial()
    {
        Console.WriteLine(" 1 - Criar conta");
        Console.WriteLine(" 2 - Logar");
        Console.WriteLine(" 0 - Sair do programa\n");
        Console.Write(" Informe uma das opções acima: ");

        int optionMenuInitial = int.Parse(Console.ReadLine());

        Console.Clear();

        return optionMenuInitial;
    }

    public static int MenuAccount(string name, double balance)
    {
        Console.WriteLine($" Olá {name}!");
        Console.WriteLine($" Saldo em conta: R$ {balance:F2}\n");

        Console.WriteLine(" [1] - Informações da conta");
        Console.WriteLine(" [2] - Depositar");
        Console.WriteLine(" [3] - Sacar");
        Console.WriteLine(" [4] - Transferir");
        Console.WriteLine(" [5] - Histórico de transações");
        Console.WriteLine(" [6] - Editar conta");
        Console.WriteLine(" [7] - Deletar conta");
        Console.WriteLine(" [0] - Logout\n");

        Console.Write(" Selecione a opção desejada: ");
        int optionMenuAccount = int.Parse(Console.ReadLine());

        Console.Clear();

        return optionMenuAccount;
    }
}
