using thomasRomeu_PrimerParcial.Entities;

namespace thomasRomeu_PrimerParcial.Dto
{
    public class ContactoDto
    {
        public ContactoDto()
        {
            Telefonos = new List<TelefonoDto>();
        }
        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string TipoDocumento { get; set; }

        public int NumeroDocumento { get; set; }

        public List<TelefonoDto> Telefonos { get; set; }
    }
}
