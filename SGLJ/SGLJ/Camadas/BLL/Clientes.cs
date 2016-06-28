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

        public List<Modelo.Clientes> lstSelectById(int id)
        {
            DAL.Clientes dalClientes = new DAL.Clientes();
            return dalClientes.lstSelectById(id);
        }

        public List<Modelo.Clientes> SelectByNome(string nome)
        {
            DAL.Clientes dalClientes = new DAL.Clientes();
            return dalClientes.SelectByNome(nome);
        }
        
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
