using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CryptoExamples.DES;
using CryptoExamples.Util;

namespace CryptoExamples
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            toolStripStatusLabel.Text = "Select Type and Algorithm";
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

        private void EnableDisableControls(bool isEnabled)
        {
            txtCypher.Enabled = isEnabled;
            txtKey.Enabled = isEnabled;
            txtPlain.Enabled = isEnabled;
            btnEncrypt.Enabled = isEnabled;
            btnDecrypt.Enabled = isEnabled;
        }


        private void chkLogging_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLogging.Checked)
                Win32.AllocConsole();
            else Win32.FreeConsole();
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPlain.Text) || string.IsNullOrWhiteSpace(txtKey.Text))
            {
                MessageBox.Show("Please enter the Plain text and the Key for encryption.");
            }
            DateTime begin = DateTime.UtcNow;
            switch (sltAlgorithm.SelectedIndex)
            {
                case 1:
                    switch (comboModes.SelectedIndex)
                    {
                        case 0:
                            
                            DESAlgorithm des = new DESAlgorithm();
                            string encryptedString = des.encrypt(txtPlain.Text, Utility.String2HexArray(txtKey.Text, 16)[0]);                           
                            txtCypher.Text = encryptedString;
                            break;
                    }
                    break;
                case 2: break;
                case 3: break;
            }
            DateTime end = DateTime.UtcNow;
            toolStripStatusLabel.Text = "Elapsed time: " + (end - begin).ToString("c");
        }

    }
}
