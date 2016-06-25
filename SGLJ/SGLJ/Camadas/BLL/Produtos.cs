using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGLJ.Camadas.BLL
{
    class Produtos
    {
        public List<Modelo.Produtos> Select()
        {
            DAL.Produtos dalProdutos = new DAL.Produtos();
            return dalProdutos.Select();
        }

        public Modelo.Produtos SelectById(int id)
        {
            DAL.Produtos dalProdutos = new DAL.Produtos();
            return dalProdutos.SelectById(id);
        }

        public void Insert(Modelo.Produtos produtos)
        {
            DAL.Produtos dalProdutos = new DAL.Produtos();
            dalProdutos.Insert(produtos);
        }

        public void Update(Modelo.Produtos produtos)
        {
            DAL.Produtos dalProdutos = new DAL.Produtos();
            dalProdutos.Update(produtos);
        }

        public void Delete(Modelo.Produtos produtos)
        {
            DAL.Produtos dalProdutos = new DAL.Produtos();
            dalProdutos.Delete(produtos);
        }
    }
}
