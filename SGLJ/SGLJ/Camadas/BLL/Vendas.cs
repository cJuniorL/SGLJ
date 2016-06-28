using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGLJ.Camadas.BLL
{
    public class Vendas
    {
        public List<Modelo.Vendas> Select()
        {
            DAL.Vendas dalVendas = new DAL.Vendas();

            return dalVendas.Select();
        }

        public Modelo.Vendas SelectById(int id)
        {
            DAL.Vendas dalVendas = new DAL.Vendas();

            return dalVendas.SelectById(id);
        }

        public void Insert(Modelo.Vendas venda)
        {
            DAL.Vendas dalVendas = new DAL.Vendas();

            dalVendas.Insert(venda);
        }
    }
}
