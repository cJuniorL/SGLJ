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

        public void Insert(Modelo.Produtos_Vendas produtoVendas)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Insert into Produtos_Vendas values (@idProdutos, @idVendas, @quantidade)";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@idProdutos", produtoVendas.idProdutos);
            cmd.Parameters.AddWithValue("@idVendas", produtoVendas.idVendas);
            cmd.Parameters.AddWithValue("@quantidade", produtoVendas.quantidade);
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

        public List<Modelo.Produtos_Vendas> SelectByVenda(int venda)
        {
            List<Modelo.Produtos_Vendas> lstProdutoVendas = new List<Modelo.Produtos_Vendas>();
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Select * from Produtos_Vendas where idVendas=@idVendas;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@idVendas", venda);
            conexao.Open();
            try
            {
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                Modelo.Produtos_Vendas produtoVendas = new Modelo.Produtos_Vendas();
                while (reader.Read())
                {
                    produtoVendas.idProdutos = Convert.ToInt32(reader["idProdutos"]);
                    produtoVendas.idVendas = Convert.ToInt32(reader["idVendas"]);
                    produtoVendas.quantidade = Convert.ToInt32(reader["quantidade"]);
                    lstProdutoVendas.Add(produtoVendas);
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

            return lstProdutoVendas;
        }
    }
}
