
using Unit8_SRP_F24;
using Unit8_SRP_F24.Contracts;

namespace Unit8_SRP_F24Tests.UnitTests;

[TestClass]
public class SimpleTradeValidatorTests
{

    [TestMethod()]
    public void TestGoodCurrencyString()
    {
        //Arrange
        var logger = new ConsoleLogger();
        var tradeValidator = new SimpleTradeValidator(logger);
        string[] strData = { "AAABBB", "4444", "1.00" };

        //Act
        bool result = tradeValidator.ValidateTradeData(strData, 1);

        //Assert
        Assert.IsTrue(result);
    }

    [TestMethod()]
    public void TestShortCurrencyString()
    {
        //Arrange
        var logger = new ConsoleLogger();
        var tradeValidator = new SimpleTradeValidator(logger);
        string[] strData = { "AAA", "4444", "1.00" };

        //Act
        bool result = tradeValidator.ValidateTradeData(strData, 1  );

        //Assert
        Assert.IsFalse(result);
    }

    [TestMethod()]
    public void TestLongCurrencyString()
    {
        //Arrange
        var logger = new ConsoleLogger();
        var tradeValidator = new SimpleTradeValidator(logger);
        string[] strData = { "AAAABBBB", "4444", "1.00" };

        //Act
        bool result = tradeValidator.ValidateTradeData(strData, 1);

        //Assert
        Assert.IsFalse(result);
    }

    [TestMethod()]
    public void TestNormalTrade()
    {
        //Arrange
        var logger = new ConsoleLogger();
        var tradeValidator = new SimpleTradeValidator(logger);
        string[] strData = { "AAABBB", "4444", "1.00" };

        //Act
        bool result = tradeValidator.ValidateTradeData(strData, 1);

        //Assert
        Assert.IsTrue(result);
    }

    [TestMethod()]
    public void TestAmount999()
    {
        //Arrange
        var logger = new ConsoleLogger();
        var tradeValidator = new SimpleTradeValidator(logger);
        string[] strData = { "AAABBB", "999", "1.00" };

        //Act
        bool result = tradeValidator.ValidateTradeData(strData, 1);

        //Assert
        Assert.IsFalse(result);
    }

    [TestMethod()]
    public void TestAmount1000()
    {
        //Arrange
        var logger = new ConsoleLogger();
        var tradeValidator = new SimpleTradeValidator(logger);
        string[] strData = { "AAABBB", "1000", "1.00" };

        //Act
        bool result = tradeValidator.ValidateTradeData(strData, 1);

        //Assert
        Assert.IsTrue(result);
    }

    [TestMethod()]
    public void TestAmountNeg10000()
    {
        //Arrange
        var logger = new ConsoleLogger();
        var tradeValidator = new SimpleTradeValidator(logger);
        string[] strData = { "AAABBB", "-10000", "1.00" };

        //Act
        bool result = tradeValidator.ValidateTradeData(strData, 1);

        //Assert
        Assert.IsFalse(result);
    }

    [TestMethod()]
    public void TestAmount100k()
    {
        //Arrange
        var logger = new ConsoleLogger();
        var tradeValidator = new SimpleTradeValidator(logger);
        string[] strData = { "AAABBB", "1000000", "1.00" };

        //Act
        bool result = tradeValidator.ValidateTradeData(strData, 1);

        //Assert
        Assert.IsTrue(result);
    }

    [TestMethod()]
    public void TestAmount101k()
    {
        //Arrange
        var logger = new ConsoleLogger();
        var tradeValidator = new SimpleTradeValidator(logger);
        string[] strData = { "AAABBB", "1000001", "1.00" };

        //Act
        bool result = tradeValidator.ValidateTradeData(strData, 1);

        //Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void ValidFields_ReturnsTrue()
    {
        // Arrange
        var validator = new SimpleTradeValidator(new StubLogger());
        string[] fields = { "AAABBB", "1000", "1.25" };

        // Act
        bool isValid = validator.ValidateTradeData(fields, 1);

        // Assert
        Assert.IsTrue(isValid);
    }

    [TestMethod]
    public void WrongNumberOfFields_ReturnsFalse()
    {
        // Arrange
        var validator = new SimpleTradeValidator(new StubLogger());
        string[] fields = { "AAABBB", "1000" };

        // Act
        bool isValid = validator.ValidateTradeData(fields, 1);

        // Assert
        Assert.IsFalse(isValid);
    }

    [TestMethod]
    public void CurrencyCodeOfWrongLength_ReturnsFalse()
    {
        // Arrange
        var validator = new SimpleTradeValidator(new StubLogger());
        string[] fields = { "AABBB", "1000", "1.25" };

        // Act
        bool isValid = validator.ValidateTradeData(fields, 1);

        // Assert
        Assert.IsFalse(isValid);
    }

    [TestMethod]
    public void NonIntegerAmount_ReturnsFalse()
    {
        // Arrange
        var validator = new SimpleTradeValidator(new StubLogger());
        string[] fields = { "AAABBB", "10.5", "1.25" };

        // Act
        bool isValid = validator.ValidateTradeData(fields, 1);

        // Assert
        Assert.IsFalse(isValid);
    }

    [TestMethod]
    public void NonDecimalPrice_ReturnsFalse()
    {
        // Arrange
        var validator = new SimpleTradeValidator(new StubLogger());
        string[] fields = { "AAABBB", "1000", "not-a-price" };

        // Act
        bool isValid = validator.ValidateTradeData(fields, 1);

        // Assert
        Assert.IsFalse(isValid);
    }

    [TestMethod]
    public void NegativeAmount_ReturnsFalse()
    {
        // Arrange
        var validator = new SimpleTradeValidator(new StubLogger());
        string[] fields = { "AAABBB", "-1000", "1.25" };

        // Act
        bool isValid = validator.ValidateTradeData(fields, 1);

        // Assert
        Assert.IsFalse(isValid);
    }

    [TestMethod]
    public void NegativePrice_ReturnsFalse()
    {
        // Arrange
        var validator = new SimpleTradeValidator(new StubLogger());
        string[] fields = { "AAABBB", "1000", "-1.25" };

        // Act
        bool isValid = validator.ValidateTradeData(fields, 1);

        // Assert
        Assert.IsFalse(isValid);
    }

    [TestMethod]
    public void NonLetterCurrencyCodes_ReturnsFalse()
    {
        // Arrange
        var validator = new SimpleTradeValidator(new StubLogger());
        string[] fields = { "A1!BB?", "1000", "1.25" };

        // Act
        bool isValid = validator.ValidateTradeData(fields, 1);

        // Assert
        Assert.IsFalse(isValid);
    }

    [TestMethod()]
    public void TestEmptyCurrencyString()
    {
        //Arrange
        var logger = new ConsoleLogger();
        var tradeValidator = new SimpleTradeValidator(logger);
        string[] strData = { "", "4444", "1.00" };

        //Act
        bool result = tradeValidator.ValidateTradeData(strData, 1);

        //Assert
        Assert.IsFalse(result);
    }

    private sealed class StubLogger : ILogger
    {
        public void LogMessage(string message, params object[] args)
        {
        }
    }
}
