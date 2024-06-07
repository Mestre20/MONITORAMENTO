using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MONITORAMENTO_DE_REDE
{
    public partial class Form1 : Form
    {
        private CancellationTokenSource _cancellationTokenSource;
        private Config config;

        public Form1()
        {
            InitializeComponent();
            config = Config.LoadConfig(); // Carrega as configurações ao iniciar
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Adicionar um MenuStrip ao formulário e configurar os itens de menu
            MenuStrip menuStrip = new MenuStrip();
            ToolStripMenuItem configurarMenuItem = new ToolStripMenuItem("Configurar");
            ToolStripMenuItem configurarIPsMenuItem = new ToolStripMenuItem("Configurar IPs", null, ConfigurarIPs_Click);
            ToolStripMenuItem configurarTimerMenuItem = new ToolStripMenuItem("Configurar Timer", null, ConfigurarTimer_Click);

            configurarMenuItem.DropDownItems.Add(configurarIPsMenuItem);
            configurarMenuItem.DropDownItems.Add(configurarTimerMenuItem);
            menuStrip.Items.Add(configurarMenuItem);

            this.Controls.Add(menuStrip);
            this.MainMenuStrip = menuStrip;

            // Atualiza o intervalo do timer e os IPs conforme a configuração carregada
            timer1.Interval = config.PingInterval;
        }

        private async Task PingPCAsync(string ipAddress, PictureBox pictureBox, CancellationToken cancellationToken)
        {
            Ping ping = new Ping();
            int timeout = 1000; // Tempo limite de 1 segundo

            try
            {
                PingReply reply = await Task.Run(() => ping.Send(ipAddress, timeout), cancellationToken);
                if (reply.Status == IPStatus.Success)
                {
                    pictureBox.Invoke(new Action(() =>
                    {
                        pictureBox.Image = Properties.Resources.initialImage;
                    }));
                }
                else
                {
                    pictureBox.Invoke(new Action(() =>
                    {
                        pictureBox.Image = Properties.Resources.erroImage;
                    }));
                }
            }
            catch (OperationCanceledException)
            {
                pictureBox.Invoke(new Action(() =>
                {
                    pictureBox.Image = Properties.Resources.erroImage;
                }));
            }
            catch
            {
                pictureBox.Invoke(new Action(() =>
                {
                    pictureBox.Image = Properties.Resources.erroImage;
                }));
            }
        }

        private async void button11_Click(object sender, EventArgs e)
        {
            if (button11.Text == "INICIAR")
            {
                button11.Text = "PARAR";
                _cancellationTokenSource = new CancellationTokenSource();
                timer1.Interval = config.PingInterval;
                timer1.Start();
            }
            else if (button11.Text == "PARAR")
            {
                timer1.Stop();
                _cancellationTokenSource.Cancel();
                button11.Text = "INICIAR";
            }
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            PictureBox[] pictureBoxes = {
                pictureBox1, pictureBox2, pictureBox3,
                pictureBox4, pictureBox5, pictureBox6,
                pictureBox7, pictureBox8, pictureBox9,
                pictureBox10, pictureBox11
            };

            var pingTasks = new List<Task>();

            for (int i = 0; i < config.IPAddresses.Length; i++)
            {
                var task = PingPCAsync(config.IPAddresses[i], pictureBoxes[i], _cancellationTokenSource.Token);
                pingTasks.Add(task);
            }

            try
            {
                await Task.WhenAll(pingTasks);
            }
            catch (OperationCanceledException)
            {
                // Pings foram cancelados
            }
        }

        private void ConfigurarIPs_Click(object sender, EventArgs e)
        {
            using (ConfigurarIPsForm form = new ConfigurarIPsForm(config.IPAddresses))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    config.IPAddresses = form.IPAddresses;
                    config.SaveConfig(); // Salva as configurações após modificar
                }
            } 
        }

        private void ConfigurarTimer_Click(object sender, EventArgs e)
        {
            using (ConfigurarTimerForm form = new ConfigurarTimerForm(config.PingInterval))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    config.PingInterval = form.Interval;
                    config.SaveConfig(); // Salva as configurações após modificar
                }
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            // Lógica para o botão de conexão com a internet (se necessário)
        }

        private void button13_Click(object sender, EventArgs e)
        {

        }
    }
}
