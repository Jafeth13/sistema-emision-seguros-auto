namespace SistemaEmisionSegurosAuto.DTOs
{
    public class PolizaResponseDto
    {
        public int Id { get; set; }

        public string NumeroPoliza { get; set; } = string.Empty;

        public decimal PrimaTotal { get; set; }

        public decimal SumaAsegurada { get; set; }

        public DateTime FechaEmision { get; set; }
    }
}
