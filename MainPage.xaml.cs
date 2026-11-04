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
            (result, formula) = UnitConversions.Convert(_selectedCategory, _selectedConversion, value);

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

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
