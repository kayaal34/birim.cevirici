using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace UnitConverterApp;

public partial class MainPage : ContentPage
{
    private MainPageViewModel _viewModel;

    public MainPage()
    {
        InitializeComponent();
        _viewModel = new MainPageViewModel();
        BindingContext = _viewModel;
    }
}

public class MainPageViewModel : INotifyPropertyChanged
{
    private string _selectedCategory;
    private string _selectedConversion;
    private string _inputValue;
    private string _resultText;
    private string _resultFormula;
    private bool _hasResult;
    private string _infoText = "Kategori seçip dönüştürme türünü belirleyin, sonra değer girin.";

    public ObservableCollection<string> Categories { get; } = new()
    {
        "🌡️ Sıcaklık",
        "📏 Uzunluk",
        "⚖️ Ağırlık",
        "💧 Hacim",
        "📐 Alan",
        "🚗 Hız",
        "⚡ Enerji",
        "📐 Açı Ölçüleri",
        "⏱️ Zaman",
        "💾 Veri Boyutu",
        "🔌 Güç",
        "🌡️ Basınç",
        "🌊 Yoğunluk"
    };

    public ObservableCollection<string> ConversionTypes { get; set; } = new();

    public string SelectedCategory
    {
        get => _selectedCategory;
        set
        {
            if (_selectedCategory != value)
            {
                _selectedCategory = value;
                OnPropertyChanged();
                UpdateConversionTypes();
            }
        }
    }

    public string SelectedConversion
    {
        get => _selectedConversion;
        set
        {
            if (_selectedConversion != value)
            {
                _selectedConversion = value;
                OnPropertyChanged();
            }
        }
    }

    public string InputValue
    {
        get => _inputValue;
        set
        {
            if (_inputValue != value)
            {
                _inputValue = value;
                OnPropertyChanged();
            }
        }
    }

    public string ResultText
    {
        get => _resultText;
        set
        {
            if (_resultText != value)
            {
                _resultText = value;
                OnPropertyChanged();
            }
        }
    }

    public string ResultFormula
    {
        get => _resultFormula;
        set
        {
            if (_resultFormula != value)
            {
                _resultFormula = value;
                OnPropertyChanged();
            }
        }
    }

    public bool HasResult
    {
        get => _hasResult;
        set
        {
            if (_hasResult != value)
            {
                _hasResult = value;
                OnPropertyChanged();
            }
        }
    }

    public string InfoText
    {
        get => _infoText;
        set
        {
            if (_infoText != value)
            {
                _infoText = value;
                OnPropertyChanged();
            }
        }
    }

    public ICommand ConvertCommand { get; }
    public ICommand CategorySelectedCommand { get; }

    public MainPageViewModel()
    {
        ConvertCommand = new Command(Convert);
        CategorySelectedCommand = new Command<string>(category => SelectedCategory = category);
    }

