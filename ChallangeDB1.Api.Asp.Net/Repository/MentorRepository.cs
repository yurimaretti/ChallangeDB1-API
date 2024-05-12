using ChallangeDB1.Api.Asp.Net.Models;
using ChallangeDB1.Api.Asp.Net.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace ChallangeDB1.Api.Asp.Net.Repository
{
    public class MentorRepository
    {
        private readonly DataBaseContext dataBaseContext;

        public MentorRepository(DataBaseContext ctx)
        {
            dataBaseContext = ctx;
        }

        //Métodos API

        public IList<MentorModel> Listar()
        {
            var lista = new List<MentorModel>();

            lista = dataBaseContext.
                Mentor.
                Include(f => f.FormacaoMentor).
                Include(h => h.Habilidade).
                Include(m => m.Match).
                ToList<MentorModel>();

            return lista;
        }

        public MentorModel Buscar(string id)
        {
            var mentor = new MentorModel();

            mentor = dataBaseContext.
                Mentor.
                Include(f => f.FormacaoMentor).
                Where(f => f.EmailMentor == id).
                Include(h => h.Habilidade).
                Where(h => h.EmailMentor == id).
                Include(m => m.Match).
                Where(m => m.EmailMentor == id).
                FirstOrDefault();

            return mentor;
        }

        public void Inserir(MentorModel mentor)
        {
            dataBaseContext.Mentor.Add(mentor);
            dataBaseContext.SaveChanges();
        }

        public void Alterar(MentorModel mentor)
        {
            dataBaseContext.Mentor.Update(mentor);
            dataBaseContext.SaveChanges();
        }

        public void Excluir(string id)
        {
            var mentor = new MentorModel(id);

            dataBaseContext.Mentor.Remove(mentor);
            dataBaseContext.SaveChanges();
        }
    }
}
