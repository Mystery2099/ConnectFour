using Connect_Four.Classes.GameBoard;
using Connect_Four.Classes.Players;
using Connect_Four.Interfaces;
using static System.Console;

namespace Connect_Four.Classes;

public class Game : IGame
{
    public static bool ShouldRestart { get; private set; }

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
        bool singlePlayer;
        string[] validInputs = { "1", "2" };
        
        Clear();
        WriteLine("Welcome to Connect Four!\n");

        while (true)
        {
            WriteLine($"Enter '{validInputs[0]}' for single player\n" +
                      $"Enter '{validInputs[1]}' for multiplayer");

            var input = ReadLine();

            singlePlayer = input == validInputs[0];
            if (validInputs.Contains(input)) break;
            
            WriteLine("Invalid input. Please try again.");
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

        var output = string.Empty;
        
        if (_board.HasWinner)
        {
            output = $"{currentPlayer.Name} wins!";
        } 
        else if (_board.IsFull)
        {
            output = "The game is a draw.";
        }
        
        WriteLine(output);
        
        ShouldRestart = AskToRestart();
    }

    private static bool AskToRestart()
    {
        string[] validInputs = { "1", "2" };
        bool restart;
        
        WriteLine($"Would you like to play again? (Please enter '{validInputs[0]}' for yes and '{validInputs[1]}' for no)");

        while (true)
        {
            var input = ReadLine();
            
            if (input == validInputs[0])
            {
                restart = true;
                break;
            }

            if (input == validInputs[1])
            {
                restart = false;
                WriteLine("Closing Game...");
                break;
            }
            
            WriteLine($"Your input was invalid!\nPlease enter '{validInputs[0]}' or '{validInputs[1]}'!");
        }

        return restart;
    }
}