namespace Uqs.Customer.Tests;

public class ProfileServiceTests
{
    [Fact]
    public void CustomerVaild_UserName_ArgumentNullException()
    {
        // Arrange
        var sut = new ProfileService();
        // Act
        var e = Record.Exception(() => sut.ChangeUserName(null!));
        // Assert
        var ex = Assert.IsType<ArgumentNullException>(e);
        Assert.Equal("username", ex.ParamName);
        Assert.StartsWith("Value", ex.Message);
    }

    [Theory]
    [InlineData("Anameof8", true)]
    [InlineData("NameOfChar12", true)]
    [InlineData("ANameOfChar13", false)]
    [InlineData("NameOf7", false)]
    [InlineData("", false)]
    public void CustomerVaild_UserNameList_ArgumenetOutOfRangeException(string username, bool isValid)
    {
        // Arrange
        var sut = new ProfileService();
        // Act
        var e = Record.Exception(() => sut.ChangeUserName(username));
        // Assert
        if (isValid)
        {
            Assert.Null(e);
        }
        else
        {
            var ex = Assert.IsType<ArgumentOutOfRangeException>(e);
            Assert.Equal("username", ex.ParamName);
            Assert.StartsWith("Length", ex.Message);
        }
    }

    [Theory]
    [InlineData("!Anameof8", false)]
    [InlineData("Name_Char12", true)]
    [InlineData("AName Char13", false)]
    [InlineData("Inthe@middle", false)]
    [InlineData("WithDollar$", false)]
    public void CustomerVaild_InvalidCharValidation_ArgumenetOutOfRangeException(string username, bool isValid)
    {
        // Arrange
        var sut = new ProfileService();
        // Act
        var e = Record.Exception(() => sut.ChangeUserName(username));
        // Assert
        if (isValid)
        {
            Assert.Null(e);
        }
        else
        {
            var ex = Assert.IsType<ArgumentOutOfRangeException>(e);
            Assert.Equal("username", ex.ParamName);
            Assert.StartsWith("InvalidChar", ex.Message);
        }
    }
}