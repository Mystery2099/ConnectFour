﻿using Connect_Four.Classes.Boards;
using Connect_Four.Classes.Players;
using static System.Console;

namespace Connect_Four.Classes.Game;

internal class Game : IGame
{
    public static bool ShouldRestart { get; private set; }

    private Board _board;
    private readonly Player _player1;
    private readonly Player _player2;
    private Player _currentPlayer;
    private bool _gameOver;

    private Game()
    {
        var gameMode = SetGameMode();

        _board = Board.Create();
        
        _player1 = Player.Create(1, true);
        _player2 = Player.Create(2, gameMode == GameMode.MultiPlayer);
        _currentPlayer = _player1;
        
        _gameOver = false;
    }
    
    /*
     * starts a new game by asking the player some questions and creating a new instance of the Game class.
     */
    public static void Start()
    {
        Clear();
        WriteLine("Welcome to Connect Four!\n");
        //Creates a new Game and starts the game loop in Play()
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
            _board.Print();

            _currentPlayer.MakeMove(ref _board);
            
            _gameOver = _board.HasWinner() || _board.IsFull();
            
            if (_gameOver)
            {
                GameOver();
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
        _board.Print();

        var output = string.Empty;
        
        if (_board.HasWinner())
        {
            output = $"{_currentPlayer.Name} wins!";
        } 
        else if (_board.IsFull())
        {
            output = "The game is a draw.";
        }
        
        WriteLine(output);
        
        ShouldRestart = AskToRestart();
    }

    private static bool AskToRestart()
    {
        string[] validInputs = { "0", "1" };
        bool restart;
        
        WriteLine($"Would you like to play again? (Please enter '{validInputs[0]}' for yes and '{validInputs[1]}' for no)");

        while (true)
        {
            var input = ReadLine();

            restart = input == validInputs[0];
            if (restart) break;

            if (input == validInputs[1])
            {
                WriteLine("Closing Game...");
                break;
            }
            
            WriteLine($"Your input was invalid!\nPlease enter '{validInputs[0]}' or '{validInputs[1]}'!");
        }

        return restart;
    }
}