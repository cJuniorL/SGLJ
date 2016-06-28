using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGLJ.Camadas.BLL
{
    public class Clientes
    {
        public List<Modelo.Clientes> Select()
        {
            DAL.Clientes dalClientes = new DAL.Clientes();
            return dalClientes.Select();
        }

        public Modelo.Clientes SelectById(int id)
        {
            DAL.Clientes dalClientes = new DAL.Clientes();
            return dalClientes.SelectById(id);
        }
        /*
        public Modelo.Clientes SelectByNome(string nome)
        {

            return null;
        }
        */
        public void Insert(Modelo.Clientes clientes)
        {
            DAL.Clientes dalClientes = new DAL.Clientes();
            dalClientes.Insert(clientes);
        }

        public void Update(Modelo.Clientes clientes)
        {
            DAL.Clientes dalClientes = new DAL.Clientes();
            dalClientes.Update(clientes);
        }

        public void Delete(Modelo.Clientes clientes)
        {
            DAL.Clientes dalClientes = new DAL.Clientes();
            dalClientes.Delete(clientes);
        }
    }
}
