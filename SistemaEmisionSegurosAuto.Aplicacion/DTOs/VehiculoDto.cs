using System.ComponentModel.DataAnnotations;

namespace SistemaEmisionSegurosAuto.DTOs
{
    public class VehiculoDto
    {
        [Required]
        [MaxLength(20)]
        public string Placa { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Marca { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Modelo { get; set; } = string.Empty;

        [Range(1900, 2100)]
        public int Anio { get; set; }

        [Range(1, double.MaxValue)]
        public decimal ValorComercial { get; set; }
    }
}