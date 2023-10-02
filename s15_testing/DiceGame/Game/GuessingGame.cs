using DiceGame.UserCommunication;

namespace DiceGame.Game;

public class GuessingGame
{
    private readonly IDice _dice;
    private readonly IUserCommunication _userCommunication;
    private const int _initialTries = 3;

    public GuessingGame(IDice dice, IUserCommunication userCommunication)
    {
        _dice = dice;
        _userCommunication = userCommunication;
    }


    public GameResult Play()
    {
        var diceRollResult = _dice.Roll();
        _userCommunication.ShowMessage("Dice rolled. Guess what number it shows in 3 tries.");
        var triesLeft = _initialTries;
        while (triesLeft > 0)
        {
            var guess = _userCommunication.ReadInteger("Enter a number:");
            if (guess == diceRollResult)
            {
                return GameResult.Victory;
            }
            _userCommunication.ShowMessage("Wrong number.");
            --triesLeft;
        }
        return GameResult.Loss;
    }

    public void PrintResult(GameResult gameResults)
    {
        string message =
            gameResults == GameResult.Victory
            ? "You win!"
            : "You lose :(";
        _userCommunication.ShowMessage(message);
    }
}