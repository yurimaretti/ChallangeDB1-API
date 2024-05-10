using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ChallangeDB1.Api.Asp.Net.Models
{
    [Table("T_DB1_HABILIDADES")]
    public class HabilidadeModel
    {
        //Atributos

        [Key]
        [Column("ID_HABILIDADE")]
        public int HabilidadeId { get; set; }

        [Column("AREA_HABILIDADE")]
        [Required]
        [StringLength(800)]
        public string AreaHabilidade { get; set; }

        //Chave Estrangeira - Foreign Key (FK)

        [ForeignKey("Mentor")]
        [Column("EMAIL_MENTOR")]
        [StringLength(70)]
        public string EmailMentor { get; set; }

        //Objetos - Navigation Objects

        [JsonIgnore]
        public MentorModel? Mentor { get; set; }

        //Construtores

        public HabilidadeModel()
        {
        }

        public HabilidadeModel(int habilidadeId)
        {
            HabilidadeId = habilidadeId;
        }

        public HabilidadeModel(string emailMentor)
        {
            EmailMentor = emailMentor;
        }

        public HabilidadeModel(int habilidadeId, string areaHabilidade, string emailMentor)
        {
            HabilidadeId = habilidadeId;
            AreaHabilidade = areaHabilidade;
            EmailMentor = emailMentor;
        }
    }
}
