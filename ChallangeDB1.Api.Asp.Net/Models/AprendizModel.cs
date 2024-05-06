namespace ChallangeDB1.Api.Asp.Net.Models
{
    public class AprendizModel
    {
        public string EmailAprendiz { get; set; }

        public string NomeAprendiz { get; set; }

        public string GeneroAprendiz { get; set; }

        public string SenhaAprendiz { get; set; }

        public AprendizModel(string emailAprendiz, string nomeAprendiz, string generoAprendiz, string senhaAprendiz)
        {
            EmailAprendiz = emailAprendiz;
            NomeAprendiz = nomeAprendiz;
            GeneroAprendiz = generoAprendiz;
            SenhaAprendiz = senhaAprendiz;
        }
    }
}
