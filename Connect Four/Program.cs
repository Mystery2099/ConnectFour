using Connect_Four.Classes;

namespace Connect_Four;

internal static class ConnectFour
{
    public static bool ShouldRestart = false;

    public static void Main()
    {
        Console.Title = "Connect 4";
        do { Game.Start(); } while (ShouldRestart);
    }
}