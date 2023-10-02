using DiceGame.Game;
using DiceGame.UserCommunication;
using Moq;
using NUnit.Framework;

namespace DiceGameTests;

[TestFixture]
public class DiceGameTests
{
    private Mock<IDice> _diceMock;
    private Mock<IUserCommunication> _usercommunicationmock;
    private GuessingGame _cut;

    [SetUp]
    public void Setup()
    {
        _diceMock = new Mock<IDice>();
        _usercommunicationmock = new Mock<IUserCommunication>();
        _cut = new GuessingGame(_diceMock.Object,_usercommunicationmock.Object);
    }

    [Test]
    public void Play_ShallReturnVictory_IfTheUserGuessesTheNumberOnTheFirstTry()
    {
        const int NumberOnDie = 3;
        _diceMock
            .Setup(mock => mock.Roll())
            .Returns(NumberOnDie);
        _usercommunicationmock
            .Setup(mock => mock.ReadInteger(It.IsAny<string>()))
            .Returns(NumberOnDie);  
        var gameResult = _cut.Play();
        Assert.AreEqual(GameResult.Victory, gameResult);
    }
    [Test]
    public void Play_ShallReturnLoss_IfTheUserFailsThreeTries()
    {
        const int NumberOnDie = 6;
        _diceMock
            .Setup(mock => mock.Roll())
            .Returns(NumberOnDie);
        _usercommunicationmock
            .SetupSequence(mock => mock.ReadInteger(It.IsAny<string>()))
            .Returns(1)
            .Returns(2)
            .Returns(3);
        var gameResult = _cut.Play();
        Assert.AreEqual(GameResult.Loss,gameResult);
    }
    [Test]
    public void Play_ShallShowWrongMessage_IfTheUserFailsTwoTries()
    {
        const int NumberOnDie = 6;
        _diceMock
            .Setup(mock => mock.Roll())
            .Returns(NumberOnDie);
        _usercommunicationmock
            .SetupSequence(mock => mock.ReadInteger(It.IsAny<string>()))
            .Returns(1)
            .Returns(2)
            .Returns(3);
        var gameResult = _cut.Play();
        _usercommunicationmock.Verify(mock => mock.ShowMessage("Wrong number."), Times.AtLeast(3));
    }
    [Test]
    public void Play_ShallShowMainMessage_WhenTheAppStarts()
    {
        _cut.Play();
        _usercommunicationmock.Verify(mock => mock.ShowMessage("Dice rolled. Guess what number it shows in 3 tries."), Times.Once);
    }

    [TestCase(GameResult.Victory, "You win!")]
    [TestCase(GameResult.Loss, "You lose :(")]
    public void PrintResult_ShallShowGameResultMessage_WhenTheGameEnds(GameResult gameResult,string message)
    {
        _cut.PrintResult(gameResult);

        _usercommunicationmock.Verify(mock => mock.ShowMessage(message), Times.Once);
    }
}