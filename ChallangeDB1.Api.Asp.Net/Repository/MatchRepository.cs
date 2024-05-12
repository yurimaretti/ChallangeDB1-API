using ChallangeDB1.Api.Asp.Net.Models;
using ChallangeDB1.Api.Asp.Net.Repository.Context;

namespace ChallangeDB1.Api.Asp.Net.Repository
{
    public class MatchRepository
    {
        private readonly DataBaseContext dataBaseContext;

        public MatchRepository(DataBaseContext ctx)
        {
            dataBaseContext = ctx;
        }

        //Métodos API

        public IList<MatchModel> ListarPorAprdz(string emailAprdz)
        {
            var lista = new List<MatchModel>();
            
            lista = dataBaseContext.
                Match
                .Where(e => e.EmailAprdz == emailAprdz)
                .ToList<MatchModel>();
            
            return lista;
        }

        public IList<MatchModel> ListarPorMentor(string emailMentor)
        {
            var lista = new List<MatchModel>();
            
            lista = dataBaseContext.
                Match
                .Where(e => e.EmailMentor == emailMentor)
                .ToList<MatchModel>();
            
            return lista;
        }

        public MatchModel BuscarMatch(string emailAprdz, string emailMentor)
        {
            var match = dataBaseContext.
                Match.
                Where(a => a.EmailAprdz == emailAprdz).
                Where(m => m.EmailMentor == emailMentor).
                FirstOrDefault();
                
            return match;
        }

        public MatchModel BuscarPorId(int id)
        {
            var match = dataBaseContext.
                Match.
                Find(id);

            return match;
        }

        public void Inserir(MatchModel match)
        {
            dataBaseContext.Match.Add(match);
            dataBaseContext.SaveChanges();
        }

        public void Alterar(MatchModel match)
        {
            dataBaseContext.Match.Update(match);
            dataBaseContext.SaveChanges();
        }

        public void Excluir(int id)
        {
            var match = new MatchModel(id);

            dataBaseContext.Match.Remove(match);
            dataBaseContext.SaveChanges();
        }
    }
}
