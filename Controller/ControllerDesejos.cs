using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.SqlClient;

namespace Controller
{
    public class ControllerDesejos
    {
        public bool GravarDesejos(Desejo desejo) {
            SqlConnection conexao = ADODBConnection.Connection();
            SqlCommand comando = conexao.CreateCommand();
            comando.CommandText = "insert into tbl_desejo (id_amigo_solicitante, id_amigo_solicitado, data_desejo, valor, descricao_desejo)" + 
            "values (@amigosolicitante, @amigosolicitado, @data_desejo, @valor, @descricao)";
            comando.Parameters.AddWithValue("@amigosolicitante", desejo.Solicitante.IDAmigo);
            comando.Parameters.AddWithValue("@amigosolicitado", desejo.Solicitado.IDAmigo);
            comando.Parameters.AddWithValue("@data_desejo", desejo.DataDesejo);
            comando.Parameters.AddWithValue("@valor", desejo.Valor);
            comando.Parameters.AddWithValue("@descricao", desejo.Descricao);

            conexao.Open();
            int linhasModificadas = comando.ExecuteNonQuery();
            conexao.Close();

            if (linhasModificadas == 0)
                return false;
            else
                return true;
        }

        public List<Desejo> ListarDesejosporAmigos(int IdAmigo)
        {
            SqlConnection conexao = ADODBConnection.Connection();
            SqlCommand comando = conexao.CreateCommand();
            comando.CommandText = "select id_desejo, id_amigo_solicitante, id_amigo_solicitado, data_desejo, valor, descricao_desejo, tbl_amigo.nome, e-mail, data_nascimento  from " +
                "from tbl_desejo join tbl_amigo on tbl_desejo.id_amigo_solicitante = tbl_amigo.id_amigo" +
               "where tbl_desejo.id_amigo_solicitante = @idAmigo";
            comando.Parameters.AddWithValue("@idAmigo", IdAmigo);
            List<Desejo> listadejesos = new List<Desejo>();
            Desejo desejo;
            conexao.Open();
            using (SqlDataReader reader = comando.ExecuteReader()) 
            {

                while (reader.Read()) {
                    desejo = new Desejo();
                    desejo.IDDesejo = reader.GetInt32(0);
                    desejo.Solicitante.IDAmigo = reader.GetInt32(1);
                    desejo.Solicitado.IDAmigo = reader.GetInt32(2);
                    desejo.DataDesejo = reader.GetDateTime(3);
                    desejo.Valor = reader.GetFloat(4);
                    desejo.Descricao = reader.GetString(5);
                    desejo.Solicitante.Nome = reader.GetString(6);
                    desejo.Solicitante.Email = reader.GetString(7);
                    desejo.Solicitante.DataNascimento = reader.GetDateTime(8);
                    listadejesos.Add(desejo);    
                
                }
                conexao.Close();
                return listadejesos;

            
            }





        }




    }
}
