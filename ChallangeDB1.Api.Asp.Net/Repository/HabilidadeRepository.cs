using ChallangeDB1.Api.Asp.Net.Models;
using ChallangeDB1.Api.Asp.Net.Repository.Context;

namespace ChallangeDB1.Api.Asp.Net.Repository
{
    public class HabilidadeRepository
    {
        private readonly DataBaseContext dataBaseContext;

        public HabilidadeRepository(DataBaseContext ctx)
        {
            dataBaseContext = ctx;
        }

        //Métodos API

        public HabilidadeModel ListarPorEmail(string email)
        {
            var habilidade = dataBaseContext
                .Habilidade
                .Where(e => e.EmailMentor == email)
                .FirstOrDefault();

            return habilidade;
        }

        public HabilidadeModel BuscarPorId(int id)
        {
            var habilidade = dataBaseContext.
                Habilidade.
                Find(id);

            return habilidade;
        }

        public void Inserir(HabilidadeModel habilidade)
        {
            dataBaseContext.Habilidade.Add(habilidade);
            dataBaseContext.SaveChanges();
        }

        public void Alterar(HabilidadeModel habilidade)
        {
            dataBaseContext.Habilidade.Update(habilidade);
            dataBaseContext.SaveChanges();
        }

        public void Excluir(int id)
        {
            var habilidade = new HabilidadeModel(id);

            dataBaseContext.Habilidade.Remove(habilidade);
            dataBaseContext.SaveChanges();
        }
    }
}
