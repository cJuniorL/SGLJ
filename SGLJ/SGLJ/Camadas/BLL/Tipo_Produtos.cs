using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGLJ.Camadas.BLL
{
    class Tipo_Produtos
    {
        public List<Modelo.Tipo_Produtos> Select()
        {
            DAL.Tipo_Produtos dalCli = new DAL.Tipo_Produtos();

            return dalCli.Select();
        }

        public List<Modelo.Tipo_Produtos> SelectById(int id)
        {
            DAL.Tipo_Produtos dalTipoProdutos = new DAL.Tipo_Produtos();

            return dalTipoProdutos.SelectById(id);
        }

        public void Insert(Modelo.Tipo_Produtos tipoProdutos)
        {
            DAL.Tipo_Produtos dalTipoProdutos = new DAL.Tipo_Produtos();
            //
            dalTipoProdutos.Insert(tipoProdutos);
        }

        public void Update(Modelo.Tipo_Produtos tipoProdutos)
        {
            DAL.Tipo_Produtos dalTipoProdutos = new DAL.Tipo_Produtos();
            dalTipoProdutos.Update(tipoProdutos);
        }

        public void Delete(Modelo.Tipo_Produtos tipoProdutos)
        {
            DAL.Tipo_Produtos dalTipoProdutos = new DAL.Tipo_Produtos();

            dalTipoProdutos.Delete(tipoProdutos);
        }
    }
}
