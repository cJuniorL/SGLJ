using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGLJ.Camadas.DAL
{
    public class Cidades
    {
        private string strCon = Conexao.getConexao();

        public List<Modelo.Cidade> Select()
        {
            List<Modelo.Cidade> lstCidade = new List<Modelo.Cidade>();
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Select * from Cidades";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            conexao.Open();
            try
            {
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    Modelo.Cidade cidade = new Modelo.Cidade();
                    cidade.id = Convert.ToInt32(reader["id"]);
                    cidade.nome = reader["nome"].ToString();
                    cidade.uf = reader["uf"].ToString();
                    lstCidade.Add(cidade);
                }
            }
            catch
            {
                Console.WriteLine("Deu erro na Seleção de Cidades...");
            }
            finally
            {
                conexao.Close();
            }

            return lstCidade;
        }


        public Modelo.Cidade SelectById(int id)
        {
            Modelo.Cidade cidade = new Modelo.Cidade();
            List<Modelo.Cidade> lstCidade = new List<Modelo.Cidade>();
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Select * from Cidades where id=@id;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", id);
            conexao.Open();
            try
            {
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    cidade.id = Convert.ToInt32(reader["id"]);
                    cidade.nome = reader["nome"].ToString();
                    cidade.uf = reader["uf"].ToString();
                }
            }
            catch
            {
                Console.WriteLine("Deu erro na Seleção de Cidade por ID...");
            }
            finally
            {
                conexao.Close();
            }

            return cidade;
        }

        public void Insert(Modelo.Cidade cidade)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Insert into Cidades values (@nome, @uf)";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@nome", cidade.nome);
            cmd.Parameters.AddWithValue("@uf", cidade.uf);
            conexao.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Deu erro na inserção de Cidades...");
            }
            finally
            {
                conexao.Close();
            }
        }

        public void Update(Modelo.Cidade cidade)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Update Cidades set nome=@nome, uf=@uf where id=@id;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", cidade.id);
            cmd.Parameters.AddWithValue("@uf", cidade.uf);
            conexao.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro na atualização de Cidade");
            }
            finally
            {
                conexao.Close();
            }
        }

        public void Delete(Modelo.Cidade cidade)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Delete from Cidades where id=@id;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", cidade.id);
            conexao.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro na Remoção de Cidades");
            }
            finally
            {
                conexao.Close();
            }

        }

    }
}
