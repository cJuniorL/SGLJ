using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGLJ.Camadas.DAL
{
    public class Clientes
    {
        private string strCon = Conexao.getConexao();

        public List<Modelo.Clientes> Select()
        {
            List<Modelo.Clientes> lstClientes = new List<Modelo.Clientes>();
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Select * from Clientes";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            conexao.Open();
            try
            {
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    Modelo.Clientes clientes = new Modelo.Clientes();
                    clientes.id = Convert.ToInt32(reader["id"]);
                    clientes.idCidade = Convert.ToInt32(reader["idCidade"]);
                    clientes.nome = reader["nome"].ToString();
                    clientes.telefone = reader["telefone"].ToString();
                    clientes.celular = reader["celular"].ToString();
                    clientes.endereco = reader["endereco"].ToString();
                    clientes.cpf = reader["cpf"].ToString();
                    clientes.email = reader["email"].ToString();
                    lstClientes.Add(clientes);
                }
            }
            catch
            {
                Console.WriteLine("Deu erro na Seleção de Clientes...");
            }
            finally
            {
                conexao.Close();
            }

            return lstClientes;
        }


        public Modelo.Clientes SelectById(int id)
        {
            Modelo.Clientes cliente = new Modelo.Clientes();
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Select * from Clientes where id=@id;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", id);
            conexao.Open();
            try
            {
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    cliente.id = Convert.ToInt32(reader["id"]);
                    cliente.idCidade = Convert.ToInt32(reader["idCidade"]);
                    cliente.nome = reader["nome"].ToString();
                    cliente.telefone = reader["telefone"].ToString();
                    cliente.celular = reader["celular"].ToString();
                    cliente.endereco = reader["endereco"].ToString();
                    cliente.cpf = reader["cpf"].ToString();
                    cliente.email = reader["email"].ToString();
                }
            }
            catch
            {
                Console.WriteLine("Deu erro na Seleção de Cliente por ID...");
            }
            finally
            {
                conexao.Close();
            }

            return cliente;
        }

        public void Insert(Modelo.Clientes cliente)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Insert into Clientes values (@idCidade, @nome, @telefone, @celular, @endereco, @cpf, @email)";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@idCidade", cliente.idCidade);
            cmd.Parameters.AddWithValue("@nome", cliente.nome);
            cmd.Parameters.AddWithValue("@telefone", cliente.telefone);
            cmd.Parameters.AddWithValue("@celular", cliente.celular);
            cmd.Parameters.AddWithValue("@endereco", cliente.endereco);
            cmd.Parameters.AddWithValue("@cpf", cliente.cpf);
            cmd.Parameters.AddWithValue("@email", cliente.email);
            conexao.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Deu erro na inserção de Cliente...");
            }
            finally
            {
                conexao.Close();
            }
        }

        public void Update(Modelo.Clientes cliente)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Update Clientes set idCidade=@idCidade, nome=@nome, telefone=@telefone, celular=@celular, endereco=@endereco, cpf=@cpf, email=@email where id=@id;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", cliente.id);
            cmd.Parameters.AddWithValue("@idCidade", cliente.idCidade);
            cmd.Parameters.AddWithValue("@nome", cliente.nome);
            cmd.Parameters.AddWithValue("@telefone", cliente.telefone);
            cmd.Parameters.AddWithValue("@celular", cliente.celular);
            cmd.Parameters.AddWithValue("@endereco", cliente.endereco);
            cmd.Parameters.AddWithValue("@cpf", cliente.cpf);
            cmd.Parameters.AddWithValue("@email", cliente.email);
            conexao.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro na atualização do Cliente");
            }
            finally
            {
                conexao.Close();
            }
        }

        public void Delete(Modelo.Clientes cliente)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Delete from Clientes where id=@id;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", cliente.id);
            conexao.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro na Remoção de Clientes");
            }
            finally
            {
                conexao.Close();
            }

        }
    }
}
