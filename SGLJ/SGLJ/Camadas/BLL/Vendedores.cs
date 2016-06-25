using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGLJ.Camadas.BLL
{
    public class Vendedores
    {
        public List<Modelo.Vendedores> Select()
        {
            DAL.Vendedores dalVendedores = new DAL.Vendedores();
            return dalVendedores.Select();
        }

        public Modelo.Vendedores SelectById(int id)
        {
            DAL.Vendedores dalVendedores = new DAL.Vendedores();
            return dalVendedores.SelectById(id);
        }

        public void Insert(Modelo.Vendedores vendedores)
        {
            DAL.Vendedores dalVendedores = new DAL.Vendedores();
            dalVendedores.Insert(vendedores);
        }

        public void Update(Modelo.Vendedores vendedores)
        {
            DAL.Vendedores dalVendedores = new DAL.Vendedores();
            dalVendedores.Update(vendedores);
        }

        public void Delete(Modelo.Vendedores vendedores)
        {
            DAL.Vendedores dalVendedores = new DAL.Vendedores();
            dalVendedores.Delete(vendedores);
        }
    }
}
