namespace Eventos.Platinum.Library.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string NombreUsuario { get; set; }
        public string Password { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] Salt { get; set; }
        public int? SmarterId { get; set; }
        public bool Activo { get; set; }
        public DateTime? FechaUltimoIngreso { get; set; }
        public int UsuarioTipoId { get; set; }
        public string NuevoPassword { get; set; }

    }
}
