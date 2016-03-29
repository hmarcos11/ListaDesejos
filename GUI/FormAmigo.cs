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
    public partial class FormAmigo : Form

    {
        private ControllerAmigo controle;
        public FormAmigo()
        {
            InitializeComponent();
            controle = new ControllerAmigo();
        }
        private void novo() {
            textBoxNome.Text = "";
            textBoxId.Text = "0";
            textBoxEmail.Text = "";
            dateTimePickerDataNascimento.Value = DateTime.Now;
        
        }
        private void atualizarGrid() {
            dataGridViewAmigo.DataSource = controle.ListarAmigos();
            dataGridViewAmigo.Columns[0].Visible = false;
        
        
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonExcluir_Click(object sender, EventArgs e)
        {
            int idAmigo = Convert.ToInt32(textBoxId.Text);
            if (idAmigo != 0) {
                if (controle.ExcluirAmigo(idAmigo))
                {
                    MessageBox.Show("Amigo excluido com sucesso!!!");
                    novo();
                    atualizarGrid();

                }
                else {
                    MessageBox.Show("Erro ao excluir o amigo");
             
                }
            }
            else {
                MessageBox.Show("Selecione um amigo para excluir!!!!");
            
            }

            
            }

        private void buttonGravar_Click(object sender, EventArgs e)
        {
            Amigo amigo = new Amigo();
            amigo.Nome = textBoxNome.Text;
            amigo.Email = textBoxEmail.Text;
            amigo.IDAmigo = Convert.ToInt32(textBoxId.Text);
            amigo.DataNascimento = dateTimePickerDataNascimento.Value;
            if (controle.GravarAmigo(amigo))
            {
                MessageBox.Show("Amigo salvo com Sucesso");
                novo();
                atualizarGrid();
            }
            else {

                MessageBox.Show("Erro ao salvar Amigo");
            }

        }


        private void buttonNovo_Click(object sender, EventArgs e)
        {
            novo();
        }

        private void FormAmigo_Load(object sender, EventArgs e)
        {
            novo();
            atualizarGrid();
        }

        private void dataGridViewAmigo_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewAmigo.CurrentRow != null) {

                List<Amigo> lista = (List<Amigo>)dataGridViewAmigo.DataSource;
                Amigo amigo = lista[dataGridViewAmigo.CurrentRow.Index];
                textBoxNome.Text = amigo.Nome;
                textBoxEmail.Text = amigo.Email;
                textBoxId.Text = amigo.IDAmigo.ToString();
                dateTimePickerDataNascimento.Value = amigo.DataNascimento;
            
            
            }
        }
    }
}
