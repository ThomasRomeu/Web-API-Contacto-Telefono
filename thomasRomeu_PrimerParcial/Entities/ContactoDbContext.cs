using Microsoft.EntityFrameworkCore;


namespace thomasRomeu_PrimerParcial.Entities
{
    public class ContactoDbContext : DbContext
    {
        public ContactoDbContext() 
        { 

        }

        public ContactoDbContext(DbContextOptions<ContactoDbContext> options) : base(options) 
        { 

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
            => optionsBuilder.UseSqlServer("server=localhost;Database=DBContactos;Trusted_Connection=True; TrustServerCertificate=True");


        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Contacto> Contactos { get; set; }
        public virtual DbSet<Telefono> Telefonos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasData
                (
                new Entities.Usuario
                {
                    IdUsuario = 1,
                    nombreUsuario = "tromeu",
                    password = "4622"
                });

            modelBuilder.Entity<Contacto>().HasData
                (
                new Contacto
                {
                    IdContacto = 1,
                    Nombre = "Ludmila",
                    Apellido = "Ferez",
                    TipoDocumento = "DNI",
                    NumeroDocumento = 42442367
                },
                new Contacto
                {
                    IdContacto = 2,
                    Nombre = "Gianluca",
                    Apellido = "Romeu",
                    TipoDocumento = "DNI",
                    NumeroDocumento = 42567249
                },
                new Contacto
                {
                    IdContacto = 3,
                    Nombre = "Joaquin",
                    Apellido = "Romeu",
                    TipoDocumento = "DNI",
                    NumeroDocumento = 43190425
                });

            modelBuilder.Entity<Telefono>().HasData
                (
                new Telefono
                {
                    IdTelefono = 1,
                    ContactoId = 1,
                    TipoTelefono = "Celular",
                    NumeroTelefono = 1125245672,
                },
                new Telefono
                {
                    IdTelefono = 2,
                    ContactoId = 2,
                    TipoTelefono = "Celular",
                    NumeroTelefono = 1125245672,
                },
                new Telefono
                {
                    IdTelefono = 3,
                    ContactoId = 3,
                    TipoTelefono = "Fijo",
                    NumeroTelefono = 46228527,
                });
        }


    }
}
