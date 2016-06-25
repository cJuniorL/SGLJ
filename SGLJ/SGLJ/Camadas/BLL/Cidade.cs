using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGLJ.Camadas.BLL
{
    public class Cidade
    {
        public List<Modelo.Cidade> Select()
        {
            DAL.Cidades dalCidades = new DAL.Cidades();
            return dalCidades.Select();
        }

        public Modelo.Cidade SelectById(int id)
        {
            DAL.Cidades dalCidade = new DAL.Cidades();
            return dalCidade.SelectById(id);
        }

        public void Insert(Modelo.Cidade cidade)
        {
            DAL.Cidades dalCidade = new DAL.Cidades();
            dalCidade.Insert(cidade);
        }

        public void Update(Modelo.Cidade cidade)
        {
            DAL.Cidades dalCidade = new DAL.Cidades();
            dalCidade.Update(cidade);
        }

        public void Delete(Modelo.Cidade cidade)
        {
            DAL.Cidades dalCidade = new DAL.Cidades();
            dalCidade.Delete(cidade);
        }
    }
}
