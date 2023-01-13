public class Messages
{
    public static void MessageError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($" {message}\n");
        Console.ResetColor();
    }
}
