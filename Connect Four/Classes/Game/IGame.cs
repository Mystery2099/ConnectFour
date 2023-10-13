using Connect_Four.Classes.Players;

namespace Connect_Four.Classes.Game;

internal interface IGame
{
    void Play();
    void GameOver(Player currentPlayer);
}