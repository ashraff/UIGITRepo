namespace CryptoExamples
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.crytpoType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.sltAlgorithm = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkLogging = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboModes = new System.Windows.Forms.ComboBox();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.txtPlain = new System.Windows.Forms.TextBox();
            this.txtCypher = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Key = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.backgroundWorkerThreadOne = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // crytpoType
            // 
            this.crytpoType.FormattingEnabled = true;
            this.crytpoType.Items.AddRange(new object[] {
            "Secret Key Cryptography (SKC)",
            "Public Key Cryptography (PKC)",
            "Hash Functions"});
            this.crytpoType.Location = new System.Drawing.Point(108, 65);
            this.crytpoType.Name = "crytpoType";
            this.crytpoType.Size = new System.Drawing.Size(304, 21);
            this.crytpoType.TabIndex = 0;
            this.crytpoType.SelectedIndexChanged += new System.EventHandler(this.crytpoType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Type";
            // 
            // sltAlgorithm
            // 
            this.sltAlgorithm.DisplayMember = "Value";
            this.sltAlgorithm.FormattingEnabled = true;
            this.sltAlgorithm.Location = new System.Drawing.Point(108, 110);
            this.sltAlgorithm.Name = "sltAlgorithm";
            this.sltAlgorithm.Size = new System.Drawing.Size(304, 21);
            this.sltAlgorithm.TabIndex = 2;
            this.sltAlgorithm.ValueMember = "Value";
            this.sltAlgorithm.SelectedIndexChanged += new System.EventHandler(this.sltAlgorithm_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Algorithm";
            // 
            // chkLogging
            // 
            this.chkLogging.AutoSize = true;
            this.chkLogging.Location = new System.Drawing.Point(25, 23);
            this.chkLogging.Name = "chkLogging";
            this.chkLogging.Size = new System.Drawing.Size(141, 17);
            this.chkLogging.TabIndex = 4;
            this.chkLogging.Text = "Enable Console Logging";
            this.chkLogging.UseVisualStyleBackColor = true;
            this.chkLogging.CheckedChanged += new System.EventHandler(this.chkLogging_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.comboModes);
            this.groupBox1.Location = new System.Drawing.Point(25, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(418, 140);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Algorithm Selector";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Mode";
            // 
            // comboModes
            // 
            this.comboModes.FormattingEnabled = true;
            this.comboModes.Location = new System.Drawing.Point(83, 104);
            this.comboModes.Name = "comboModes";
            this.comboModes.Size = new System.Drawing.Size(181, 21);
            this.comboModes.TabIndex = 0;
            // 
            // txtKey
            // 
            this.txtKey.Enabled = false;
            this.txtKey.Location = new System.Drawing.Point(108, 286);
            this.txtKey.Multiline = true;
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(304, 56);
            this.txtKey.TabIndex = 8;
            // 
            // txtPlain
            // 
            this.txtPlain.Enabled = false;
            this.txtPlain.Location = new System.Drawing.Point(108, 216);
            this.txtPlain.Multiline = true;
            this.txtPlain.Name = "txtPlain";
            this.txtPlain.Size = new System.Drawing.Size(304, 59);
            this.txtPlain.TabIndex = 9;
            // 
            // txtCypher
            // 
            this.txtCypher.Enabled = false;
            this.txtCypher.Location = new System.Drawing.Point(108, 351);
            this.txtCypher.Multiline = true;
            this.txtCypher.Name = "txtCypher";
            this.txtCypher.Size = new System.Drawing.Size(304, 59);
            this.txtCypher.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 216);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Plain Text";
            // 
            // Key
            // 
            this.Key.AutoSize = true;
            this.Key.Location = new System.Drawing.Point(39, 286);
            this.Key.Name = "Key";
            this.Key.Size = new System.Drawing.Size(25, 13);
            this.Key.TabIndex = 12;
            this.Key.Text = "Key";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(42, 351);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Citpher Text";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDecrypt);
            this.groupBox2.Controls.Add(this.btnEncrypt);
            this.groupBox2.Location = new System.Drawing.Point(25, 192);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(418, 269);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Data Encrypt/Decrypt";
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Enabled = false;
            this.btnDecrypt.Location = new System.Drawing.Point(312, 235);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(75, 23);
            this.btnDecrypt.TabIndex = 1;
            this.btnDecrypt.Text = "Decrypt";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Enabled = false;
            this.btnEncrypt.Location = new System.Drawing.Point(212, 235);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(75, 23);
            this.btnEncrypt.TabIndex = 0;
            this.btnEncrypt.Text = "Encrypt";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 495);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(469, 22);
            this.statusStrip.TabIndex = 16;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(455, 16);
            this.toolStripProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.toolStripProgressBar1.Visible = false;
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 517);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Key);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCypher);
            this.Controls.Add(this.txtPlain);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.chkLogging);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.sltAlgorithm);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.crytpoType);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cryptography Examples";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox crytpoType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox sltAlgorithm;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkLogging;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.TextBox txtPlain;
        private System.Windows.Forms.TextBox txtCypher;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Key;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.ComponentModel.BackgroundWorker backgroundWorkerThreadOne;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboModes;
    }
}

