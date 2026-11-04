namespace UnitConverterApp;

/// <summary>
/// Birim dönüşümleri. Arayüzden bağımsız olduğu için testlerde doğrudan kullanılabilir.
/// </summary>
public static class UnitConversions
{
    /// <summary>
    /// Kullanıcı girişini okur. Hem "12,5" hem "12.5" kabul edilir; Türkçe sistemde
    /// double.TryParse "12.5" değerini binlik ayıracı sayıp 125 olarak okuyordu.
    /// </summary>
    public static bool TryParseInput(string? input, out double value)
    {
        value = 0;
        if (string.IsNullOrWhiteSpace(input))
        {
            return false;
        }
        var normalized = input.Trim().Replace(',', '.');
        return double.TryParse(normalized, System.Globalization.NumberStyles.Float,
                               System.Globalization.CultureInfo.InvariantCulture, out value)
               && double.IsFinite(value);
    }

    public static (double, string) Convert(string category, string conversion, double value)
    {
        return category switch
        {
            "🌡️ Sıcaklık" => ConvertTemperature(value, conversion),
            "📏 Uzunluk" => ConvertLength(value, conversion),
            "⚖️ Ağırlık" => ConvertWeight(value, conversion),
            "💧 Hacim" => ConvertVolume(value, conversion),
            "📐 Alan" => ConvertArea(value, conversion),
            "🚗 Hız" => ConvertSpeed(value, conversion),
            "⚡ Enerji" => ConvertEnergy(value, conversion),
            "📐 Açı Ölçüleri" => ConvertAngle(value, conversion),
            "⏱️ Zaman" => ConvertTime(value, conversion),
            "💾 Veri Boyutu" => ConvertDataSize(value, conversion),
            "🔌 Güç" => ConvertPower(value, conversion),
            "🌡️ Basınç" => ConvertPressure(value, conversion),
            "🌊 Yoğunluk" => ConvertDensity(value, conversion),
            _ => (0, "")
        };
    }

    public static (double, string) ConvertTemperature(double value, string conversion)
    {
        return conversion switch
        {
            "Celsius → Fahrenheit" => ((value * 9 / 5) + 32, "°F = (°C × 9/5) + 32"),
            "Celsius → Kelvin" => (value + 273.15, "K = °C + 273.15"),
            "Fahrenheit → Celsius" => ((value - 32) * 5 / 9, "°C = (°F - 32) × 5/9"),
            "Fahrenheit → Kelvin" => ((value - 32) * 5 / 9 + 273.15, "K = (°F - 32) × 5/9 + 273.15"),
            "Kelvin → Celsius" => (value - 273.15, "°C = K - 273.15"),
            "Kelvin → Fahrenheit" => ((value - 273.15) * 9 / 5 + 32, "°F = (K - 273.15) × 9/5 + 32"),
            _ => (0, "")
        };
    }

    public static (double, string) ConvertLength(double value, string conversion)
    {
        return conversion switch
        {
            "Metre → Kilometre" => (value / 1000, "km = m ÷ 1000"),
            "Metre → Santimetre" => (value * 100, "cm = m × 100"),
            "Kilometre → Metre" => (value * 1000, "m = km × 1000"),
            "Metre → Mil" => (value * 0.000621371, "mil = m × 0.000621371"),
            "Metre → İnç" => (value * 39.3701, "inç = m × 39.3701"),
            "Metre → Ayak" => (value * 3.28084, "ayak = m × 3.28084"),
            _ => (0, "")
        };
    }

    public static (double, string) ConvertWeight(double value, string conversion)
    {
        return conversion switch
        {
            "Kilogram → Gram" => (value * 1000, "g = kg × 1000"),
            "Kilogram → Pound" => (value * 2.20462, "lbs = kg × 2.20462"),
            "Kilogram → Ounce" => (value * 35.274, "oz = kg × 35.274"),
            "Gram → Kilogram" => (value / 1000, "kg = g ÷ 1000"),
            "Pound → Kilogram" => (value / 2.20462, "kg = lbs ÷ 2.20462"),
            "Ounce → Gram" => (value * 28.3495, "g = oz × 28.3495"),
            _ => (0, "")
        };
    }

    public static (double, string) ConvertVolume(double value, string conversion)
    {
        return conversion switch
        {
            "Litre → Mililitre" => (value * 1000, "mL = L × 1000"),
            "Litre → Galon" => (value * 0.264172, "gal = L × 0.264172"),
            "Litre → Pint" => (value * 2.11338, "pint = L × 2.11338"),
            "Mililitre → Litre" => (value / 1000, "L = mL ÷ 1000"),
            "Galon → Litre" => (value * 3.78541, "L = gal × 3.78541"),
            "Pint → Mililitre" => (value * 473.176, "mL = pint × 473.176"),
            _ => (0, "")
        };
    }

    public static (double, string) ConvertArea(double value, string conversion)
    {
        return conversion switch
        {
            "m² → km²" => (value / 1000000, "km² = m² ÷ 1,000,000"),
            "m² → Hektar" => (value / 10000, "ha = m² ÷ 10,000"),
            "km² → m²" => (value * 1000000, "m² = km² × 1,000,000"),
            "Hektar → m²" => (value * 10000, "m² = ha × 10,000"),
            "m² → Mil²" => (value * 3.86102e-7, "mil² = m² × 3.86102e-7"),
            "Hektar → Dekar" => (value * 10, "dekar = ha × 10"),
            _ => (0, "")
        };
    }

