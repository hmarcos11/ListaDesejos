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
    public partial class FormVisualizarDesejos : Form
    {

        private ControllerDesejos controleDesejo;
        private ControllerAmigo controleAmigo;
        public FormVisualizarDesejos()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string amigo = textBox1.Text;
            int id = 0;
            foreach (Amigo amg in controleAmigo.ListarAmigos()) {
                if (amg.Nome == amigo) {
                    id = amg.IDAmigo;
                }
                dataGridViewDesejo.DataSource = controleDesejo.ListarDesejosporAmigos(id);

} 

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
