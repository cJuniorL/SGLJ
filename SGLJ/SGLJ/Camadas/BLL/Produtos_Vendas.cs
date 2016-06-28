using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGLJ.Camadas.BLL
{
    class Produtos_Vendas
    {
        public void Insert(Modelo.Produtos_Vendas produtoVendas)
        {
            DAL.Produtos_Vendas dalProdutoVendas = new DAL.Produtos_Vendas();
            dalProdutoVendas.Insert(produtoVendas);
        }

        public List<Modelo.Produtos_Vendas> SelectByVenda(int venda)
        {
            DAL.Produtos_Vendas dalProdutoVendas = new DAL.Produtos_Vendas();
            return dalProdutoVendas.SelectByVenda(venda);
        }
    }
}
