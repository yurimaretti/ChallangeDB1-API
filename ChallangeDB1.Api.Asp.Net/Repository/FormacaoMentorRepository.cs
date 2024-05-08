using ChallangeDB1.Api.Asp.Net.Models;
using ChallangeDB1.Api.Asp.Net.Repository.Context;

namespace ChallangeDB1.Api.Asp.Net.Repository
{
    public class FormacaoMentorRepository
    {
        private readonly DataBaseContext dataBaseContext;

        public FormacaoMentorRepository(DataBaseContext ctx)
        {
            dataBaseContext = ctx;
        }

        //Métodos API

        public IList<FormacaoMentorModel> ListarPorEmail(string email)
        {
            var lista = new List<FormacaoMentorModel>();

            lista = dataBaseContext.
                FormacaoMentor
                .Where(e => e.EmailMentor == email)
                .ToList<FormacaoMentorModel>();

            return lista;
        }

        public FormacaoMentorModel BuscarPorId(int id)
        {
            var formacao = dataBaseContext.
                FormacaoMentor.
                Find(id);

            return formacao;
        }

        public void Inserir(FormacaoMentorModel formacao)
        {
            dataBaseContext.FormacaoMentor.Add(formacao);
            dataBaseContext.SaveChanges();
        }

        public void Alterar(FormacaoMentorModel formacao)
        {
            dataBaseContext.FormacaoMentor.Update(formacao);
            dataBaseContext.SaveChanges();
        }

        public void Excluir(int id)
        {
            var formacao = new FormacaoMentorModel(id);

            dataBaseContext.FormacaoMentor.Remove(formacao);
            dataBaseContext.SaveChanges();
        }
    }
}
