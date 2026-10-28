using SistemaEmisionSegurosAuto.Domain.Entidades;

namespace SistemaEmisionSegurosAuto.Entidades
{
    public class Poliza
    {
        public int Id { get; set; }

        public string NumeroPoliza { get; set; } = string.Empty;

        public DateTime FechaEmision { get; set; }

        public decimal SumaAsegurada { get; set; }

        public decimal PrimaTotal { get; set; }

        public int ClienteId { get; set; }

        public int VehiculoId { get; set; }

        public Cliente Cliente { get; set; } = null!;

        public Vehiculo Vehiculo { get; set; } = null!;
    }
}