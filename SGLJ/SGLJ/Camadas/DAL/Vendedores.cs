using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGLJ.Camadas.DAL
{
    public class Vendedores
    {
        private string strCon = Conexao.getConexao();

        public List<Modelo.Vendedores> Select()
        {
            List<Modelo.Vendedores> lstVendedores = new List<Modelo.Vendedores>();
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Select * from Vendedores";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            conexao.Open();
            try
            {
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    Modelo.Vendedores vendedor = new Modelo.Vendedores();
                    vendedor.id = Convert.ToInt32(reader["id"]);
                    vendedor.idCidade = Convert.ToInt32(reader["idCidade"]);
                    vendedor.nome = reader["nome"].ToString();
                    vendedor.telefone = reader["telefone"].ToString();
                    vendedor.celular = reader["celular"].ToString();
                    vendedor.endereco = reader["endereco"].ToString();
                    vendedor.rg = reader["rg"].ToString();
                    vendedor.cpf = reader["cpf"].ToString();
                    vendedor.salario = Convert.ToSingle(reader["salario"]);
                    lstVendedores.Add(vendedor);
                }
            }
            catch
            {
                Console.WriteLine("Deu erro na Seleção de Vendedores...");
            }
            finally
            {
                conexao.Close();
            }

            return lstVendedores;
        }


        public Modelo.Vendedores SelectById(int id)
        {
            Modelo.Vendedores vendedor = new Modelo.Vendedores();
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Select * from Vendedores where id=@id;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", id);
            conexao.Open();
            try
            {
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    vendedor.id = Convert.ToInt32(reader["id"]);
                    vendedor.idCidade = Convert.ToInt32(reader["idCidade"]);
                    vendedor.nome = reader["nome"].ToString();
                    vendedor.telefone = reader["telefone"].ToString();
                    vendedor.celular = reader["celular"].ToString();
                    vendedor.endereco = reader["endereco"].ToString();
                    vendedor.rg = reader["rg"].ToString();
                    vendedor.cpf = reader["cpf"].ToString();
                    vendedor.salario = Convert.ToSingle(reader["salario"]);
                }
            }
            catch
            {
                Console.WriteLine("Deu erro na Seleção de Vendedor por ID...");
            }
            finally
            {
                conexao.Close();
            }

            return vendedor;
        }

        public void Insert(Modelo.Vendedores vendedor)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Insert into Vendedores values (@idCidade, @nome, @telefone, @celular, @endereco, @rg, @cpf, @salario)";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@idCidade", vendedor.idCidade);
            cmd.Parameters.AddWithValue("@nome", vendedor.nome);
            cmd.Parameters.AddWithValue("@telefone", vendedor.telefone);
            cmd.Parameters.AddWithValue("@celular", vendedor.celular);
            cmd.Parameters.AddWithValue("@endereco", vendedor.endereco);
            cmd.Parameters.AddWithValue("@rg", vendedor.rg);
            cmd.Parameters.AddWithValue("@cpf", vendedor.cpf);
            cmd.Parameters.AddWithValue("@salario", vendedor.salario);
            conexao.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Deu erro na inserção de Vendedores...");
            }
            finally
            {
                conexao.Close();
            }
        }

        public void Update(Modelo.Vendedores vendedor)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Update Clientes set idCidade=@idCidade, nome=@nome, telefone=@telefone, celular=@celular, endereco=@endereco, rg=@rg ,cpf=@cpf, salario=@salario where id=@id;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", vendedor.id);
            cmd.Parameters.AddWithValue("@idCidade", vendedor.idCidade);
            cmd.Parameters.AddWithValue("@nome", vendedor.nome);
            cmd.Parameters.AddWithValue("@telefone", vendedor.telefone);
            cmd.Parameters.AddWithValue("@celular", vendedor.celular);
            cmd.Parameters.AddWithValue("@endereco", vendedor.endereco);
            cmd.Parameters.AddWithValue("@rg", vendedor.rg);
            cmd.Parameters.AddWithValue("@cpf", vendedor.cpf);
            cmd.Parameters.AddWithValue("@salario", vendedor.salario);
            conexao.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro na atualização do Vendedor");
            }
            finally
            {
                conexao.Close();
            }
        }

        public void Delete(Modelo.Vendedores vendedor)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Delete from Vendedores where id=@id;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", vendedor.id);
            conexao.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro na Remoção de Vendedor");
            }
            finally
            {
                conexao.Close();
            }

        }
    }
}
