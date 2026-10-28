namespace SistemaEmisionSegurosAuto.Domain.Entidades
{
    public class Cliente
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string Identificacion { get; set; } = string.Empty;

        public string Correo { get; set; } = string.Empty;

        public bool Activo { get; set; } = true;
    }
}