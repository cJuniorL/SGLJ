using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGLJ.Camadas.Modelo
{
    public class Vendas
    {
        public int id { get; set; }
        public int idVendedor { get; set; }
        public int idCliente { get; set; }
        public DateTime data { get; set; }
        public float total { get; set; }
    }
}
