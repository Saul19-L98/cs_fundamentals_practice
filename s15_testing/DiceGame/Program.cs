using DiceGame.Game;
using DiceGame.UserCommunication;

var random = new Random();
var dice = new Dice(random);
var consoleCommunication = new ConsoleUserCommunication();
var guessingGame = new GuessingGame(dice, consoleCommunication);
GameResult gameResults = guessingGame.Play();
guessingGame.PrintResult(gameResults);

Console.ReadKey();