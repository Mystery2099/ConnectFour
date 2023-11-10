using Connect_Four.Classes.Game;

/*
 * starts the game once, then checks the static ShouldRestart property to know if it should start the game again
 */
do { Game.Start(); } while (Game.ShouldRestartProgram);

