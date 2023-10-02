using mocks;
using Moq;
using NUnit.Framework;

namespace mocksTests;

[TestFixture]
public class PersonalDataReaderTests
{

    private PersonalDataReader _cut;
    private Mock<IDatabaseConnection> _databaseConnectionMock;

    [SetUp]
    public void Setup()
    {
        _databaseConnectionMock = new Mock<IDatabaseConnection>();
        _cut = new PersonalDataReader(_databaseConnectionMock.Object);
    }

    [Test]
    public void Read_ShallProduceResultWithDataOfPersonReadFromTheDatabase()
    {
        var databaseConnectionMock = new Mock<IDatabaseConnection>();
        databaseConnectionMock
            .Setup(mock => mock.GetById(It.IsAny<int>()))
            .Returns(new Person(5,"John","Smith"));

        var personalDataReader = new PersonalDataReader(databaseConnectionMock.Object);
        //'Reset' will reset the previous configuration.
        //databaseConnectionMock.Reset();
        string result = personalDataReader.Read(5);
        Assert.AreEqual("(Id: 5) John Smith", result);
    }
    [Test]
    public void Save_ShallCallTheWriteMethod_WithCorrectArguments()
    {
        var databaseConnectionMock = new Mock<IDatabaseConnection>();
        

        var personalDataReader = new PersonalDataReader(databaseConnectionMock.Object);

        var personToBeSaved = new Person(10,"Jane","Miller");

        personalDataReader.Save(personToBeSaved);

        databaseConnectionMock.Verify(mock => mock.Write(personToBeSaved.Id, personToBeSaved), Times.Once());
    }
}