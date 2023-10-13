using Connect_Four.Classes;

Console.Title = "Connect 4";

/*
 * starts the game once, then checks the static ShouldRestart property to know if it should start the game again
 */
do { Game.Start(); } while (Game.ShouldRestart);