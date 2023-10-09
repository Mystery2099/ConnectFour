using Connect_Four.Classes.Players;

namespace Connect_Four.Classes;

public class Game
{
    private Board board;
    private Player player1;
    private Player player2;

    public Game(bool isSinglePlayer)
    {
        board = new Board(4, 4);

        if (isSinglePlayer)
        {
            player1 = new HumanPlayer("Player 1", 1);
            player2 = new ComputerPlayer("Computer", 2);
        }
        else
        {
            player1 = new HumanPlayer("Player 1", 1);
            player2 = new HumanPlayer("Player 2", 2);
        }
    }

    public void Play()
    {
        var currentPlayer = player1;

        while (true)
        {
            board.Print();

            var column = currentPlayer.MakeMove(board);
            board.MakeMove(column, currentPlayer.PlayerNumber);

            if (board.HasWinner)
            {
                board.Print();
                Console.WriteLine($"{currentPlayer.Name} wins!");
                break;
            }

            if (board.IsFull)
            {
                board.Print();
                Console.WriteLine("The game is a draw.");
                break;
            }

            currentPlayer = (currentPlayer == player1) ? player2 : player1;
        }
    }
}