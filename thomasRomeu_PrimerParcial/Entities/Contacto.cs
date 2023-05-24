using System.ComponentModel.DataAnnotations;


namespace thomasRomeu_PrimerParcial.Entities
{
    public class Contacto
    {
        public Contacto() 
        {
            Telefonos = new List<Telefono>();
        }
        [Key]
        public int IdContacto { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string TipoDocumento { get; set; }

        public int NumeroDocumento { get; set; }

        public List<Telefono> Telefonos { get; set; }
    }
}