    public static (double, string) ConvertSpeed(double value, string conversion)
    {
        return conversion switch
        {
            "m/s → km/h" => (value * 3.6, "km/h = m/s × 3.6"),
            "m/s → mil/h" => (value * 2.23694, "mil/h = m/s × 2.23694"),
            "km/h → m/s" => (value / 3.6, "m/s = km/h ÷ 3.6"),
            "km/h → mil/h" => (value * 0.621371, "mil/h = km/h × 0.621371"),
            "m/s → Knot" => (value * 1.94384, "knot = m/s × 1.94384"),
            "mil/h → km/h" => (value * 1.60934, "km/h = mil/h × 1.60934"),
            _ => (0, "")
        };
    }

    public static (double, string) ConvertEnergy(double value, string conversion)
    {
        return conversion switch
        {
            "Joule → Kilojoule" => (value / 1000, "kJ = J ÷ 1000"),
            "Joule → Kilowatt-saat" => (value / 3600000, "kWh = J ÷ 3,600,000"),
            "Joule → Kalori" => (value / 4.184, "cal = J ÷ 4.184"),
            "Kilojoule → Joule" => (value * 1000, "J = kJ × 1000"),
            "Kilowatt-saat → Joule" => (value * 3600000, "J = kWh × 3,600,000"),
            "Kalori → Joule" => (value * 4.184, "J = cal × 4.184"),
            _ => (0, "")
        };
    }

    public static (double, string) ConvertAngle(double value, string conversion)
    {
        const double PI = Math.PI;
        return conversion switch
        {
            "Derece → Radian" => (value * PI / 180, "rad = derece × π/180"),
            "Derece → Gradient" => (value * 10 / 9, "grad = derece × 10/9"),
            "Radian → Derece" => (value * 180 / PI, "derece = rad × 180/π"),
            "Radian → Gradient" => (value * 200 / PI, "grad = rad × 200/π"),
            "Gradient → Derece" => (value * 0.9, "derece = grad × 0.9"),
            "Gradient → Radian" => (value * 0.9 * PI / 180, "rad = grad × 0.9 × π/180"),
            _ => (0, "")
        };
    }

    public static (double, string) ConvertTime(double value, string conversion)
    {
        return conversion switch
        {
            "Saniye → Dakika" => (value / 60, "dk = saniye ÷ 60"),
            "Saniye → Saat" => (value / 3600, "sa = saniye ÷ 3600"),
            "Dakika → Saniye" => (value * 60, "saniye = dk × 60"),
            "Dakika → Saat" => (value / 60, "sa = dk ÷ 60"),
            "Saat → Dakika" => (value * 60, "dk = sa × 60"),
            "Saat → Saniye" => (value * 3600, "saniye = sa × 3600"),
            "Gün → Saat" => (value * 24, "sa = gün × 24"),
            "Hafta → Gün" => (value * 7, "gün = hafta × 7"),
            _ => (0, "")
        };
    }

    public static (double, string) ConvertDataSize(double value, string conversion)
    {
        return conversion switch
        {
            "Byte → Kilobyte" => (value / 1024, "KB = byte ÷ 1024"),
            "Byte → Megabyte" => (value / 1048576, "MB = byte ÷ 1,048,576"),
            "Byte → Gigabyte" => (value / 1073741824, "GB = byte ÷ 1,073,741,824"),
            "Byte → Terabyte" => (value / 1099511627776, "TB = byte ÷ 1,099,511,627,776"),
            "Megabyte → Byte" => (value * 1048576, "byte = MB × 1,048,576"),
            "Megabyte → Gigabyte" => (value / 1024, "GB = MB ÷ 1024"),
            "Gigabyte → Megabyte" => (value * 1024, "MB = GB × 1024"),
            _ => (0, "")
        };
    }

    public static (double, string) ConvertPower(double value, string conversion)
    {
        return conversion switch
        {
            "Watt → Kilowatt" => (value / 1000, "kW = W ÷ 1000"),
            "Watt → Megawatt" => (value / 1000000, "MW = W ÷ 1,000,000"),
            "Kilowatt → Watt" => (value * 1000, "W = kW × 1000"),
            "Kilowatt → Megawatt" => (value / 1000, "MW = kW ÷ 1000"),
            "Megawatt → Kilowatt" => (value * 1000, "kW = MW × 1000"),
            "Megawatt → Watt" => (value * 1000000, "W = MW × 1,000,000"),
            _ => (0, "")
        };
    }

    public static (double, string) ConvertPressure(double value, string conversion)
    {
        return conversion switch
        {
            "Pascal → Bar" => (value / 100000, "bar = Pa ÷ 100,000"),
            "Pascal → ATM" => (value / 101325, "atm = Pa ÷ 101,325"),
            "Pascal → PSI" => (value / 6894.757, "psi = Pa ÷ 6894.757"),
            "Bar → Pascal" => (value * 100000, "Pa = bar × 100,000"),
            "ATM → Pascal" => (value * 101325, "Pa = atm × 101,325"),
            "PSI → Pascal" => (value * 6894.757, "Pa = psi × 6894.757"),
            _ => (0, "")
        };
    }

    public static (double, string) ConvertDensity(double value, string conversion)
    {
        return conversion switch
        {
            "kg/m³ → g/cm³" => (value / 1000, "g/cm³ = kg/m³ ÷ 1000"),
            "kg/m³ → lb/ft³" => (value * 0.0624279606, "lb/ft³ = kg/m³ × 0.0624"),
            "g/cm³ → kg/m³" => (value * 1000, "kg/m³ = g/cm³ × 1000"),
            "g/cm³ → lb/ft³" => (value * 62.4279606, "lb/ft³ = g/cm³ × 62.428"),
            "lb/ft³ → kg/m³" => (value * 16.01846337, "kg/m³ = lb/ft³ × 16.018"),
            "lb/ft³ → g/cm³" => (value * 0.016018463, "g/cm³ = lb/ft³ × 0.01602"),
            _ => (0, "")
        };
    }
}
