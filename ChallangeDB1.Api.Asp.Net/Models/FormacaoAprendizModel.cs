using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ChallangeDB1.Api.Asp.Net.Models
{
    [Table("T_DB1_FORM_APRDZ")]
    public class FormacaoAprendizModel
    {
        //Atributos

        [Key]
        [Column("ID_FORM_APRZ")]
        public int FormAprdzId { get; set; }

        [Column("GRAU_INSTRUCAO")]
        [Required]
        [StringLength(50)]
        public string NivelFormAprdz { get; set; }

        [Column("CURSO_APRZ")]
        [Required]
        [StringLength(70)]
        public string CursoAprdz { get; set; }

        [Column("INST_APRDZ")]
        [Required]
        [StringLength(70)]
        public string InstAprdz { get; set; }

        //Chave Estrangeira - Foreign Key (FK)

        [ForeignKey("Aprendiz")]
        [Column("EMAIL_APRDZ")]
        [StringLength(70)]
        public string EmailAprendiz { get; set; }

        //Objetos - Navigation Objects

        [JsonIgnore]
        public AprendizModel? Aprendiz { get; set; }

        //Construtores

        public FormacaoAprendizModel()
        {
        }

        public FormacaoAprendizModel(int formAprdzId)
        {
            FormAprdzId = formAprdzId;
        }

        public FormacaoAprendizModel(string emailAprendiz)
        {
            EmailAprendiz = emailAprendiz;
        }

        public FormacaoAprendizModel(int formAprdzId, string nivelFormAprdz, string cursoAprdz, string instAprdz, string emailAprendiz)
        {
            FormAprdzId = formAprdzId;
            NivelFormAprdz = nivelFormAprdz;
            CursoAprdz = cursoAprdz;
            InstAprdz = instAprdz;
            EmailAprendiz = emailAprendiz;
        }
    }
}
