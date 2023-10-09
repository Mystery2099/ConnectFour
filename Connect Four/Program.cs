using Connect_Four.Classes;
using static System.Console;

namespace Connect_Four;

internal static class ConnectFour
{
    public static bool ShouldRestart = false;

    public static void Main()
    {
        Title = "Connect 4";
        do
        { 
            Clear();
            WriteLine("Welcome to Connect Four!\n");
            var singlePlayer = false;
            var askForGameMode = true;
            while (askForGameMode)
            {
                WriteLine("Please enter '1' for single player, \n" +
                          "enter '2' for multiplayer");
                switch (ReadLine())
                {
                    case "1":
                        singlePlayer = true;
                        askForGameMode = false;
                        break;
                    case "2":
                        singlePlayer = false;
                        askForGameMode = false;
                        break;
                }
            }
            new Game(singlePlayer).Play();
        } while (ShouldRestart);
    }
}