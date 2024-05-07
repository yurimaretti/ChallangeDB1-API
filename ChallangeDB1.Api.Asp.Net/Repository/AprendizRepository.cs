using ChallangeDB1.Api.Asp.Net.Models;
using ChallangeDB1.Api.Asp.Net.Repository.Context;

namespace ChallangeDB1.Api.Asp.Net.Repository
{
    public class AprendizRepository
    {
        private readonly DataBaseContext dataBaseContext;

        public AprendizRepository(DataBaseContext ctx)
        {
            dataBaseContext = ctx;
        }

        //Métodos API

        public IList<AprendizModel> Listar() 
        {
            var lista = new List<AprendizModel>();

            lista = dataBaseContext.
                Aprendiz.
                ToList<AprendizModel>();

            return lista;
        }

        public AprendizModel Buscar(string id) 
        {
            var aprendiz = dataBaseContext.
                Aprendiz.
                Find(id);

            return aprendiz;
        }

        public void Inserir(AprendizModel aprendiz)
        {
            dataBaseContext.Aprendiz.Add(aprendiz);
            dataBaseContext.SaveChanges();
        }

        public void Alterar(AprendizModel aprendiz)
        {
            dataBaseContext.Aprendiz.Update(aprendiz);
            dataBaseContext.SaveChanges();
        }

        public void Excluir(string id)
        {
            var aprendiz = new AprendizModel(id);

            dataBaseContext.Aprendiz.Remove(aprendiz);
            dataBaseContext.SaveChanges();
        }
    }
}
