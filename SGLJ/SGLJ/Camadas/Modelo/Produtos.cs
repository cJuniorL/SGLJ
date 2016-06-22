using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGLJ.Camadas.Modelo
{
    public class Produtos
    {
        public int id { get; set; }
        public int idTipo_Produto { get; set; }
        public string descr { get; set; }
        public int quantidade { get; set; }
        public float valor { get; set; }
    }
}
