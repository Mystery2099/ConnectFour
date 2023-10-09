using Connect_Four.Classes.Players;

namespace Connect_Four.Interfaces;

public interface IGame
{
    void Play();
    void GameOver(Player currentPlayer);
}