namespace ChatBot.Forms
{
    partial class SettingsForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblApiKey;
        private TextBox txtApiKey;
        private Label lblModel;
        private ComboBox cmbModel;
        private Button btnSave;
        private Button btnCancel;
        private LinkLabel lnkGetApiKey;
        private Label lblInfo;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblApiKey = new Label();
            this.txtApiKey = new TextBox();
            this.lblModel = new Label();
            this.cmbModel = new ComboBox();
            this.btnSave = new Button();
            this.btnCancel = new Button();
            this.lnkGetApiKey = new LinkLabel();
            this.lblInfo = new Label();
            this.SuspendLayout();

            // 
            // lblInfo
            // 
            this.lblInfo.Font = new Font("Segoe UI", 9F);
            this.lblInfo.ForeColor = Color.LightGray;
            this.lblInfo.Location = new Point(20, 20);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new Size(340, 40);
            this.lblInfo.Text = "Gemini API anahtarınızı Google AI Studio'dan alabilirsiniz. Anahtar güvenli bir şekilde saklanacaktır.";

            // 
            // lblApiKey
            // 
            this.lblApiKey.AutoSize = true;
            this.lblApiKey.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblApiKey.ForeColor = Color.White;
            this.lblApiKey.Location = new Point(20, 70);
            this.lblApiKey.Name = "lblApiKey";
            this.lblApiKey.Size = new Size(100, 19);
            this.lblApiKey.Text = "API Anahtarı:";

            // 
            // txtApiKey
            // 
            this.txtApiKey.BackColor = Color.FromArgb(60, 60, 60);
            this.txtApiKey.BorderStyle = BorderStyle.FixedSingle;
            this.txtApiKey.Font = new Font("Segoe UI", 10F);
            this.txtApiKey.ForeColor = Color.White;
            this.txtApiKey.Location = new Point(20, 95);
            this.txtApiKey.Name = "txtApiKey";
            this.txtApiKey.PasswordChar = '●';
            this.txtApiKey.PlaceholderText = "AIza... şeklinde API anahtarınızı girin";
            this.txtApiKey.Size = new Size(340, 30);
            this.txtApiKey.TabIndex = 0;

            // 
            // lnkGetApiKey
            // 
            this.lnkGetApiKey.AutoSize = true;
            this.lnkGetApiKey.Font = new Font("Segoe UI", 9F);
            this.lnkGetApiKey.LinkColor = Color.FromArgb(100, 149, 237);
            this.lnkGetApiKey.Location = new Point(20, 130);
            this.lnkGetApiKey.Name = "lnkGetApiKey";
            this.lnkGetApiKey.Size = new Size(180, 15);
            this.lnkGetApiKey.TabIndex = 1;
            this.lnkGetApiKey.Text = "🔗 Google AI Studio'dan API al";
            this.lnkGetApiKey.LinkClicked += new LinkLabelLinkClickedEventHandler(this.LnkGetApiKey_LinkClicked);

            // 
            // lblModel
            // 
            this.lblModel.AutoSize = true;
            this.lblModel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblModel.ForeColor = Color.White;
            this.lblModel.Location = new Point(20, 160);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new Size(55, 19);
            this.lblModel.Text = "Model:";

            // 
            // cmbModel
            // 
            this.cmbModel.BackColor = Color.FromArgb(60, 60, 60);
            this.cmbModel.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbModel.FlatStyle = FlatStyle.Flat;
            this.cmbModel.Font = new Font("Segoe UI", 10F);
            this.cmbModel.ForeColor = Color.White;
            this.cmbModel.Location = new Point(20, 185);
            this.cmbModel.Name = "cmbModel";
            this.cmbModel.Size = new Size(340, 31);
            this.cmbModel.TabIndex = 2;

            // 
            // btnSave
            // 
            this.btnSave.BackColor = Color.FromArgb(0, 150, 136);
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = FlatStyle.Flat;
            this.btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnSave.ForeColor = Color.White;
            this.btnSave.Location = new Point(190, 240);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new Size(80, 35);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Kaydet";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new EventHandler(this.BtnSave_Click);

            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = Color.FromArgb(100, 100, 100);
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = FlatStyle.Flat;
            this.btnCancel.Font = new Font("Segoe UI", 10F);
            this.btnCancel.ForeColor = Color.White;
            this.btnCancel.Location = new Point(280, 240);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(80, 35);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "İptal";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new EventHandler(this.BtnCancel_Click);

            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(45, 45, 48);
            this.ClientSize = new Size(380, 295);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.lblApiKey);
            this.Controls.Add(this.txtApiKey);
            this.Controls.Add(this.lnkGetApiKey);
            this.Controls.Add(this.lblModel);
            this.Controls.Add(this.cmbModel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "⚙️ Ayarlar";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
