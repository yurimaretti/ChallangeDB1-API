using ChallangeDB1.Api.Asp.Net.Models;
using ChallangeDB1.Api.Asp.Net.Repository.Context;
using System.Linq;

namespace ChallangeDB1.Api.Asp.Net.Repository
{
    public class InteresseRepository
    {
        private readonly DataBaseContext dataBaseContext;

        public InteresseRepository(DataBaseContext ctx)
        {
            dataBaseContext = ctx;
        }

        //Métodos API

        public IList<InteresseModel> ListarPorEmail(string email)
        {
            var lista = new List<InteresseModel>();

            lista = dataBaseContext.
                Interesse
                .Where(e => e.EmailAprdz == email)
                .ToList<InteresseModel>();

            return lista;
        }

        public InteresseModel BuscarPorId(int id)
        {
            var interesse = dataBaseContext.
                Interesse.
                Find(id);

            return interesse;
        }

        public void Inserir(InteresseModel interesse)
        {
            dataBaseContext.Interesse.Add(interesse);
            dataBaseContext.SaveChanges();
        }

        public void Alterar(InteresseModel interesse)
        {
            dataBaseContext.Interesse.Update(interesse);
            dataBaseContext.SaveChanges();
        }

        public void Excluir(int id)
        {
            var interesse = new InteresseModel(id);

            dataBaseContext.Interesse.Remove(interesse);
            dataBaseContext.SaveChanges();
        }
    }
}
