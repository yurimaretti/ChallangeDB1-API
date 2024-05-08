using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ChallangeDB1.Api.Asp.Net.Models
{
    [Table("T_DB1_APRENDIZ")]
    public class AprendizModel
    {
        //Atributos

        [Key]
        [Column("EMAIL_APRDZ")]
        [StringLength(70)]
        public string EmailAprendiz { get; set; }

        [Column("NOME_APRDZ")]
        [Required]
        [StringLength(70)]
        public string NomeAprendiz { get; set; }

        [Column("GENERO_APRDZ")]
        [Required]
        [StringLength(22)]
        public string GeneroAprendiz { get; set; }

        [Column("SENHA_APRDZ")]
        [Required]
        [StringLength(50)]
        public string SenhaAprendiz { get; set; }

        //Navigation properties

        [JsonIgnore]
        public IList<FormacaoAprendizModel>? FormacaoAprendiz { get; set; }

        //Construtores

        public AprendizModel()
        {
        }

        public AprendizModel(string emailAprendiz)
        {
            EmailAprendiz = emailAprendiz;
        }

        public AprendizModel(string emailAprendiz, string nomeAprendiz, string generoAprendiz, string senhaAprendiz)
        {
            EmailAprendiz = emailAprendiz;
            NomeAprendiz = nomeAprendiz;
            GeneroAprendiz = generoAprendiz;
            SenhaAprendiz = senhaAprendiz;
        }
    }
}
