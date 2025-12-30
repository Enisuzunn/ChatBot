# 🤖 Gemini ChatBot - Windows Desktop Application

C# WinForms ile geliştirilmiş, Google Gemini AI destekli masaüstü sohbet uygulaması.

![.NET](https://img.shields.io/badge/.NET-8.0-purple)
![Windows](https://img.shields.io/badge/Platform-Windows-blue)
![License](https://img.shields.io/badge/License-MIT-green)

## 📋 Özellikler

- 🚀 Google Gemini AI ile gerçek zamanlı sohbet
- 💬 Sohbet geçmişi korunarak bağlamsal yanıtlar
- 🎨 Modern koyu tema arayüz
- ⚙️ Kolay API anahtarı yapılandırması
- 🔄 Farklı Gemini modelleri arasında geçiş (Flash, Pro)

## 🛠️ Gereksinimler

- Windows 10/11
- Visual Studio 2022
- .NET 8.0 SDK
- Google Gemini API Anahtarı

## 📦 Kurulum

1. **Projeyi klonlayın:**
   ```bash
   git clone https://github.com/YOUR_USERNAME/ChatBot.git
   cd ChatBot
   ```

2. **Visual Studio 2022 ile açın:**
   - `ChatBot.sln` dosyasını çift tıklayın
   - Veya VS2022'de File > Open > Project/Solution

3. **NuGet paketlerini yükleyin:**
   - Solution Explorer'da projeye sağ tıklayın
   - "Restore NuGet Packages" seçin

4. **API Anahtarını ayarlayın:**
   - [Google AI Studio](https://aistudio.google.com/app/apikey) adresinden API anahtarı alın
   - Uygulamayı çalıştırıp "Ayarlar" butonundan API anahtarını girin
   - Veya `appsettings.json` dosyasını düzenleyin

5. **Derleyin ve çalıştırın:**
   - F5 tuşuna basın veya Debug > Start Debugging

## 🔧 Yapılandırma

### appsettings.json

```json
{
  "GeminiSettings": {
    "ApiKey": "YOUR_GEMINI_API_KEY_HERE",
    "Model": "gemini-1.5-flash",
    "MaxTokens": 2048
  }
}
```

### Desteklenen Modeller

| Model | Açıklama |
|-------|----------|
| `gemini-1.5-flash` | Hızlı yanıtlar için optimize edilmiş |
| `gemini-1.5-pro` | Daha kapsamlı ve detaylı yanıtlar |
| `gemini-1.0-pro` | Klasik Gemini modeli |

## 📁 Proje Yapısı

```
ChatBot/
├── ChatBot.sln
├── .gitignore
├── README.md
└── ChatBot/
    ├── ChatBot.csproj
    ├── Program.cs
    ├── appsettings.json
    ├── Forms/
    │   ├── MainForm.cs
    │   ├── MainForm.Designer.cs
    │   ├── SettingsForm.cs
    │   └── SettingsForm.Designer.cs
    ├── Services/
    │   ├── IGeminiService.cs
    │   └── GeminiService.cs
    └── Models/
        ├── ChatMessage.cs
        ├── GeminiRequest.cs
        └── GeminiResponse.cs
```

## 🎯 Kullanım

1. Uygulamayı başlatın
2. İlk kullanımda "Ayarlar" butonuna tıklayın
3. Google AI Studio'dan aldığınız API anahtarını girin
4. Model seçin (varsayılan: gemini-1.5-flash)
5. "Kaydet" butonuna tıklayın
6. Artık sohbet edebilirsiniz! 🎉

## ⌨️ Kısayollar

| Kısayol | İşlev |
|---------|-------|
| `Enter` | Mesaj gönder |
| `Shift+Enter` | Yeni satır |

## 🔒 Güvenlik

- API anahtarınızı asla GitHub'a pushlamayın
- `appsettings.json` dosyası `.gitignore`'a eklenmiştir
- Hassas veriler için environment variable kullanımı önerilir

## 🤝 Katkıda Bulunma

1. Fork yapın
2. Feature branch oluşturun (`git checkout -b feature/amazing-feature`)
3. Commit yapın (`git commit -m 'Add amazing feature'`)
4. Push yapın (`git push origin feature/amazing-feature`)
5. Pull Request açın

## 📄 Lisans

Bu proje MIT lisansı altında lisanslanmıştır.

## 📞 İletişim

Sorularınız için issue açabilirsiniz.

---

⭐ Bu projeyi beğendiyseniz yıldız vermeyi unutmayın!
