using AutoMapper;
using thomasRomeu_PrimerParcial.Dto;
using thomasRomeu_PrimerParcial.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Internal;

namespace thomasRomeu_PrimerParcial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ContactoController : ControllerBase
    {
        private ContactoDbContext _contactoDbContext;
        private IMapper _mapper;

        public ContactoController(ContactoDbContext contactoDbContext, IMapper mapper)
        {
            _contactoDbContext = contactoDbContext;
            _mapper = mapper;
        }

        // Obtengo todos los Contactos

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<ContactoDto>>> GetAll()
        {
            var result = await _contactoDbContext.Contactos.Include(x => x.Telefonos).ToListAsync();

            var mapper = _mapper.Map<List<ContactoDto>>(result);

            return Ok(mapper);
        }

        // Obtengo los Contactos segun su Nombre y Apellido

        [HttpGet("GetNombreApellido/{nombre}/{apellido}")]
        public async Task<ActionResult<ContactoDto>> GetNombre(string nombre, string apellido)
        {
            var result2 = await _contactoDbContext.Contactos.Include(x => x.Telefonos).SingleOrDefaultAsync(n => n.Nombre == nombre && n.Apellido == apellido);

            var mapper2 = _mapper.Map<ContactoDto>(result2);

            return Ok(mapper2);
        }

        //Obtengo los Contactos segun su Numero de Telefono

        [HttpGet("GetTelefono/{telefono}")]
        public async Task<ActionResult<ContactoDto>> GetTelefono(int telefono)
        {
            var result2 = await _contactoDbContext.Contactos.Include(x => x.Telefonos).FirstOrDefaultAsync(c => c.Telefonos.Any(t => t.NumeroTelefono == telefono));

            var mapper2 = _mapper.Map<ContactoDto>(result2);

            return Ok(mapper2);
        }

        // Creo un Contacto nuevo

        [HttpPost("CreateContacto")]
        public async Task<ActionResult> CreateContacto([FromBody] ContactoDto contactoDto)
        {
            try
            {
                var contacto = new Contacto
                {
                    Nombre = contactoDto.Nombre,
                    Apellido = contactoDto.Apellido,
                    TipoDocumento = contactoDto.TipoDocumento,
                    NumeroDocumento = contactoDto.NumeroDocumento,
                    Telefonos = contactoDto.Telefonos.Select(t => new Telefono
                    {
                        TipoTelefono = t.TipoTelefono,
                        NumeroTelefono = t.NumeroTelefono
                    }).ToList()
                    
                };

                _contactoDbContext.Contactos.Add(contacto);
                var result = await _contactoDbContext.SaveChangesAsync();

                if (result > 0)
                {
                    return StatusCode(201);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // Añado un nuevo Numero de Telefono a un Contacto ya existente

        [HttpPost("CreateTelefono{nombre}/{apellido}/telefonos")]
        public async Task<IActionResult> CreateTelefono(string nombre, string apellido, [FromBody] TelefonoDto telefonoDto)
        {
            var contactoExistente = await _contactoDbContext.Contactos
                .Include(c => c.Telefonos)
                .FirstOrDefaultAsync(c => c.Nombre == nombre && c.Apellido == apellido);

            if (contactoExistente == null)
            {
                return NotFound();
            }

            var nuevoTelefono = new Telefono
            {
                TipoTelefono = telefonoDto.TipoTelefono,
                NumeroTelefono = telefonoDto.NumeroTelefono
            };

            contactoExistente.Telefonos.Add(nuevoTelefono);
            await _contactoDbContext.SaveChangesAsync();

            return Ok();
        }

        // Elimino un Contacto

        [HttpDelete("Delete/{nombre}/{apellido}")]
        public async Task<ActionResult<ContactoDto>> Delete(string nombre, string apellido)
        {
            var result2 = await _contactoDbContext.Contactos.Include(x => x.Telefonos).SingleOrDefaultAsync(n => n.Nombre == nombre && n.Apellido == apellido);

            var mapper2 = _mapper.Map<ContactoDto>(result2);

            if (result2 == null)
            {
                return NotFound();
            }

            _contactoDbContext.Contactos.Remove(result2);
            _contactoDbContext.SaveChangesAsync().Wait();


            return StatusCode(201);
        }

        // Elimino un Numero de Telefono de un Contacto existente

        [HttpDelete("DeleteTelefono/{telefono}")]
        public async Task<ActionResult<TelefonoDto>> DeleteTelefono(int telefono)
        {
            var result2 = await _contactoDbContext.Telefonos.FirstOrDefaultAsync(t => t.NumeroTelefono == telefono);

            var mapper2 = _mapper.Map<TelefonoDto>(result2);

            if (result2 == null)
            {
                return NotFound();
            }

            _contactoDbContext.Telefonos.Remove(result2);
            _contactoDbContext.SaveChangesAsync().Wait();


            return StatusCode(201);
        }

    }
}
