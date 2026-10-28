using System.ComponentModel.DataAnnotations;

namespace SistemaEmisionSegurosAuto.DTOs
{
    public class EmitirPolizaDto
    {
        [Required]
        public int ClienteId { get; set; }

        [Required]
        public VehiculoDto Vehiculo { get; set; } = null!;

        [Required]
        [MinLength(1)]
        public List<int> CoberturasIds { get; set; } = new();
    }
}