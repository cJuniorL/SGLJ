using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGLJ.Camadas.BLL
{
    public class RemoverProduto
    {
        static public void remover(int idProd, int quantidade)
        {
            Produtos bllProdutos = new Produtos();
            Modelo.Produtos produto = bllProdutos.SelectById(idProd);
            produto.quantidade -= quantidade;
            bllProdutos.Update(produto);

        }
    }
}
