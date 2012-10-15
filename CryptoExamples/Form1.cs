namespace CryptoExamples
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows.Forms;

    using CryptoExamples.DES;
    using CryptoExamples.Util;

    public partial class Form1 : Form
    {
        #region Constructors

        public Form1()
        {
            InitializeComponent();
            backgroundWorkerThreadOne.DoWork += DoWork;
            backgroundWorkerThreadOne.RunWorkerCompleted += BwRunWorkerOneCompleted;
            backgroundWorkerThreadOne.WorkerReportsProgress = true;

            toolStripStatusLabel.Text = "Select Type and Algorithm";
        }

        #endregion Constructors

        #region Methods

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            txtPlain.Text = "";
            if (string.IsNullOrWhiteSpace(txtCypher.Text) || string.IsNullOrWhiteSpace(txtKey.Text))
            {
                MessageBox.Show("Please enter the Plain text and the Key for encryption.");
                return;
            }
            if (txtKey.Text.Length < 8)
            {
                MessageBox.Show("Key is too short.Should be of length 8");
                txtKey.Focus();
                return;
            }

            if (comboModes.SelectedIndex == 1 && string.IsNullOrWhiteSpace(txtInputVector.Text))
            {
                MessageBox.Show("Please enter the Input Vector(IV) for CBC Mode.");
                txtInputVector.Focus();
                return;
            }

            toolStripProgressBar1.Style = ProgressBarStyle.Marquee;
            toolStripProgressBar1.MarqueeAnimationSpeed = 30;
            toolStripProgressBar1.Visible = true;

            SharedObject sharedObject = new SharedObject();

            sharedObject.Algorithm = sltAlgorithm.SelectedIndex;
            sharedObject.Mode = comboModes.SelectedIndex;
            sharedObject.PlainText = txtPlain.Text;
            sharedObject.CipherText = txtCypher.Text;
            sharedObject.InputVector = txtInputVector.Text;
            sharedObject.Key = txtKey.Text;
            sharedObject.IsEncrypt = false;

            backgroundWorkerThreadOne.RunWorkerAsync(sharedObject);
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            txtCypher.Text = "";
            if (string.IsNullOrWhiteSpace(txtPlain.Text) || string.IsNullOrWhiteSpace(txtKey.Text))
            {
                MessageBox.Show("Please enter the Plain text and the Key for encryption.");
                return;
            }

            if (txtKey.Text.Length < 8)
            {
                MessageBox.Show("Key is too short.Should be of length 8");
                txtKey.Focus();
                return;
            }


            if (comboModes.SelectedIndex == 1 && string.IsNullOrWhiteSpace(txtInputVector.Text))
            {
                MessageBox.Show("Please enter the Input Vector(IV) for CBC Mode.");
                txtInputVector.Focus();
                return;
            }

            toolStripProgressBar1.Style = ProgressBarStyle.Marquee;
            toolStripProgressBar1.MarqueeAnimationSpeed = 30;
            toolStripProgressBar1.Visible = true;

            SharedObject sharedObject = new SharedObject();

            sharedObject.Algorithm = sltAlgorithm.SelectedIndex;
            sharedObject.Mode = comboModes.SelectedIndex;
            sharedObject.PlainText = txtPlain.Text;
            sharedObject.CipherText = txtCypher.Text;
            sharedObject.Key = txtKey.Text;
            sharedObject.InputVector = txtInputVector.Text;
            sharedObject.IsEncrypt = true;

            backgroundWorkerThreadOne.RunWorkerAsync(sharedObject);
        }

        private void BwRunWorkerOneCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            SharedObject sharedObject = e.Result as SharedObject;
            toolStripProgressBar1.Visible = false;
            toolStripStatusLabel.Text = "Elapsed time: " + sharedObject.TimeTaken;

            if (sharedObject.IsEncrypt)
                txtCypher.Text = sharedObject.CipherText;
            else
                txtPlain.Text = sharedObject.PlainText;

            if(!string.IsNullOrWhiteSpace(sharedObject.InputVector))
                txtInputVector.Text = sharedObject.InputVector;
        }

        private void chkLogging_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLogging.Checked)
                Win32.AllocConsole();
            else Win32.FreeConsole();
        }

        private void crytpoType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            sltAlgorithm.DataSource = new BindingSource(null, null);
            sltAlgorithm.Text = "";
            toolStripStatusLabel.Text = "Select Algorithm";
            EnableDisableControls(false);
            switch (comboBox.SelectedIndex)
            {
                case 0:
                    sltAlgorithm.DataSource = new BindingSource(Constants.SKC_ALOGRITHMS, null);
                    sltAlgorithm.DisplayMember = "Value";
                    sltAlgorithm.ValueMember = "Key";
                    sltAlgorithm.SelectedIndex = 0;
                    break;
                case 1: break;
                case 2: break;
            }
        }

        private void DoWork(object sender, DoWorkEventArgs doWorkEventArgs)
        {
            DateTime begin = DateTime.UtcNow;

            SharedObject sharedObject = doWorkEventArgs.Argument as SharedObject;
            SharedObject resultObject = new SharedObject();
            switch (sharedObject.Algorithm)
            {
                case 1:


                    DESAlgorithm des = new DESAlgorithm();
                    if (sharedObject.IsEncrypt)
                        resultObject = des.encrypt(sharedObject);
                    else resultObject = des.decrypt(sharedObject);

                    break;
                case 2: break;
                case 3: break;
            }
            DateTime end = DateTime.UtcNow;

            resultObject.TimeTaken = (end - begin).ToString("c");
            resultObject.IsEncrypt = sharedObject.IsEncrypt;

            doWorkEventArgs.Result = resultObject;
        }

        private void EnableDisableControls(bool isEnabled)
        {
            txtCypher.Enabled = isEnabled;
            txtKey.Enabled = isEnabled;
            txtPlain.Enabled = isEnabled;
            btnEncrypt.Enabled = isEnabled;
            btnDecrypt.Enabled = isEnabled;
            btnGenerateKey.Enabled = isEnabled;
            btnGenerateIV.Enabled = isEnabled;
        }

        private void sltAlgorithm_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;

            if (sltAlgorithm.SelectedIndex != 0)
                EnableDisableControls(true);
            else EnableDisableControls(false);

            comboModes.DataSource = new BindingSource(null, null);
            comboModes.Text = "";
            toolStripStatusLabel.Text = "Select Mode";

            switch (sltAlgorithm.SelectedIndex)
            {
                case 1:
                    comboModes.DataSource = new BindingSource(Constants.DES_MODES, null);
                    comboModes.DisplayMember = "Value";
                    comboModes.ValueMember = "Key";
                    comboModes.SelectedIndex = 0;
                    toolStripStatusLabel.Text = "Enter the Plain text and the Key(64 Bit/8 Characters)";
                    txtKey.MaxLength = 8;

                    break;
            }
        }

        #endregion Methods

        private void comboModes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboModes.SelectedIndex == 1)
                txtInputVector.Enabled = true;
            else txtInputVector.Enabled = false;
        }

        private void btnGenerateKey_Click(object sender, EventArgs e)
        {
            txtKey.Text = Guid.NewGuid().ToString("N").Substring(0, 8); 
        }

        private void btnGenerateIV_Click(object sender, EventArgs e)
        {
           txtInputVector.Text  = Guid.NewGuid().ToString("N").Substring(0, 8); 
        }

        
    }
}