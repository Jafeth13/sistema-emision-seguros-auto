namespace SistemaEmisionSegurosAuto.Entidades
{
    public class PolizaCobertura
    {
        public int PolizaId { get; set; }

        public int CoberturaId { get; set; }

        public Poliza Poliza { get; set; } = null!;

        public Cobertura Cobertura { get; set; } = null!;
    }
}