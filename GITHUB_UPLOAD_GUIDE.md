# GitHub'a Yükleme Adımları

## 1️⃣ GitHub'da Yeni Repository Oluşturun

1. [GitHub.com](https://github.com) adresine gidin
2. Sağ üst köşedeki **+** butonunu tıklayın
3. **New repository** seçin
4. Repository adı: `UnitConverterApp`
5. Açıklama: "Modern MAUI Unit Converter with 13 categories"
6. **Public** seçin (herkese görünür olsun)
7. **Create repository** tıklayın

---

## 2️⃣ Remote Bağlantısı Ekleyin

GitHub'da oluşturduğunuz repository sayfasında komut verilecektir. Aşağıdaki komutu terminalde çalıştırın (YOUR_USERNAME yerine kendi GitHub kullanıcı adınızı yazın):

```bash
cd C:\Users\yahya\dönüştürücü\UnitConverterApp

git remote add origin https://github.com/YOUR_USERNAME/UnitConverterApp.git

git branch -M main

git push -u origin main
```

**Örnek:**
```bash
git remote add origin https://github.com/yahya-dev/UnitConverterApp.git
git branch -M main
git push -u origin main
```

---

## 3️⃣ GitHub Erişim Token'ı (Zorunlu)

GitHub, şifre yerine **Personal Access Token** (PAT) kullanıyor. Token oluşturmak için:

1. GitHub'a gidin
2. **Settings** → **Developer settings** → **Personal access tokens** → **Tokens (classic)**
3. **Generate new token** tıklayın
4. Token adı: `UnitConverterApp`
5. Aşağıdaki izinleri seçin:
   - ☑️ `repo` (tam erişim)
   - ☑️ `workflow` (Actions)
6. **Generate token** tıklayın
7. **Token'ı kopyalayın** (sonra tekrar göremeyeceksiniz!)

---

## 4️⃣ Push Komutunu Çalıştırın

Terminal'e aşağıdaki komutu yazın:

```bash
git push -u origin main
```

Sorduğunda:
- **Username:** GitHub kullanıcı adınız
- **Password:** Yukarıda oluşturduğunuz Token'ı yapıştırın

---

## 5️⃣ Başarı! ✅

Repository'niz GitHub'da görünecektir. Şunları kontrol edin:

✅ README.md gösteriliyor  
✅ Tüm dosyalar yüklendi  
✅ 3 commit görünüyor  
✅ LICENSE dosyası mevcut  

---

## 🔄 Sonra Yapılacak Pushlar

Sonraki değişiklikleri yüklemek çok basit:

```bash
git add .
git commit -m "Açıklama yazın"
git push
```

---

## 📚 Faydalı Linkler

- [GitHub Hello World](https://guides.github.com/activities/hello-world/)
- [Git Cheat Sheet](https://github.github.com/training-kit/downloads/github-git-cheat-sheet.pdf)
- [Personal Access Token](https://docs.github.com/en/authentication/keeping-your-account-and-data-secure/creating-a-personal-access-token)

---

## 💡 İpuçları

**SSH Kullanmak İstiyorsanız:**

```bash
git remote set-url origin git@github.com:YOUR_USERNAME/UnitConverterApp.git
```

(Bunun için GitHub'da SSH key eklemeniz gerekir)

---

## 🆘 Sorun Yaşarsanız

**Eğer `fatal: unable to access` hatası alırsanız:**
1. Token'ı yanlış yapıştırdıysanız yeni bir tane oluşturun
2. Username ve token'ı kontrol edin
3. İnternet bağlantısını kontrol edin

---

**Hazır mısınız? Hadi başlayalım! 🚀**
