using Connect_Four.Classes.GameBoard;
using Connect_Four.Classes.Players;
using Connect_Four.Interfaces;
using static System.Console;

namespace Connect_Four.Classes;

public class Game : IGame
{
    private readonly Board _board;
    private readonly Player _player1;
    private readonly Player _player2;
    private bool _gameOver;

    private Game(bool isSinglePlayer)
    {
        _board = Board.Create(BoardSize.Normal);

        _player1 = Player.Create(1, true);
        _player2 = Player.Create(2, !isSinglePlayer);
        _gameOver = false;
    }
    
    //Asks the player some questions and starts a new game
    public static void Start()
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
    }
    
    public void Play()
    {
        var currentPlayer = _player1;

        while (true)
        {
            _board.Print();

            var column = currentPlayer.MakeMove(_board);
            _board.MakeMove(column, currentPlayer.PlayerNumber);
            
            _gameOver = _board.HasWinner || _board.IsFull;
            if (_gameOver)
            {
                GameOver(currentPlayer);
                break;
            }
            
            currentPlayer = (currentPlayer == _player1) ? _player2 : _player1;
        }
    }

    public void GameOver(Player currentPlayer)
    {
        _board.Print();
        if (_board.HasWinner)
        {
            WriteLine($"{currentPlayer.Name} wins!");
        }
        else if (_board.IsFull)
        {
            WriteLine("The game is a draw.");
        }
        ConnectFour.ShouldRestart = AskToRestart();
    }

    private static bool AskToRestart()
    {
        var complete = false;
        var restart = false;
        
        WriteLine("Would you like to play again? (Please enter '1' for yes and '2' for no)");

        while (!complete)
        {
            switch (ReadLine())
            {
                case "1":
                    restart = true;
                    complete = true;
                    break;
                case "2":
                    restart = false;
                    complete = true;
                    WriteLine("Closing Game...");
                    break;
                default:
                    WriteLine("Please enter '1' or '2'!");
                    continue;
            }
        }

        return restart;
    }
}