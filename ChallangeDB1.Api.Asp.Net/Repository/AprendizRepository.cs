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
                Include(m => m.Match).
                ToList<AprendizModel>();

            return lista;
        }

        public IList<MentorModel> ListarMentoresMatch(string emailAprdz)
        {
            // Buscar os aprendizes que atendem aos critérios de curtida
            var aprendizesComMatches = dataBaseContext.Aprendiz
                .Include(a => a.Match)
                .Where(a => a.EmailAprendiz == emailAprdz &&
                            a.Match.Any(m => m.CurtidaAprendiz == 1 && m.CurtidaMentor == 1))
                .ToList();

            // Extrair os emails dos mentores dos aprendizes encontrados
            var emailsMentores = aprendizesComMatches
                .SelectMany(a => a.Match.Where(m => m.CurtidaAprendiz == 1 && m.CurtidaMentor == 1)
                                        .Select(m => m.EmailMentor))
                .Distinct()
                .ToList();

            // Buscar os mentores correspondentes aos emails encontrados
            var mentores = dataBaseContext.Mentor
                .Where(m => emailsMentores.Contains(m.EmailMentor))
                .ToList();

            return mentores;
        }

        public IList<AprendizModel> ListarPorMatch()
        {
            var lista = new List<AprendizModel>();

            lista = dataBaseContext.
                Aprendiz.
                Include(f => f.FormacaoAprendiz).
                Include(i => i.Interesse).
                Include(m => m.Match).
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
                Where(i => i.EmailAprendiz == id).
                Include(m => m.Match).
                Where(m => m.EmailAprendiz == id).
                FirstOrDefault();

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
