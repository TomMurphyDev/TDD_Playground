using System.ComponentModel;

namespace Company.Math.Tests;

public class DivisionTests
{
    [Fact]
    public void Divide_DivisibleIntegers_WholeNumber()
    {
        //Arrange
        int divedend = 10;
        int divisor = 5;
        decimal expQuotient = 2;
        //Act
        decimal actQuotient = Division.Divide(divedend, divisor);
        //Assert
        Assert.Equal(expQuotient, actQuotient);
    }

    [Fact]
    public void Divide_IndivisibleIntegers_DecimalNumber()
    {
        int divedend = 10;
        int divisor = 4;
        decimal expQuotient = 2.5m;
        //Act
        decimal actQuotient = Division.Divide(divedend, divisor);
        //Assert
        Assert.Equal(expQuotient, actQuotient);
    }

    [Fact]
    public void Divide_DivideBy0_DivideZeroExceptionThrown()
    {
        // Arrange
        int dividend = 10;
        int divisor = 0;
        // Act
        Exception e = Record.Exception(() => Division.Divide(dividend, divisor));
        // Assert
        Assert.IsType<DivideByZeroException>(e);
    }

    [Theory]
    [InlineData(int.MaxValue, int.MinValue, -0.999999999534)]
    [InlineData(-int.MaxValue, int.MinValue, 0.999999999534)]
    [InlineData(int.MinValue, int.MaxValue, -1.000000000466)]
    [InlineData(int.MinValue, -int.MaxValue, 1.000000000466)]
    public void Divide_DivideEdgeCases_ExtremeInput(int divedend, int divisor, decimal result)
    {
        //Arrange
        //Act
        decimal actQuotient = Division.Divide(divedend,divisor);
        Assert.Equal(result,actQuotient,12);
    }
}