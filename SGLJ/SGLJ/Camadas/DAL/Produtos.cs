using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGLJ.Camadas.DAL
{
    class Produtos
    {
        private string strCon = Conexao.getConexao();

        public List<Modelo.Produtos> Select()
        {
            List<Modelo.Produtos> lstProdutos= new List<Modelo.Produtos>();
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Select * from Produtos";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            conexao.Open();
            try
            {
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    Modelo.Produtos produtos = new Modelo.Produtos();
                    produtos.id = Convert.ToInt32(reader["id"]);
                    produtos.descr = reader["descr"].ToString();
                    produtos.idTipo_Produto = Convert.ToInt32(reader["idTipo_Produtos"]);
                    produtos.quantidade = Convert.ToInt32(reader["quantidade"]);
                    produtos.valor = Convert.ToSingle(reader["valor"]);
                    lstProdutos.Add(produtos);
                }
            }
            catch
            {
                Console.WriteLine("Deu erro na Seleção de Produtos...");
            }
            finally
            {
                conexao.Close();
            }

            return lstProdutos;
        }

        public Modelo.Produtos SelectById(int id)
        {
            Modelo.Produtos produtos = new Modelo.Produtos();
            List<Modelo.Produtos> lstProdutos = new List<Modelo.Produtos>();
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Select * from Produtos where id=@id;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", id);
            conexao.Open();
            try
            {
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    produtos.id = Convert.ToInt32(reader["id"]);
                    produtos.descr = reader["descr"].ToString();
                    produtos.idTipo_Produto = Convert.ToInt32(reader["idTipo_Produtos"]);
                    produtos.quantidade = Convert.ToInt32(reader["quantidade"]);
                    produtos.valor = Convert.ToSingle(reader["valor"]);
                }
            }
            catch
            {
                Console.WriteLine("Deu erro na Seleção de Produtos por ID...");
            }
            finally
            {
                conexao.Close();
            }

            return produtos;
        }

        public void Insert(Modelo.Produtos produtos)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Insert into Produtos values (@idTipo_Produtos, @descr, @quantidade, @valor)";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@idTipo_Produtos", produtos.idTipo_Produto);
            cmd.Parameters.AddWithValue("@descr", produtos.descr);
            cmd.Parameters.AddWithValue("@quantidade", produtos.quantidade);
            cmd.Parameters.AddWithValue("@valor", produtos.valor);
            conexao.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Deu erro na inserção de Produtos...");
            }
            finally
            {
                conexao.Close();
            }
        }


        public void Update(Modelo.Produtos produtos)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Update Produtos set idTipo_Produtos=@idTipo_Produtos, descr=@descr, quantidade=@quantidade, valor=@valor where id=@id;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", produtos.id);
            cmd.Parameters.AddWithValue("@idTipo_Produtos", produtos.idTipo_Produto);
            cmd.Parameters.AddWithValue("@descr", produtos.descr);
            cmd.Parameters.AddWithValue("@quantidade", produtos.quantidade);
            cmd.Parameters.AddWithValue("@valor", produtos.valor);
            conexao.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro na atualização de Produtos");
            }
            finally
            {
                conexao.Close();
            }
        }

        public void Delete(Modelo.Produtos produtos)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Delete from Produtos where id=@id;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", produtos.id);
            conexao.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro na Remoção de Produtos");
            }
            finally
            {
                conexao.Close();
            }

        }

    }
}
