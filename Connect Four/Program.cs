using Connect_Four.Classes;
using static System.Console;

namespace Connect_Four;

internal static class ConnectFour
{
    public static bool ShouldRestart = false;

    public static void Main()
    {
        Title = "Connect 4";
        do { Game.Start(); } while (ShouldRestart);
    }
}