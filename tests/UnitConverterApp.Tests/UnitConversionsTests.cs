using System.Globalization;
using UnitConverterApp;
using Xunit;

public class UnitConversionsTests
{
    [Theory]
    [InlineData("🌡️ Sıcaklık", "Celsius → Fahrenheit", 100, 212)]
    [InlineData("🌡️ Sıcaklık", "Fahrenheit → Celsius", 32, 0)]
    [InlineData("🌡️ Sıcaklık", "Kelvin → Celsius", 273.15, 0)]
    [InlineData("📏 Uzunluk", "Kilometre → Metre", 1.5, 1500)]
    [InlineData("⚖️ Ağırlık", "Gram → Kilogram", 250, 0.25)]
    [InlineData("📐 Alan", "Hektar → Dekar", 2, 20)]
    [InlineData("🚗 Hız", "m/s → km/h", 10, 36)]
    [InlineData("⏱️ Zaman", "Hafta → Gün", 2, 14)]
    [InlineData("💾 Veri Boyutu", "Megabyte → Byte", 1, 1048576)]
    [InlineData("🌡️ Basınç", "ATM → Pascal", 1, 101325)]
    [InlineData("🌊 Yoğunluk", "g/cm³ → kg/m³", 1, 1000)]
    public void Converts(string category, string conversion, double input, double expected)
    {
        var (result, formula) = UnitConversions.Convert(category, conversion, input);

        Assert.Equal(expected, result, 6);
        Assert.False(string.IsNullOrEmpty(formula));
    }

    [Fact]
    public void AnglesUseExactFactors()
    {
        Assert.Equal(Math.PI, UnitConversions.ConvertAngle(180, "Derece → Radian").Item1, 12);
        Assert.Equal(100, UnitConversions.ConvertAngle(90, "Derece → Gradient").Item1, 12);
        Assert.Equal(200, UnitConversions.ConvertAngle(Math.PI, "Radian → Gradient").Item1, 12);
    }

    [Fact]
    public void RoundTripsStayClose()
    {
        var pounds = UnitConversions.ConvertWeight(10, "Kilogram → Pound").Item1;

        Assert.Equal(10, UnitConversions.ConvertWeight(pounds, "Pound → Kilogram").Item1, 6);
    }

    [Fact]
    public void UnknownConversionThrows()
    {
        Assert.Throws<ArgumentException>(() => UnitConversions.Convert("📏 Uzunluk", "Metre → Parsek", 1));
        Assert.Throws<ArgumentException>(() => UnitConversions.Convert("Bilinmeyen", "Metre → Kilometre", 1));
    }

    [Theory]
    [InlineData("12,5", 12.5)]
    [InlineData("12.5", 12.5)]
    [InlineData(" -3 ", -3)]
    [InlineData("1e3", 1000)]
    public void ParsesInput(string input, double expected)
    {
        Assert.True(UnitConversions.TryParseInput(input, out var value));
        Assert.Equal(expected, value, 12);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("on iki")]
    [InlineData("1e999")]
    public void RejectsBadInput(string? input)
    {
        Assert.False(UnitConversions.TryParseInput(input, out _));
    }

    [Fact]
    public void DotIsNotAThousandsSeparatorOnTurkishSystems()
    {
        var previous = CultureInfo.CurrentCulture;
        CultureInfo.CurrentCulture = new CultureInfo("tr-TR");
        try
        {
            Assert.True(UnitConversions.TryParseInput("12.5", out var value));
            Assert.Equal(12.5, value, 12);
        }
        finally
        {
            CultureInfo.CurrentCulture = previous;
        }
    }
}
