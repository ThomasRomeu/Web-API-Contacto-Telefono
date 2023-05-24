using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace thomasRomeu_PrimerParcial.Entities
{
    public class Telefono
    {
        [Key]
        public int IdTelefono { get; set; }

        public string TipoTelefono { get; set; }

        public int NumeroTelefono { get; set; }

        [ForeignKey("Contacto")]
        public int ContactoId { get; set; }

        public Contacto Contacto { get; set; }
    }
}
