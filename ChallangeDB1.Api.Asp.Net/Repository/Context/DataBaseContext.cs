﻿using ChallangeDB1.Api.Asp.Net.Models;
using Microsoft.EntityFrameworkCore;

namespace ChallangeDB1.Api.Asp.Net.Repository.Context
{
    public class DataBaseContext: DbContext
    {
        // Propriedades que serão responsáveis pelo acesso às tabelas do BD

        public DbSet<AprendizModel> Aprendiz { get; set; }

        public DbSet<MentorModel> Mentor { get; set; }

        public DbSet<FormacaoAprendizModel> FormacaoAprendiz { get; set; }

        public DbSet<FormacaoMentorModel> FormacaoMentor { get; set; }

        public DbSet<InteresseModel> Interesse { get; set; }

        public DbSet<HabilidadeModel> Habilidade { get; set; }

        public DbSet<MatchModel> Match { get; set; }

        //Construtores

        public DataBaseContext(DbContextOptions options) : base(options)
        {
        }

        protected DataBaseContext()
        {
        }
    }
}
