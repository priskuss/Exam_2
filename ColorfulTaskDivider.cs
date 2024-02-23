using AnsiTools;

public class ConsoleUtils
{
    public static void PrintColorfulDivider()
    {
        string divider = "<><><><><><><><><><><><><><><><>";
        string[] colors = { ANSICodes.Colors.Red, ANSICodes.Colors.Green, ANSICodes.Colors.Yellow, ANSICodes.Colors.Blue, ANSICodes.Colors.Magenta, ANSICodes.Colors.Cyan };
        //Console.WriteLine("\n");
        for (int i = 0; i < divider.Length; i++)
        {
            Console.Write(colors[i % colors.Length] + divider[i]);
        }
        Console.Write(ANSICodes.Reset); // reset color
        Console.WriteLine("\n");
    }
}