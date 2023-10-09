using Connect_Four.Classes.GameBoard;
using Connect_Four.Classes.Players;

namespace Connect_Four.Classes;

public class Game
{
    private readonly Board _board;
    private readonly Player _player1;
    private readonly Player _player2;
    private bool _gameOver;

    public Game(bool isSinglePlayer)
    {
        _board = Board.Create(BoardTypes.Normal);

        _player1 = Player.Create(1, true);
        _player2 = Player.Create(2, !isSinglePlayer);
        _gameOver = false;
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

    void GameOver(Player currentPlayer)
    {
        if (_board.HasWinner)
        {
            _board.Print();
            Console.WriteLine($"{currentPlayer.Name} wins!");
            ConnectFour.ShouldRestart = AskToRestart();
        }
        else if (_board.IsFull)
        {
            _board.Print();
            Console.WriteLine("The game is a draw.");
            ConnectFour.ShouldRestart = AskToRestart();
        }
    }
    
    bool AskToRestart()
    {
        var complete = false;
        var restart = false;
        while (!complete)
        {
            Console.WriteLine("Would you like to play again? (Please enter '1' for yes and '2' for no)");
            switch (Console.ReadLine())
            {
                case "1":
                    restart = true;
                    complete = true;
                    break;
                case "2":
                    restart = false;
                    complete = true;
                    Console.WriteLine("Closing Game...");
                    break;
                default:
                    Console.WriteLine("You did not enter '1' or '2'!");
                    continue;
            }
        }

        return restart;
    }
}