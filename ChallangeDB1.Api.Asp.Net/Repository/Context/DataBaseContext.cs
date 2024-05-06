using ChallangeDB1.Api.Asp.Net.Models;
using Microsoft.EntityFrameworkCore;

namespace ChallangeDB1.Api.Asp.Net.Repository.Context
{
    public class DataBaseContext: DbContext
    {
        // Propriedades que serão responsáveis pelo acesso às tabelas do BD

        public DbSet<AprendizModel> Aprendiz { get; set; }

        //Construtores

        public DataBaseContext(DbContextOptions options) : base(options)
        {
        }

        protected DataBaseContext()
        {
        }
    }
}
