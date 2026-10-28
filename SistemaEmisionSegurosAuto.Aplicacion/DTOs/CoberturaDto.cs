using System.ComponentModel.DataAnnotations;

namespace SistemaEmisionSegurosAuto.DTOs
{
    public class CoberturaDto
    {
        [Required]
        public string Nombre { get; set; }

        [Range(1, 999999)]
        public decimal MontoCobertura { get; set; }
    }
}