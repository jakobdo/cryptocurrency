using Xunit;

public class ProgramTest
{
    [Fact]
    public void TestSingleSetPricePerUnit()
    {
        // Arrange
        Converter convert = new();

        // Act
        convert.SetPricePerUnit("BTC", 1000);

        // Assert
        Assert.Equal(1000, convert.GetPricePerUnit("BTC"));
    }

    [Fact]
    public void TestLastSetPricePerUnitCounts()
    {
        // Arrange
        Converter convert = new();

        // Act
        convert.SetPricePerUnit("BTC", 1000);
        convert.SetPricePerUnit("BTC", 2000);

        // Assert
        Assert.Equal(2000, convert.GetPricePerUnit("BTC"));
    }

    [Fact]
    public void TestConvertFromCurrencyNameExists()
    {
        // Arrange
        Converter convert = new();
        convert.SetPricePerUnit("BTC", 1000);
        convert.SetPricePerUnit("LTC", 100);

        // Act
        double result = convert.Convert("BTC", "LTC", 10);

        // Assert
        Assert.Equal(100, result);
    }

    [Fact]
    public void TestConvertFromCurrencyNameDoesNotExists()
    {
        // Arrange
        Converter convert = new();
        convert.SetPricePerUnit("BTC", 1000);
        convert.SetPricePerUnit("LTC", 100);

        // Act & Assert
        Assert.Throws<ArgumentException>(() => convert.Convert("BTC_NOT", "LTC", 10));
    }

}