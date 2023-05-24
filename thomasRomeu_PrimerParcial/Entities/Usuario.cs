using System.ComponentModel.DataAnnotations;

namespace thomasRomeu_PrimerParcial.Entities
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }

        public string nombreUsuario { get; set; }

        public string password { get; set; }
    }
}
