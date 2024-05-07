using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChallangeDB1.Api.Asp.Net.Models
{
    [Table("T_DB1_MENTOR")]
    public class MentorModel
    {
        //Atributos

        [Key]
        [Column("EMAIL_MENTOR")]
        [StringLength(70)]
        public string EmailMentor { get; set; }

        [Column("NOME_MENTOR")]
        [Required]
        [StringLength(70)]
        public string NomeMentor { get; set; }

        [Column("GENERO_MENTOR")]
        [Required]
        [StringLength(22)]
        public string GeneroMentor { get; set; }

        [Column("SENHA_MENTOR")]
        [Required]
        [StringLength(50)]
        public string SenhaMentor { get; set; }

        ////Navigation properties
      


        //Construtores

        public MentorModel()
        {
        }

        public MentorModel(string emailMentor)
        {
            EmailMentor = emailMentor;
        }

        public MentorModel(string emailMentor, string nomeMentor, string generoMentor, string senhaMentor)
        {
            EmailMentor = emailMentor;
            NomeMentor = nomeMentor;
            GeneroMentor = generoMentor;
            SenhaMentor = senhaMentor;
        }
    }
}
