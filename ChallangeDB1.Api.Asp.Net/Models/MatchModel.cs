using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ChallangeDB1.Api.Asp.Net.Models
{
    [Table("T_DB1_MATCH")]
    public class MatchModel
    {
        //Atributos

        [Key]
        [Column("ID_MATCH")]
        public int MatchId { get; set; }

        [Column("CURTIDA_APRENDIZ")]
        [Required]
        public int CurtidaAprendiz { get; set; }

        [Column("CURTIDA_MENTOR")]
        [Required]
        public int CurtidaMentor { get; set; }

        //Chave Estrangeira - Foreign Key (FK)

        [ForeignKey("Aprendiz")]
        [Column("EMAIL_APRDZ")]
        [StringLength(70)]
        public string EmailAprdz { get; set; }

        [ForeignKey("Mentor")]
        [Column("EMAIL_MENTOR")]
        [StringLength(70)]
        public string EmailMentor { get; set; }

        //Objetos - Navigation Objects

        [JsonIgnore]
        public AprendizModel? Aprendiz { get; set; }

        [JsonIgnore]
        public MentorModel? Mentor { get; set; }

        //Construtores

        public MatchModel()
        {
        }

        public MatchModel(int matchId)
        {
            MatchId = matchId;
        }

        public MatchModel(string emailAprdz, string emailMentor)
        {
            EmailAprdz = emailAprdz;
            EmailMentor = emailMentor;
        }

        public MatchModel(int matchId, int curtidaAprendiz, int curtidaMentor, string emailAprdz, string emailMentor)
        {
            MatchId = matchId;
            CurtidaAprendiz = curtidaAprendiz;
            CurtidaMentor = curtidaMentor;
            EmailAprdz = emailAprdz;
            EmailMentor = emailMentor;
        }
    }
}
