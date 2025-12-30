using ChatBot.Models;
using ChatBot.Services;
using Microsoft.Extensions.Configuration;

namespace ChatBot.Forms
{
    public partial class MainForm : Form
    {
        private readonly IGeminiService _geminiService;
        private readonly List<ChatMessage> _conversationHistory;
        private bool _isProcessing;

        public MainForm()
        {
            InitializeComponent();
            _geminiService = new GeminiService();
            _conversationHistory = new List<ChatMessage>();
            LoadConfiguration();
            SetupUI();
        }

        private void LoadConfiguration()
        {
            try
            {
                var config = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .Build();

                var apiKey = config["GeminiSettings:ApiKey"];
                var model = config["GeminiSettings:Model"];

                if (!string.IsNullOrWhiteSpace(apiKey) && apiKey != "YOUR_GEMINI_API_KEY_HERE")
                {
                    _geminiService.SetApiKey(apiKey);
                }

                if (!string.IsNullOrWhiteSpace(model))
                {
                    _geminiService.SetModel(model);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Konfigürasyon yüklenirken hata: {ex.Message}", "Uyarı", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SetupUI()
        {
            // Form ayarları
            this.Text = "🤖 Gemini ChatBot";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimumSize = new Size(600, 500);

            // Hoşgeldin mesajı
            AppendMessage("🤖 Asistan", "Merhaba! Ben Gemini destekli bir sohbet asistanıyım. Size nasıl yardımcı olabilirim?", Color.FromArgb(100, 149, 237));
            
            if (!_geminiService.IsConfigured)
            {
                AppendMessage("⚠️ Sistem", "API anahtarı ayarlanmamış. Lütfen 'Ayarlar' butonuna tıklayarak Gemini API anahtarınızı girin.", Color.FromArgb(255, 165, 0));
            }
        }

        private void AppendMessage(string sender, string message, Color senderColor)
        {
            if (rtbChat.InvokeRequired)
            {
                rtbChat.Invoke(new Action(() => AppendMessage(sender, message, senderColor)));
                return;
            }

            // Gönderici adı
            rtbChat.SelectionStart = rtbChat.TextLength;
            rtbChat.SelectionColor = senderColor;
            rtbChat.SelectionFont = new Font(rtbChat.Font, FontStyle.Bold);
            rtbChat.AppendText($"{sender}:\n");

            // Mesaj içeriği
            rtbChat.SelectionColor = Color.White;
            rtbChat.SelectionFont = new Font(rtbChat.Font, FontStyle.Regular);
            rtbChat.AppendText($"{message}\n\n");

            // Otomatik kaydır
            rtbChat.SelectionStart = rtbChat.TextLength;
            rtbChat.ScrollToCaret();
        }

        private async void BtnSend_Click(object sender, EventArgs e)
        {
            await SendMessageAsync();
        }

        private async void TxtMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !e.Shift)
            {
                e.SuppressKeyPress = true;
                await SendMessageAsync();
            }
        }

        private async Task SendMessageAsync()
        {
            if (_isProcessing) return;

            var message = txtMessage.Text.Trim();
            if (string.IsNullOrWhiteSpace(message)) return;

            _isProcessing = true;
            btnSend.Enabled = false;
            txtMessage.Enabled = false;
            btnSend.Text = "⏳";

            try
            {
                // Kullanıcı mesajını göster
                AppendMessage("👤 Sen", message, Color.FromArgb(50, 205, 50));
                txtMessage.Clear();

                // AI yanıtını al
                var response = await _geminiService.SendMessageAsync(message, _conversationHistory);

                // Sohbet geçmişine ekle
                _conversationHistory.Add(new ChatMessage("user", message));
                _conversationHistory.Add(new ChatMessage("model", response));

                // Yanıtı göster
                AppendMessage("🤖 Asistan", response, Color.FromArgb(100, 149, 237));
            }
            catch (Exception ex)
            {
                AppendMessage("❌ Hata", ex.Message, Color.Red);
            }
            finally
            {
                _isProcessing = false;
                btnSend.Enabled = true;
                txtMessage.Enabled = true;
                btnSend.Text = "Gönder";
                txtMessage.Focus();
            }
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            using var settingsForm = new SettingsForm(_geminiService);
            settingsForm.ShowDialog(this);
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Sohbet geçmişini temizlemek istediğinize emin misiniz?", 
                "Sohbeti Temizle", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (result == DialogResult.Yes)
            {
                _conversationHistory.Clear();
                rtbChat.Clear();
                AppendMessage("🤖 Asistan", "Sohbet geçmişi temizlendi. Size nasıl yardımcı olabilirim?", Color.FromArgb(100, 149, 237));
            }
        }
    }
}
