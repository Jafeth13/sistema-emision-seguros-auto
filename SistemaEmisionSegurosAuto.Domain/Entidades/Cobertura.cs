namespace SistemaEmisionSegurosAuto.Entidades
{
    public class Cobertura
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public decimal MontoCobertura { get; set; }

        public bool Activo { get; set; } = true;

    }
}