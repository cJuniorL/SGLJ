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

        //private string strCon = Conexao.getConexao();

        //public List<Modelo.Tipo_Produtos> Select()
        //{
        //    List<Modelo.Tipo_Produtos> lstTipoProdutos = new List<Modelo.Tipo_Produtos>();
        //    SqlConnection conexao = new SqlConnection(strCon);
        //    string sql = "Select * from Tipo_Produtos";
        //    SqlCommand cmd = new SqlCommand(sql, conexao);
        //    conexao.Open();
        //    try
        //    {
        //        SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        //        while (reader.Read())
        //        {
        //            MODEL.Cliente cliente = new MODEL.Cliente();
        //            cliente.id = Convert.ToInt32(reader[0].ToString());
        //            cliente.nome = reader["nome"].ToString();
        //            cliente.endereco = reader["endereco"].ToString();
        //            cliente.cidade = reader["cidade"].ToString();
        //            cliente.estado = reader["estado"].ToString();
        //            cliente.aniversario = Convert.ToDateTime(reader["aniversario"].ToString());
        //            lstCliente.Add(cliente);
        //        }
        //    }
        //    catch
        //    {
        //        Console.WriteLine("Deu erro na Seleção de Clientes...");
        //    }
        //    finally
        //    {
        //        conexao.Close();
        //    }

        //    return lstCliente;
        //}
    }
}
