# 🌍 Birim Dönüştürücü - Unit Converter

Modern C# MAUI uygulaması ile **13 farklı kategoride** matematiksel birimleri dönüştür.

## ✨ Özellikler

### 🎯 13 Dönüştürücü Kategorisi

| Kategori | Birimler | Örnek |
|----------|----------|-------|
| 🌡️ **Sıcaklık** | °C ↔ °F ↔ K | 25°C = 77°F |
| 📏 **Uzunluk** | m ↔ km ↔ mil ↔ inç ↔ ayak | 1000m = 1km |
| ⚖️ **Ağırlık** | kg ↔ g ↔ lbs ↔ oz | 1kg = 2.20lbs |
| 💧 **Hacim** | L ↔ mL ↔ gal ↔ pint | 1L = 1000mL |
| 📐 **Alan** | m² ↔ km² ↔ hektar ↔ mil² | 10000m² = 1ha |
| 🚗 **Hız** | m/s ↔ km/h ↔ mil/h ↔ knot | 1m/s = 3.6km/h |
| ⚡ **Enerji** | J ↔ kJ ↔ kWh ↔ cal | 1kJ = 1000J |
| 📐 **Açı Ölçüleri** | Derece ↔ Radian ↔ Gradient | 180° = π rad |
| ⏱️ **Zaman** | s ↔ dk ↔ sa ↔ gün ↔ hafta | 1 saat = 3600s |
| 💾 **Veri Boyutu** | Byte ↔ KB ↔ MB ↔ GB ↔ TB | 1MB = 1024KB |
| 🔌 **Güç** | W ↔ kW ↔ MW | 1kW = 1000W |
| 🌡️ **Basınç** | Pa ↔ Bar ↔ ATM ↔ PSI | 1 bar = 100000Pa |
| 🌊 **Yoğunluk** | kg/m³ ↔ g/cm³ ↔ lb/ft³ | 1g/cm³ = 1000kg/m³ |

### 🎨 Tasarım
- **Renkli ve Modern UI** - Mavi, turuncu, yeşil temalar
- **Responsive Layout** - Her cihaza uyum sağlar
- **Hemen Sonuç** - Anlık dönüştürme
- **Matematiksel Formüller** - Her sonuçla formül gösterir
- **Bilgi Paneli** - Kategoriye uygun açıklamalar

## 🚀 Teknoloji

- **Dil**: C# 12
- **Framework**: .NET MAUI 9.0
- **Platform**: Windows, Android, iOS, macOS
- **Pattern**: MVVM (Model-View-ViewModel)
- **Data Binding**: XAML ile iki yönlü bağlama

## 📋 Gereksinimler

- .NET 9.0 SDK veya üzeri
- Windows 10+ (Windows için)
- Xcode (iOS için)
- Android Studio (Android için)

## 🔧 Kurulum ve Çalıştırma

### 1. Repository'yi Klonlayın
```bash
git clone https://github.com/yourusername/UnitConverterApp.git
cd UnitConverterApp
```

### 2. Bağımlılıkları Yükleyin
```bash
dotnet restore
```

### 3. Windows'ta Çalıştırın
```bash
dotnet run -f net9.0-windows10.0.19041.0
```

### 4. Android'e Derleyin
```bash
dotnet publish -f net9.0-android -c Release
```

### 5. iOS'a Derleyin (macOS gerekli)
```bash
dotnet publish -f net9.0-ios -c Release
```

## 📁 Proje Yapısı

```
UnitConverterApp/
├── MainPage.xaml              # UI Tasarımı
├── MainPage.xaml.cs           # ViewModeli & Mantığı
├── App.xaml                   # Uygulama Kaynakları
├── MauiProgram.cs             # Başlangıç Yapılandırması
├── Resources/                 # İkonlar, Fontlar
├── Platforms/                 # Platform Spesifik Kod
│   ├── Windows/
│   ├── Android/
│   ├── iOS/
│   └── MacCatalyst/
└── UnitConverterApp.csproj    # Proje Dosyası
```

## 🎓 Öğrenme Kaynakları

Bu proje aşağıdakileri öğretir:
- MAUI kullanıcı arayüzü geliştirme
- XAML binding ve data binding
- MVVM mimarisi
- Matematiksel dönüştürmeler
- Cross-platform geliştirme

## 💡 Kod Örneği

### Sıcaklık Dönüştürme
```csharp
private (double, string) ConvertTemperature(double value, string conversion)
{
    return conversion switch
    {
        "Celsius → Fahrenheit" => ((value * 9 / 5) + 32, "°F = (°C × 9/5) + 32"),
        "Celsius → Kelvin" => (value + 273.15, "K = °C + 273.15"),
        _ => (0, "")
    };
}
```

## 🎨 Renkler & Tema

```
#0D47A1 - Koyu Mavi (Background)
#1565C0 - Açık Mavi (Header)
#FF6F00 - Turuncu (Düğmeler)
#4CAF50 - Yeşil (Sonuç)
#2196F3 - Mavi (Bilgi Paneli)
```

## 📝 Özellikler & Formüller

### Sıcaklık
- **°F = (°C × 9/5) + 32**
- **K = °C + 273.15**

### Uzunluk
- **1 km = 1000 m**
- **1 m = 39.3701 inç**
- **1 mil = 1.60934 km**

### Ağırlık
- **1 kg = 1000 g**
- **1 kg = 2.20462 lbs**
- **1 lbs = 453.592 g**

### Hacim
- **1 L = 1000 mL**
- **1 gal = 3.78541 L**

### Alan
- **1 km² = 1,000,000 m²**
- **1 hektar = 10,000 m²**

### Hız
- **1 m/s = 3.6 km/h**
- **1 km/h = 0.27778 m/s**

### Enerji
- **1 kJ = 1000 J**
- **1 kWh = 3,600,000 J**
- **1 cal = 4.184 J**

## 🐛 Bilinen Sorunlar

Şu anda bilinen sorun yoktur. Eğer sorun bulursanız lütfen issue açınız.

## 🤝 Katkı Yapın

Katkılarınızı bekliyoruz! Lütfen:

1. Fork yapınız
2. Feature branch oluşturunuz (`git checkout -b feature/AmazingFeature`)
3. Değişikliklerinizi commitleyin (`git commit -m 'Add some AmazingFeature'`)
4. Branch'inizi pushlayın (`git push origin feature/AmazingFeature`)
5. Pull Request açınız

## 📄 Lisans

Bu proje MIT Lisansı altında lisanslanmıştır - detaylar için [LICENSE](LICENSE) dosyasına bakınız.

## 👨‍💻 Yazar

**Yahya** - 2026

## 📞 İletişim

- GitHub: [@yourusername](https://github.com/yourusername)
- Email: yahya@example.com

## 🙏 Teşekkürler

- [Microsoft MAUI](https://learn.microsoft.com/maui/)
- [.NET Documentation](https://learn.microsoft.com/dotnet/)
- Tüm katkıda bulunanlar

## 📚 Faydalı Linkler

- [MAUI Documentation](https://learn.microsoft.com/maui/)
- [C# Documentation](https://learn.microsoft.com/dotnet/csharp/)
- [MVVM Pattern](https://learn.microsoft.com/windows/uwp/xaml-platform/x-bind-markup-extension)
- [Unit Conversion Formulas](https://www.metric-conversions.org/)

---

**⭐ Eğer beğendiyseniz lütfen yıldız verin!**

**🚀 Happy Converting!**
