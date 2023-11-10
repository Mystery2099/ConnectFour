using System.Runtime.InteropServices;
using Connect_Four.Classes.Boards;
using Connect_Four.Classes.Players;
using static System.Console;

namespace Connect_Four.Classes.Game;

internal class Game : IGame
{
    public static bool ShouldRestartProgram { get; private set; } = false;

    private Board _currentBoard;
    private Board? _previousBoard;
    private readonly Player _player1;
    private readonly Player _player2;
    private Player _currentPlayer;
    private readonly GameMode _gameMode;

    private Game()
    {
        _gameMode = SetGameMode();
        
        UpdateTitle(_gameMode.ToString());
        _currentBoard = Board.Create();
        _player1 = Player.Create(1, true);
        _player2 = Player.Create(2, _gameMode is GameMode.MultiPlayer);
        _currentPlayer = _player1;
        
    }
    
    /*
     * starts a new game by asking the player some questions and creating a new instance of the Game class.
     */
    internal static void Start()
    {
        Clear();
        ResetTitle(); 
        WriteLine("Welcome to Connect Four!\n");
        new Game().Play();
    }

    /*
     * Asks the user to select a game mode and returns their selection
    */
    private static GameMode SetGameMode()
    {
        string[] validInputs = { "0", "1" };
        
        while (true)
        {
            WriteLine($"Enter '{validInputs[0]}' for single player (Play against a computer with completely randomized moves)\n" +
                      $"Enter '{validInputs[1]}' for multiplayer (Play against a friend, or yourself)");
            var input = ReadLine();
            if (!validInputs.Contains(input))
            {
                WriteLine("Invalid input. Please try again.");
                continue;
            }
            
            if (input == validInputs[0])
                return GameMode.SinglePlayer;
            if (input == validInputs[1])
                return GameMode.MultiPlayer;
        }
    }
    
    /*
     * starts playing the game by alternating turns between players until there is a winner or the board is full.
     * basically starts and contains the primary game loop.
     */
    public void Play()
    {
        while (true)
        {
            Clear();
            if (_previousBoard != null)
            {
                WriteLine("Previous Board:");
                _previousBoard.Print();
                WriteLine("\nCurrent Board:");
            }
            _currentBoard.Print();

            _previousBoard = _currentBoard.DeepCopy();

            _currentPlayer.MakeMove(ref _currentBoard);
            
            
            if (_currentBoard.HasWinner() || _currentBoard.IsFull())
            {
                GameOver();
                UpdateTitle(_gameMode.ToString());
                if (!ShouldRestartProgram) continue;
                UpdateTitle("Closing");
                break;
            }
            
            _currentPlayer = (_currentPlayer == _player1) ? _player2 : _player1;
        }
    }

    /*
     * ends the game and announces whether there was a winner or the board is full.
     * also uses ShouldRestart method to ask the player if they would like to play again
     */
    public void GameOver()
    {
        UpdateTitle("Game Over");
        Clear();
        _currentBoard.Print();

        var output = string.Empty;
        
        if (_currentBoard.HasWinner())
        {
            output = $"{_currentPlayer.Name} wins!";
        } 
        else if (_currentBoard.IsFull())
        {
            output = "The game is a draw.";
        }
        
        WriteLine(output);
        
        if (ClearBoard()) return;
        
        AskToRestart();
    }

    private bool ClearBoard()
    {
        string[] validInputs = { "0", "1" };
        WriteLine($"Enter '{validInputs[0]}' to clear the board and continue playing\n" +
                  $"Enter '{validInputs[^1]}' to end the current game");
        while (true)
        {
            var input = ReadLine();
            
            if (!validInputs.Contains(input))
            {
                WriteLine($"Please enter '{validInputs[0]}' or '{validInputs[^1]}'");
                continue;
            }
            
            if (input == validInputs[0])
            {
                _currentBoard = Board.Create(_currentBoard.Rows, _currentBoard.Columns);
                _currentPlayer = _player1;
                return true;
            }

            if (input == validInputs[1]) return false;
            
        }
    }

    private void AskToRestart()
    {
        UpdateTitle("Restart");
        string[] validInputs = { "0", "1" };
        WriteLine($"Enter '{validInputs[0]}' to restart the program\n" +
                  $"Enter '{validInputs[^1]}' to close the program");
        while (true)
        {
            var input = ReadLine();
            
            ShouldRestartProgram = input == validInputs[0] || input == validInputs[2];
            
            if (ShouldRestartProgram) break;

            if (input == validInputs[1])
            {
                WriteLine("Closing Game...");
                break;
            }
            
            WriteLine("Your input was invalid!\n" +
                      $"Please enter '{validInputs[0]}' or '{validInputs[1]}'!");
        }

    }
    
    static void UpdateTitle(string newTitle)
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) 
            Title = $"Connect 4 - {newTitle}";
        else ResetTitle();
    }

    internal static void ResetTitle() => Title = "Connect 4";
}