    private void UpdateConversionTypes()
    {
        ConversionTypes.Clear();
        InfoText = "";

        switch (_selectedCategory)
        {
            case "🌡️ Sıcaklık":
                ConversionTypes.Add("Celsius → Fahrenheit");
                ConversionTypes.Add("Celsius → Kelvin");
                ConversionTypes.Add("Fahrenheit → Celsius");
                ConversionTypes.Add("Fahrenheit → Kelvin");
                ConversionTypes.Add("Kelvin → Celsius");
                ConversionTypes.Add("Kelvin → Fahrenheit");
                InfoText = "Sıcaklık dönüştürmesi için değer girin.";
                break;

            case "📏 Uzunluk":
                ConversionTypes.Add("Metre → Kilometre");
                ConversionTypes.Add("Metre → Santimetre");
                ConversionTypes.Add("Kilometre → Metre");
                ConversionTypes.Add("Metre → Mil");
                ConversionTypes.Add("Metre → İnç");
                ConversionTypes.Add("Metre → Ayak");
                InfoText = "Uzunluk değerini metre cinsinden girin.";
                break;

            case "⚖️ Ağırlık":
                ConversionTypes.Add("Kilogram → Gram");
                ConversionTypes.Add("Kilogram → Pound");
                ConversionTypes.Add("Kilogram → Ounce");
                ConversionTypes.Add("Gram → Kilogram");
                ConversionTypes.Add("Pound → Kilogram");
                ConversionTypes.Add("Ounce → Gram");
                InfoText = "Ağırlık değerini girin.";
                break;

            case "💧 Hacim":
                ConversionTypes.Add("Litre → Mililitre");
                ConversionTypes.Add("Litre → Galon");
                ConversionTypes.Add("Litre → Pint");
                ConversionTypes.Add("Mililitre → Litre");
                ConversionTypes.Add("Galon → Litre");
                ConversionTypes.Add("Pint → Mililitre");
                InfoText = "Hacim değerini girin.";
                break;

            case "📐 Alan":
                ConversionTypes.Add("m² → km²");
                ConversionTypes.Add("m² → Hektar");
                ConversionTypes.Add("km² → m²");
                ConversionTypes.Add("Hektar → m²");
                ConversionTypes.Add("m² → Mil²");
                ConversionTypes.Add("Hektar → Dekar");
                InfoText = "Alan değerini girin.";
                break;

            case "🚗 Hız":
                ConversionTypes.Add("m/s → km/h");
                ConversionTypes.Add("m/s → mil/h");
                ConversionTypes.Add("km/h → m/s");
                ConversionTypes.Add("km/h → mil/h");
                ConversionTypes.Add("m/s → Knot");
                ConversionTypes.Add("mil/h → km/h");
                InfoText = "Hız değerini girin.";
                break;

            case "⚡ Enerji":
                ConversionTypes.Add("Joule → Kilojoule");
                ConversionTypes.Add("Joule → Kilowatt-saat");
                ConversionTypes.Add("Joule → Kalori");
                ConversionTypes.Add("Kilojoule → Joule");
                ConversionTypes.Add("Kilowatt-saat → Joule");
                ConversionTypes.Add("Kalori → Joule");
                InfoText = "Enerji değerini girin.";
                break;

            case "📐 Açı Ölçüleri":
                ConversionTypes.Add("Derece → Radian");
                ConversionTypes.Add("Derece → Gradient");
                ConversionTypes.Add("Radian → Derece");
                ConversionTypes.Add("Radian → Gradient");
                ConversionTypes.Add("Gradient → Derece");
                ConversionTypes.Add("Gradient → Radian");
                InfoText = "Açı değerini derece cinsinden girin.";
                break;

            case "⏱️ Zaman":
                ConversionTypes.Add("Saniye → Dakika");
                ConversionTypes.Add("Saniye → Saat");
                ConversionTypes.Add("Dakika → Saniye");
                ConversionTypes.Add("Dakika → Saat");
                ConversionTypes.Add("Saat → Dakika");
                ConversionTypes.Add("Saat → Saniye");
                ConversionTypes.Add("Gün → Saat");
                ConversionTypes.Add("Hafta → Gün");
                InfoText = "Zaman değerini girin.";
                break;

            case "💾 Veri Boyutu":
                ConversionTypes.Add("Byte → Kilobyte");
                ConversionTypes.Add("Byte → Megabyte");
                ConversionTypes.Add("Byte → Gigabyte");
                ConversionTypes.Add("Byte → Terabyte");
                ConversionTypes.Add("Megabyte → Byte");
                ConversionTypes.Add("Megabyte → Gigabyte");
                ConversionTypes.Add("Gigabyte → Megabyte");
                InfoText = "Veri boyutunu byte cinsinden girin.";
                break;

            case "🔌 Güç":
                ConversionTypes.Add("Watt → Kilowatt");
                ConversionTypes.Add("Watt → Megawatt");
                ConversionTypes.Add("Kilowatt → Watt");
                ConversionTypes.Add("Kilowatt → Megawatt");
                ConversionTypes.Add("Megawatt → Kilowatt");
                ConversionTypes.Add("Megawatt → Watt");
                InfoText = "Güç değerini watt cinsinden girin.";
                break;

            case "🌡️ Basınç":
                ConversionTypes.Add("Pascal → Bar");
                ConversionTypes.Add("Pascal → ATM");
                ConversionTypes.Add("Pascal → PSI");
                ConversionTypes.Add("Bar → Pascal");
                ConversionTypes.Add("ATM → Pascal");
                ConversionTypes.Add("PSI → Pascal");
                InfoText = "Basınç değerini pascal cinsinden girin.";
                break;

            case "🌊 Yoğunluk":
                ConversionTypes.Add("kg/m³ → g/cm³");
                ConversionTypes.Add("kg/m³ → lb/ft³");
                ConversionTypes.Add("g/cm³ → kg/m³");
                ConversionTypes.Add("g/cm³ → lb/ft³");
                ConversionTypes.Add("lb/ft³ → kg/m³");
                ConversionTypes.Add("lb/ft³ → g/cm³");
                InfoText = "Yoğunluk değerini kg/m³ cinsinden girin.";
                break;
        }

        SelectedConversion = ConversionTypes.Count > 0 ? ConversionTypes[0] : "";
    }

