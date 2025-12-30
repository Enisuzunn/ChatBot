using ChatBot.Services;

namespace ChatBot.Forms
{
    public partial class SettingsForm : Form
    {
        private readonly IGeminiService _geminiService;

        public SettingsForm(IGeminiService geminiService)
        {
            InitializeComponent();
            _geminiService = geminiService;
            LoadModels();
        }

        private void LoadModels()
        {
            cmbModel.Items.Add("gemini-1.5-flash");
            cmbModel.Items.Add("gemini-1.5-pro");
            cmbModel.Items.Add("gemini-1.0-pro");
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

            _geminiService.SetApiKey(apiKey);
            _geminiService.SetModel(cmbModel.SelectedItem?.ToString() ?? "gemini-1.5-flash");

            MessageBox.Show("Ayarlar kaydedildi!", "Başarılı", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            this.DialogResult = DialogResult.OK;
            this.Close();
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
