using Connect_Four.Classes.Players;

namespace Connect_Four.Interfaces;

internal interface IGame
{
    void Play();
    void GameOver(Player currentPlayer);
}