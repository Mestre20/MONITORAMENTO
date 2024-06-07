using System;
using System.Windows.Forms;

namespace MONITORAMENTO_DE_REDE
{
    public partial class ConfigurarIPsForm : Form
    {
        public string[] IPAddresses { get; private set; }

        public ConfigurarIPsForm(string[] currentIPs)
        {
            InitializeComponent();
            LoadCurrentIPs(currentIPs);
        }

        private void LoadCurrentIPs(string[] currentIPs)
        {
            textBox1.Text = currentIPs.Length > 0 ? currentIPs[0] : string.Empty;
            textBox2.Text = currentIPs.Length > 1 ? currentIPs[1] : string.Empty;
            textBox3.Text = currentIPs.Length > 2 ? currentIPs[2] : string.Empty;
            textBox4.Text = currentIPs.Length > 3 ? currentIPs[3] : string.Empty;
            textBox5.Text = currentIPs.Length > 4 ? currentIPs[4] : string.Empty;
            textBox6.Text = currentIPs.Length > 5 ? currentIPs[5] : string.Empty;
            textBox7.Text = currentIPs.Length > 6 ? currentIPs[6] : string.Empty;
            textBox8.Text = currentIPs.Length > 7 ? currentIPs[7] : string.Empty;
            textBox9.Text = currentIPs.Length > 8 ? currentIPs[8] : string.Empty;
            textBox10.Text = currentIPs.Length > 9 ? currentIPs[9] : string.Empty;
            textBox11.Text = currentIPs.Length > 10 ? currentIPs[10] : string.Empty;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            IPAddresses = new string[]
            {
                textBox1.Text,
                textBox2.Text,
                textBox3.Text,
                textBox4.Text,
                textBox5.Text,
                textBox6.Text,
                textBox7.Text,
                textBox8.Text,
                textBox9.Text,
                textBox10.Text,
                textBox11.Text
            };

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ConfigurarIPsForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
