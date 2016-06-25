using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGLJ.Camadas.DAL
{
    class Tipo_Produtos
    {

        private string strCon = Conexao.getConexao();

        public List<Modelo.Tipo_Produtos> Select()
        {
            List<Modelo.Tipo_Produtos> lstTipoProdutos = new List<Modelo.Tipo_Produtos>();
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Select * from Tipo_Produtos";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            conexao.Open();
            try
            {
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    Modelo.Tipo_Produtos tipoProdutos = new Modelo.Tipo_Produtos();
                    tipoProdutos.id = Convert.ToInt32(reader[0].ToString());
                    tipoProdutos.descr = reader["descr"].ToString();
                    lstTipoProdutos.Add(tipoProdutos);
                }
            }
            catch
            {
                Console.WriteLine("Deu erro na Seleção de Tipo_Produtos...");
            }
            finally
            {
                conexao.Close();
            }

            return lstTipoProdutos;
        }

        public Modelo.Tipo_Produtos SelectById(int id)
        {
            Modelo.Tipo_Produtos tipoProdutos = new Modelo.Tipo_Produtos();
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Select * from Tipo_Produtos where id=@id;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", id);
            conexao.Open();
            try
            {
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    tipoProdutos.id = Convert.ToInt32(reader[0].ToString());
                    tipoProdutos.descr = reader["descr"].ToString();
                }
            }
            catch
            {
                Console.WriteLine("Deu erro na Seleção de Tipo_Produtos por ID...");
            }
            finally
            {
                conexao.Close();
            }

            return tipoProdutos;
        }

        public void Insert(Modelo.Tipo_Produtos tipoProdutos)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Insert into Tipo_Produtos values (@descr);";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@descr", tipoProdutos.descr);
            conexao.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Deu erro na inserção de Tipo_Produtos...");
            }
            finally
            {
                conexao.Close();
            }
        }

        public void Update(Modelo.Tipo_Produtos tipoProdutos)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Update Tipo_Produtos set descr=@descr, where id=@id";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", tipoProdutos.id);
            cmd.Parameters.AddWithValue("@descr", tipoProdutos.descr);
            conexao.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro na atualização de Tipo_Produtos");
            }
            finally
            {
                conexao.Close();
            }
        }

        public void Delete(Modelo.Tipo_Produtos tipoProdutos)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Delete from Tipo_Produtos where id=@id;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", tipoProdutos.id);
            conexao.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro na Remoção de Tipo_Produtos");
            }
            finally
            {
                conexao.Close();
            }

        }
    }
}
