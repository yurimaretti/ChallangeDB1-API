using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ChallangeDB1.Api.Asp.Net.Models
{
    [Table("T_DB1_INTERESSES")]
    public class InteresseModel
    {
        //Atributos

        [Key]
        [Column("ID_INTERESSE")]
        public int InteresseId { get; set; }

        [Column("AREA_INTERESSE")]
        [Required]
        [StringLength(800)]
        public string AreaInteresse { get; set; }

        //Chave Estrangeira - Foreign Key (FK)

        [ForeignKey("Aprendiz")]
        [Column("EMAIL_APRDZ")]
        [StringLength(70)]
        public string EmailAprdz { get; set; }

        //Objetos - Navigation Objects

        [JsonIgnore]
        public AprendizModel? Aprendiz { get; set; }

        //Construtores

        public InteresseModel()
        {
        }

        public InteresseModel(int interesseId)
        {
            InteresseId = interesseId;
        }

        public InteresseModel(string emailAprdz)
        {
            EmailAprdz = emailAprdz;
        }

        public InteresseModel(int interesseId, string areaInteresse, string emailAprdz)
        {
            InteresseId = interesseId;
            AreaInteresse = areaInteresse;
            EmailAprdz = emailAprdz;
        }
    }
}
