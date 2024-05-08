using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChallangeDB1.Api.Asp.Net.Models
{
    [Table("T_DB1_FORM_MENTOR")]
    public class FormacaoMentorModel
    {
        //Atributos

        [Key]
        [Column("ID_FORM_MENTOR")]
        public int FormMentorId { get; set; }

        [Column("GRAU_INSTRUCAO")]
        [Required]
        [StringLength(50)]
        public string NivelFormMentor { get; set; }

        [Column("CURSO_MENTOR")]
        [Required]
        [StringLength(70)]
        public string CursoMentor { get; set; }

        [Column("INST_MENTOR")]
        [Required]
        [StringLength(70)]
        public string InstMentor { get; set; }

        //Chave Estrangeira - Foreign Key (FK)

        [ForeignKey("Mentor")]
        [Column("EMAIL_MENTOR")]
        [StringLength(70)]
        public string EmailMentor { get; set; }

        //Objetos - Navigation Objects

        [JsonIgnore]
        public MentorModel? Mentor { get; set; }

        //Construtores

        public FormacaoMentorModel()
        {
        }

        public FormacaoMentorModel(int formMentorId)
        {
            FormMentorId = formMentorId;
        }

        public FormacaoMentorModel(string emailMentor)
        {
            EmailMentor = emailMentor;
        }

        public FormacaoMentorModel(int formMentorId, string nivelFormMentor, string cursoMentor, string instMentor, string emailMentor)
        {
            FormMentorId = formMentorId;
            NivelFormMentor = nivelFormMentor;
            CursoMentor = cursoMentor;
            InstMentor = instMentor;
            EmailMentor = emailMentor;
        }
    }
}
