using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP1_Aula4
{
    public partial class Form1 : Form
    {
        Button[,] botao = new Button[10,20];
        char letras = 'A';
        int cont = 1;
        static int valor = 0;
        public Form1()
        {
            InitializeComponent();
        }


        private void CriaBotoes(object sender, EventArgs e)
        {
            Label cinemark = new Label();
            cinemark.Text = "Cinemark";
            cinemark.Location = new Point(556, 9);
            cinemark.Font = new Font("Arial", 15, FontStyle.Bold);
            cinemark.ForeColor = Color.Blue;
            Controls.Add(cinemark);
            for(int i = 0; i < 10; i++)
            {
                for(int j = 0; j < 20; j++)
                {
                    botao[i,j] = new Button();
                    botao[i, j].Name = "Botao" + cont;
                    botao[i, j].BackColor = Color.Green;
                    botao[i, j].Text = $"{letras}{j+1}";
                    botao[i, j].Height = 30;
                    botao[i, j].Width = 50;
                    botao[i, j].Location = new Point(60 * j, 40 * (i + 1));
                    botao[i, j].Click += new EventHandler(this.Faturamento);
                    Controls.Add(botao[i, j]);
                    
                    cont++;
                }
                letras++;
            }
            Button faturamento = new Button();
            faturamento.Name = "Botao faturamento";
            faturamento.Text = "Faturamento";
            faturamento.Font = new Font("Arial", 12, FontStyle.Regular);
            faturamento.Height = 35;
            faturamento.Width = 120;
            faturamento.Location = new Point(553, 512);
            faturamento.Click += new EventHandler(this.MostraTela);
            Controls.Add(faturamento);
        }
        public void Faturamento(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            DialogResult confirma;
            if (button.BackColor == Color.Green)
            {
                confirma = MessageBox.Show("Deseja Adicionar o assento ao carrinho?", "Salvar Assento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
            else
            {
                confirma = MessageBox.Show("Deseja Remover o assento do carrinho?", "Remover Assento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
             
            if(confirma == DialogResult.Yes)
            {
                if (button.BackColor == Color.Red)
                {
                    button.BackColor = Color.Green;
                }
                else
                {
                    button.BackColor = Color.Red;
                }
            }
        }
        public void MostraTela(object sender, EventArgs e)
        {
            valor = 0;
            foreach(Button b in botao)
            {
                if (b.BackColor == Color.Red)
                {
                    valor += 20;
                }
            }
            MessageBox.Show($"Total a pagar: R${valor:F2}");
        }
    }
}
