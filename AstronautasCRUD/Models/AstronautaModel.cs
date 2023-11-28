using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AstronautasCRUD.Models
{
    public class AstronautaModel
    {
        public int IdAstronauta { get; set; }

        public string? Foto { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio!")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "El campo Nacionalidad es obligatorio!")]
        public string? Nacionalidad { get; set; }

        [Required(ErrorMessage = "El campo Descripcion es obligatorio!")]
        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "El campo Fecha Nacimiento es obligatorio!")]
        public DateTime? FechaNacimiento { get; set; }


        public DateTime? FechaFallecimiento { get; set; }


        public int Edad { get; set; }

        public string? RedesSociales { get; set; }

        [Required(ErrorMessage = "El campo Detalles Misiones es obligatorio!")]
        public string? DetallesMisiones { get; set; }

        public bool Activo { get; set; }

        //Aqui se almacenara el archivo de la imagen que subamos
        [NotMapped]
        [Required(ErrorMessage = "Debe Adjuntar una Imagen para realizar esta accion!")]
        public IFormFile? File { get; set; }
    }
}
