using System;
using System.Windows.Forms;

namespace MONITORAMENTO_DE_REDE
{
    public partial class ConfigurarTimerForm : Form
    {
        public int Interval { get; private set; }

        public ConfigurarTimerForm(int currentInterval)
        {
            InitializeComponent();
            // Assegure que o valor inicial está dentro dos limites permitidos
            if (currentInterval >= numericUpDownInterval.Minimum && currentInterval <= numericUpDownInterval.Maximum)
            {
                numericUpDownInterval.Value = currentInterval;
            }
            else
            {
                numericUpDownInterval.Value = numericUpDownInterval.Minimum;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Interval = (int)numericUpDownInterval.Value;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void InitializeComponent()
        {
            this.numericUpDownInterval = new System.Windows.Forms.NumericUpDown();
            this.buttonSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDownInterval
            // 
            this.numericUpDownInterval.Location = new System.Drawing.Point(12, 12);
            this.numericUpDownInterval.Maximum = new decimal(new int[] {
                60000, // 60 segundos (1 minuto)
                0,
                0,
                0});
            this.numericUpDownInterval.Minimum = new decimal(new int[] {
                100, // 100 milissegundos
                0,
                0,
                0});
            this.numericUpDownInterval.Name = "numericUpDownInterval";
            this.numericUpDownInterval.Size = new System.Drawing.Size(260, 20);
            this.numericUpDownInterval.TabIndex = 0;
            this.numericUpDownInterval.Value = new decimal(new int[] {
                1000,
                0,
                0,
                0});
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(197, 38);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 1;
            this.buttonSave.Text = "Salvar";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // ConfigurarTimerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 73);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.numericUpDownInterval);
            this.Name = "ConfigurarTimerForm";
            this.Text = "Configurar Timer";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInterval)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.NumericUpDown numericUpDownInterval;
        private System.Windows.Forms.Button buttonSave;
    }
}
