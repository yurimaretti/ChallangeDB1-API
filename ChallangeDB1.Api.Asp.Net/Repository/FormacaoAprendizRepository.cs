using ChallangeDB1.Api.Asp.Net.Models;
using ChallangeDB1.Api.Asp.Net.Repository.Context;

namespace ChallangeDB1.Api.Asp.Net.Repository
{
    public class FormacaoAprendizRepository
    {
        private readonly DataBaseContext dataBaseContext;

        public FormacaoAprendizRepository(DataBaseContext ctx)
        {
            dataBaseContext = ctx;
        }

        //Métodos API

        public IList<FormacaoAprendizModel> ListarPorEmail(string email)
        {
            var lista = new List<FormacaoAprendizModel>();

            lista = dataBaseContext.
                FormacaoAprendiz
                .Where(e => e.EmailAprendiz == email)
                .ToList<FormacaoAprendizModel>();

            return lista;
        }

        public FormacaoAprendizModel BuscarPorId(int id)
        {
            var formacao = dataBaseContext.
                FormacaoAprendiz.
                Find(id);

            return formacao;
        }

        public void Inserir(FormacaoAprendizModel formacao)
        {
            dataBaseContext.FormacaoAprendiz.Add(formacao);
            dataBaseContext.SaveChanges();
        }

        public void Alterar(FormacaoAprendizModel formacao)
        {
            dataBaseContext.FormacaoAprendiz.Update(formacao);
            dataBaseContext.SaveChanges();
        }

        public void Excluir(int id)
        {
            var formacao = new FormacaoAprendizModel(id);

            dataBaseContext.FormacaoAprendiz.Remove(formacao);
            dataBaseContext.SaveChanges();
        }
    }
}
