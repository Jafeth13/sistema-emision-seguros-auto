using System.ComponentModel.DataAnnotations;

namespace SistemaEmisionSegurosAuto.DTOs
{
    public class ClienteDto
    {

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Identificacion { get; set; }

        [Required]
        [EmailAddress]
        public string Correo { get; set; }

    }
}