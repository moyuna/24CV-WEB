using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _24CV_WEB.Models
{
    [Table("Curriculums")]
    public class Curriculum
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo nombre es requerido.")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres.")]
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        [Required(ErrorMessage = "El campo CURP es obligatorio.")]
        public string CURP { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "La fecha de nacimiento es obligatorio.")]
        public DateTime FechaNacimiento { get; set; }
        public string Dirección { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }
        [Range(0,100)]
        public int PorcentajeIngles { get; set; }
        [NotMapped]
        public IFormFile? Foto { get; set; }
        public string RutaFoto { get; set; }

    }
}
