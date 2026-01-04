using ChatBot.Services;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace ChatBot.Forms
{
    public partial class SettingsForm : Form
    {
        private readonly IGeminiService _geminiService;
        private readonly string _settingsPath;

        public SettingsForm(IGeminiService geminiService)
        {
            InitializeComponent();
            _geminiService = geminiService;
            _settingsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appsettings.json");
            LoadModels();
            LoadCurrentSettings();
        }

        private void LoadCurrentSettings()
        {
            try
            {
                if (File.Exists(_settingsPath))
                {
                    var json = File.ReadAllText(_settingsPath);
                    var settings = JsonConvert.DeserializeObject<dynamic>(json);
                    
                    var apiKey = settings?.GeminiSettings?.ApiKey?.ToString();
                    var model = settings?.GeminiSettings?.Model?.ToString();

                    if (!string.IsNullOrWhiteSpace(apiKey) && apiKey != "YOUR_GEMINI_API_KEY_HERE")
                    {
                        txtApiKey.Text = apiKey;
                    }

                    if (!string.IsNullOrWhiteSpace(model))
                    {
                        var index = cmbModel.Items.IndexOf(model);
                        if (index >= 0) cmbModel.SelectedIndex = index;
                    }
                }
            }
            catch { }
        }

        private void LoadModels()
        {
            cmbModel.Items.Add("gemini-2.0-flash");
            cmbModel.Items.Add("gemini-2.0-flash-lite");
            cmbModel.Items.Add("gemini-2.5-flash-preview-05-20");
            cmbModel.Items.Add("gemini-2.5-pro-preview-05-20");
            cmbModel.SelectedIndex = 0;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            var apiKey = txtApiKey.Text.Trim();
            
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                MessageBox.Show("Lütfen API anahtarını girin.", "Uyarı", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var model = cmbModel.SelectedItem?.ToString() ?? "gemini-2.0-flash";

            // Servise ayarla
            _geminiService.SetApiKey(apiKey);
            _geminiService.SetModel(model);

            // Dosyaya kaydet
            SaveSettings(apiKey, model);

            MessageBox.Show("Ayarlar kaydedildi!", "Başarılı", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void SaveSettings(string apiKey, string model)
        {
            try
            {
                var settings = new
                {
                    GeminiSettings = new
                    {
                        ApiKey = apiKey,
                        Model = model,
                        MaxTokens = 2048
                    }
                };

                var json = JsonConvert.SerializeObject(settings, Formatting.Indented);
                File.WriteAllText(_settingsPath, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ayarlar dosyaya kaydedilemedi: {ex.Message}", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void LnkGetApiKey_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = "https://aistudio.google.com/app/apikey",
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Link açılamadı: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
