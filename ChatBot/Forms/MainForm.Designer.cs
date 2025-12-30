namespace ChatBot.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private RichTextBox rtbChat;
        private TextBox txtMessage;
        private Button btnSend;
        private Button btnSettings;
        private Button btnClear;
        private Panel pnlTop;
        private Panel pnlBottom;
        private Label lblTitle;

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
            this.pnlTop = new Panel();
            this.lblTitle = new Label();
            this.btnSettings = new Button();
            this.btnClear = new Button();
            this.rtbChat = new RichTextBox();
            this.pnlBottom = new Panel();
            this.txtMessage = new TextBox();
            this.btnSend = new Button();

            this.pnlTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();

            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = Color.FromArgb(45, 45, 48);
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Controls.Add(this.btnClear);
            this.pnlTop.Controls.Add(this.btnSettings);
            this.pnlTop.Dock = DockStyle.Top;
            this.pnlTop.Location = new Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new Size(800, 50);
            this.pnlTop.TabIndex = 0;

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Location = new Point(15, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(180, 25);
            this.lblTitle.Text = "🤖 Gemini ChatBot";

            // 
            // btnSettings
            // 
            this.btnSettings.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnSettings.BackColor = Color.FromArgb(0, 122, 204);
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatStyle = FlatStyle.Flat;
            this.btnSettings.Font = new Font("Segoe UI", 9F);
            this.btnSettings.ForeColor = Color.White;
            this.btnSettings.Location = new Point(695, 10);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new Size(90, 30);
            this.btnSettings.TabIndex = 1;
            this.btnSettings.Text = "⚙️ Ayarlar";
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Click += new EventHandler(this.BtnSettings_Click);

            // 
            // btnClear
            // 
            this.btnClear.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnClear.BackColor = Color.FromArgb(200, 80, 80);
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = FlatStyle.Flat;
            this.btnClear.Font = new Font("Segoe UI", 9F);
            this.btnClear.ForeColor = Color.White;
            this.btnClear.Location = new Point(595, 10);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new Size(90, 30);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "🗑️ Temizle";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new EventHandler(this.BtnClear_Click);

            // 
            // rtbChat
            // 
            this.rtbChat.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.rtbChat.BackColor = Color.FromArgb(30, 30, 30);
            this.rtbChat.BorderStyle = BorderStyle.None;
            this.rtbChat.Font = new Font("Segoe UI", 11F);
            this.rtbChat.ForeColor = Color.White;
            this.rtbChat.Location = new Point(10, 60);
            this.rtbChat.Name = "rtbChat";
            this.rtbChat.ReadOnly = true;
            this.rtbChat.Size = new Size(780, 420);
            this.rtbChat.TabIndex = 1;
            this.rtbChat.Text = "";

            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = Color.FromArgb(45, 45, 48);
            this.pnlBottom.Controls.Add(this.txtMessage);
            this.pnlBottom.Controls.Add(this.btnSend);
            this.pnlBottom.Dock = DockStyle.Bottom;
            this.pnlBottom.Location = new Point(0, 490);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new Size(800, 60);
            this.pnlBottom.TabIndex = 2;

            // 
            // txtMessage
            // 
            this.txtMessage.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.txtMessage.BackColor = Color.FromArgb(60, 60, 60);
            this.txtMessage.BorderStyle = BorderStyle.FixedSingle;
            this.txtMessage.Font = new Font("Segoe UI", 11F);
            this.txtMessage.ForeColor = Color.White;
            this.txtMessage.Location = new Point(10, 15);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.PlaceholderText = "Mesajınızı yazın...";
            this.txtMessage.Size = new Size(680, 32);
            this.txtMessage.TabIndex = 0;
            this.txtMessage.KeyDown += new KeyEventHandler(this.TxtMessage_KeyDown);

            // 
            // btnSend
            // 
            this.btnSend.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnSend.BackColor = Color.FromArgb(0, 150, 136);
            this.btnSend.FlatAppearance.BorderSize = 0;
            this.btnSend.FlatStyle = FlatStyle.Flat;
            this.btnSend.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnSend.ForeColor = Color.White;
            this.btnSend.Location = new Point(700, 12);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new Size(85, 36);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "Gönder";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new EventHandler(this.BtnSend_Click);

            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(30, 30, 30);
            this.ClientSize = new Size(800, 550);
            this.Controls.Add(this.rtbChat);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlBottom);
            this.MinimumSize = new Size(600, 450);
            this.Name = "MainForm";
            this.Text = "🤖 Gemini ChatBot";
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
