using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using Controller;

namespace GUI
{
    public partial class FormCadastroDesejos : Form
    {
        private ControllerDesejos controle;
        public FormCadastroDesejos()
        {
            InitializeComponent();
            controle = new ControllerDesejos();
        }

        private void novo() {
            textBoxAmigoSolicitante.Text = "";
            textBoxAmigoSolicitado.Text = "";
            richTextBoxDescricao.Text = "";
            dateTimePickerDataDesejo.Value = DateTime.Now;
            textBoxValorDesejo.Text = "";
      
        
        }
        
        
        private void button2_Click(object sender, EventArgs e)
        {
            Desejo desejo = new Desejo();
            desejo.Solicitante.IDAmigo = Convert.ToInt32(textBoxAmigoSolicitante.Text);
            desejo.Solicitado.IDAmigo = Convert.ToInt32(textBoxAmigoSolicitado.Text);
            desejo.Valor = Convert.ToDouble(textBoxValorDesejo);
            desejo.Descricao = richTextBoxDescricao.Text;
            desejo.DataDesejo = dateTimePickerDataDesejo.Value;

            if (controle.GravarDesejos(desejo))
            {
                MessageBox.Show("Desejo cadastrado com sucesso!!!");
                novo();


            }
            else {
                MessageBox.Show("Erro ao Cadastrar o Desejo!!");
            
            }
                


        }

        private void button1_Click(object sender, EventArgs e)
        {
            novo();
        }
    }
}
