using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGLJ.Camadas.Modelo
{
    public class Clientes
    {
        public int id { get; set; }
        public int idCidade { get; set; }
        public int telefone { get; set; }
        public int celular { get; set; }
        public string endereco { get; set; }
        public int cpf { get; set; }
        public string email { get; set; }
    }
}
