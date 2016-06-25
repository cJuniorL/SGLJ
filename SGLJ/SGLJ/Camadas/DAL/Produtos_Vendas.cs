using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGLJ.Camadas.DAL
{
    class Produtos_Vendas
    {
        private string strCon = Conexao.getConexao();

        public List<Modelo.Produtos_Vendas> Select()
        {
            List<Modelo.Produtos_Vendas> lstProdutoVendas = new List<Modelo.Produtos_Vendas>();
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Select * from Produtos_Vendas";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            conexao.Open();
            try
            {
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    Modelo.Produtos_Vendas produtoVendas = new Modelo.Produtos_Vendas();
                    produtoVendas.idProdutos = Convert.ToInt32(reader["idProdutos"]);
                    produtoVendas.idVendas = Convert.ToInt32(reader["idVendas"]);
                    lstProdutoVendas.Add(produtoVendas);
                }
            }
            catch
            {
                Console.WriteLine("Deu erro na Seleção de Produtos_Vendas...");
            }
            finally
            {
                conexao.Close();
            }

            return lstProdutoVendas;
        }

        public void Insert(Modelo.Produtos_Vendas produtoVendas)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Insert into Produtos_Vendas values (@idProdutos, @idVendas)";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@idProdutos", produtoVendas.idProdutos);
            cmd.Parameters.AddWithValue("@idVendas", produtoVendas.idVendas);
            conexao.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Deu erro na inserção de Produto_Vendas...");
            }
            finally
            {
                conexao.Close();
            }
        }

        public void Update(Modelo.Produtos_Vendas produtoVendas)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Update Produtos_Vendas set idProdutos=@idProdutos, idVendas=@idVendas;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@idProdutos", produtoVendas.idProdutos);
            cmd.Parameters.AddWithValue("@idVendas", produtoVendas.idVendas);
            conexao.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro na atualização do Produtos_Vendas");
            }
            finally
            {
                conexao.Close();
            }
        }
        
        //public void Delete(Modelo.Produtos_Vendas produtoVendas)
        //{
        //    SqlConnection conexao = new SqlConnection(strCon);
        //    string sql = "Delete from Produtos_Vendas where id=@id;";
        //    SqlCommand cmd = new SqlCommand(sql, conexao);
        //    cmd.Parameters.AddWithValue("@idProdutos", produtoVendas.idProdutos);
        //    conexao.Open();
        //    try
        //    {
        //        cmd.ExecuteNonQuery();
        //    }
        //    catch
        //    {
        //        Console.WriteLine("Erro na Remoção de Produtos_Vendas");
        //    }
        //    finally
        //    {
        //        conexao.Close();
        //    }

        //}
        
    }
}
