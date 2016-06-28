using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGLJ.Camadas.DAL
{
    public class Vendas
    {
        private string strCon = Conexao.getConexao();

        public List<Modelo.Vendas> Select()
        {
            List<Modelo.Vendas> lstVendas = new List<Modelo.Vendas>();
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Select * from Vendas";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            conexao.Open();
            try
            {
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    Modelo.Vendas vendas = new Modelo.Vendas();
                    vendas.id = Convert.ToInt32(reader["id"]);
                    vendas.idVendedor = Convert.ToInt32(reader["idVendedores"]);
                    vendas.idCliente = Convert.ToInt32(reader["idClientes"]);
                    vendas.data = Convert.ToDateTime(reader["data"]);
                    vendas.total = Convert.ToSingle(reader["total"]);
                    lstVendas.Add(vendas);
                }
            }
            catch
            {
                Console.WriteLine("Deu erro na Seleção de Vendas...");
            }
            finally
            {
                conexao.Close();
            }

            return lstVendas;
        }


        public Modelo.Vendas SelectById(int id)
        {
            Modelo.Vendas vendas = new Modelo.Vendas();
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Select * from Vendas where id=@id;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", id);
            conexao.Open();
            try
            {
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    vendas.id = Convert.ToInt32(reader["id"]);
                    vendas.idVendedor = Convert.ToInt32(reader["idVendedores"]);
                    vendas.idCliente = Convert.ToInt32(reader["idClientes"]);
                    vendas.data = Convert.ToDateTime(reader["data"]);
                    vendas.total = Convert.ToSingle(reader["total"]);
                }
            }
            catch
            {
                Console.WriteLine("Deu erro na Seleção de Vendas por ID...");
            }
            finally
            {
                conexao.Close();
            }

            return vendas;
        }

        public Modelo.Vendas SelectByTime(DateTime time)
        {
            Modelo.Vendas vendas = new Modelo.Vendas();
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Select * from Vendas where data=@data;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@data", time);
            conexao.Open();
            try
            {
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    vendas.id = Convert.ToInt32(reader["id"]);
                    vendas.idVendedor = Convert.ToInt32(reader["idVendedores"]);
                    vendas.idCliente = Convert.ToInt32(reader["idClientes"]);
                    vendas.data = Convert.ToDateTime(reader["data"]);
                    vendas.total = Convert.ToSingle(reader["total"]);
                }
            }
            catch
            {
                Console.WriteLine("Deu erro na Seleção de Vendas por ID...");
            }
            finally
            {
                conexao.Close();
            }

            return vendas;
        }

        public void Insert(Modelo.Vendas vendas)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Insert into Vendas values (@idVendedores, @idClientes, @data, @total)";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@idVendedores", vendas.idVendedor);
            cmd.Parameters.AddWithValue("@idClientes", vendas.idCliente);
            cmd.Parameters.AddWithValue("@data", vendas.data);
            cmd.Parameters.AddWithValue("@total", vendas.total);
            conexao.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Deu erro na inserção de Venda...");
            }
            finally
            {
                conexao.Close();
            }
        }
        ///Não se deve EDITAR e REMOVER uma venda, afim de promover maior integridade no sistema.
       
    }
}