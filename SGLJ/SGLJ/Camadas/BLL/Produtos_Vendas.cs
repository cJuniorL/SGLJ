using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGLJ.Camadas.BLL
{
    class Produtos_Vendas
    {
        public List<Modelo.Produtos_Vendas> Select()
        {
            DAL.Produtos_Vendas dalProdutoVendas = new DAL.Produtos_Vendas();
            return dalProdutoVendas.Select();
        }

        //public Modelo.Produtos_Vendas SelectById(int id)
        //{
        //    DAL.Produtos_Vendas dalProdutoVendas = new DAL.Produtos_Vendas();
        //    return dalProdutoVendas.SelectById(id);
        //}

        public void Insert(Modelo.Produtos_Vendas produtoVendas)
        {
            DAL.Produtos_Vendas dalProdutoVendas = new DAL.Produtos_Vendas();
            dalProdutoVendas.Insert(produtoVendas);
        }

        public void Update(Modelo.Produtos_Vendas produtoVendas)
        {
            DAL.Produtos_Vendas dalProdutoVendas = new DAL.Produtos_Vendas();
            dalProdutoVendas.Update(produtoVendas);
        }

        public void Delete(Modelo.Produtos_Vendas produtoVendas)
        {
            DAL.Produtos_Vendas dalProdutoVendas = new DAL.Produtos_Vendas();
            //dalProdutoVendas.Delete(produtoVendas);
        }
    }
}
