using Connect_Four.Classes.GameBoard;
using Connect_Four.Classes.Players;

namespace Connect_Four.Classes;

public class Game
{
    private readonly Board _board;
    private readonly Player _player1;
    private readonly Player _player2;

    public Game(bool isSinglePlayer)
    {
        _board = Board.Create(BoardTypes.Normal);

        _player1 = new HumanPlayer("Player 1", 1);
        _player2 = isSinglePlayer ? new ComputerPlayer("Computer", 2) : 
            new HumanPlayer("Player 2", 2);
    }

    public void Play()
    {
        var currentPlayer = _player1;

        while (true)
        {
            _board.Print();

            var column = currentPlayer.MakeMove(_board);
            _board.MakeMove(column, currentPlayer.PlayerNumber);

            if (_board.HasWinner)
            {
                _board.Print();
                Console.WriteLine($"{currentPlayer.Name} wins!");
                break;
            }

            if (_board.IsFull)
            {
                _board.Print();
                Console.WriteLine("The game is a draw.");
                break;
            }

            currentPlayer = (currentPlayer == _player1) ? _player2 : _player1;
        }
    }
}