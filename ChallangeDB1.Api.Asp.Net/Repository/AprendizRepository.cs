using ChallangeDB1.Api.Asp.Net.Models;
using ChallangeDB1.Api.Asp.Net.Repository.Context;
using Microsoft.EntityFrameworkCore;

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
                Include(f => f.FormacaoAprendiz).
                Include(i => i.Interesse).
                ToList<AprendizModel>();

            return lista;
        }

        public AprendizModel Buscar(string id) 
        {
            var aprendiz = new AprendizModel();

            aprendiz = dataBaseContext.
                Aprendiz.
                Include(f => f.FormacaoAprendiz).
                Where(f => f.EmailAprendiz == id).
                Include(i => i.Interesse).
                Where(i => i.EmailAprendiz == id)
                .FirstOrDefault();

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