    private void Convert()
    {
        if (string.IsNullOrWhiteSpace(InputValue) || !double.TryParse(InputValue, out double value))
        {
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                await Application.Current.MainPage.DisplayAlert("Hata", "Lütfen geçerli bir sayı girin.", "Tamam");
            });
            return;
        }

        if (string.IsNullOrWhiteSpace(SelectedConversion))
        {
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                await Application.Current.MainPage.DisplayAlert("Hata", "Lütfen dönüştürme türü seçin.", "Tamam");
            });
            return;
        }

        double result = 0;
        string formula = "";

        try
        {
            (result, formula) = _selectedCategory switch
            {
                "🌡️ Sıcaklık" => ConvertTemperature(value, _selectedConversion),
                "📏 Uzunluk" => ConvertLength(value, _selectedConversion),
                "⚖️ Ağırlık" => ConvertWeight(value, _selectedConversion),
                "💧 Hacim" => ConvertVolume(value, _selectedConversion),
                "📐 Alan" => ConvertArea(value, _selectedConversion),
                "🚗 Hız" => ConvertSpeed(value, _selectedConversion),
                "⚡ Enerji" => ConvertEnergy(value, _selectedConversion),
                "📐 Açı Ölçüleri" => ConvertAngle(value, _selectedConversion),
                "⏱️ Zaman" => ConvertTime(value, _selectedConversion),
                "💾 Veri Boyutu" => ConvertDataSize(value, _selectedConversion),
                "🔌 Güç" => ConvertPower(value, _selectedConversion),
                "🌡️ Basınç" => ConvertPressure(value, _selectedConversion),
                "🌊 Yoğunluk" => ConvertDensity(value, _selectedConversion),
                _ => (0, "")
            };

            ResultText = $"✅ {value} → {result:F4}";
            ResultFormula = formula;
            HasResult = true;
        }
        catch (Exception ex)
        {
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                await Application.Current.MainPage.DisplayAlert("Hata", $"Dönüştürme hatası: {ex.Message}", "Tamam");
            });
        }
    }

    private (double, string) ConvertTemperature(double value, string conversion)
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

    private (double, string) ConvertLength(double value, string conversion)
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

    private (double, string) ConvertWeight(double value, string conversion)
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

    private (double, string) ConvertVolume(double value, string conversion)
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

    private (double, string) ConvertArea(double value, string conversion)
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

    private (double, string) ConvertSpeed(double value, string conversion)
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

    private (double, string) ConvertEnergy(double value, string conversion)
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

    private (double, string) ConvertAngle(double value, string conversion)
    {
        const double PI = 3.14159265359;
        return conversion switch
        {
            "Derece → Radian" => (value * PI / 180, "rad = derece × π/180"),
            "Derece → Gradient" => (value * 1.11111111, "grad = derece × 1.111"),
            "Radian → Derece" => (value * 180 / PI, "derece = rad × 180/π"),
            "Radian → Gradient" => (value * 180 / PI * 1.11111111, "grad = rad × 180/π × 1.111"),
            "Gradient → Derece" => (value * 0.9, "derece = grad × 0.9"),
            "Gradient → Radian" => (value * 0.9 * PI / 180, "rad = grad × 0.9 × π/180"),
            _ => (0, "")
        };
    }

    private (double, string) ConvertTime(double value, string conversion)
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

    private (double, string) ConvertDataSize(double value, string conversion)
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

    private (double, string) ConvertPower(double value, string conversion)
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

    private (double, string) ConvertPressure(double value, string conversion)
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

    private (double, string) ConvertDensity(double value, string conversion)
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

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
