using ApiUsuarios.Models;
using ApiUsuarios.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiUsuarios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly UsuariosContext context;
        private readonly IMapper mapper;

        public HomeController(UsuariosContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<PersonaUsuarioDTO>> PostPersonas(PersonaUsuarioDTO DTO)
        {
            Usuarios usuarios = new Usuarios();
            Personas personas = new Personas();
            Personas personas1 = await context.Personas
                .Where(e => e.NumeroIdentificacion == personas.NumeroIdentificacion).FirstOrDefaultAsync();

            if (personas1 == null)
            {
                int IntNumID = Int32.Parse(DTO.NumeroIdentificacion);
                personas.Identificador = IntNumID;
                personas.NumeroIdentificacion = DTO.NumeroIdentificacion;
                personas.Nombres = DTO.Nombres;
                personas.Apellidos = DTO.Apellidos;
                personas.Email = DTO.Email;
                personas.TipoIdentificacion = DTO.TipoIdentificacion;
                personas.FechaCrecion = DateTime.Today.ToShortDateString().ToString();
                usuarios.Identificador = IntNumID;
                usuarios.Usuario = DTO.Usuario;
                usuarios.Pass = DTO.Pass;
                usuarios.FechaCreacion = DateTime.Today.ToShortDateString().ToString();
            }
            else
            {
                return BadRequest("El Numero de identificación " + personas.NumeroIdentificacion + " ya está registrado.");
            }
            

            context.Add(mapper.Map<Personas>(personas));
            context.Add(mapper.Map<Usuarios>(usuarios));
            await context.SaveChangesAsync();
            
            return Ok(mapper.Map<PersonaUsuarioDTO>(personas));
        }
        [HttpPost("Login")]
        public async Task<ActionResult<LoginDTO>> Login(LoginDTO login)
        {
            Usuarios usuarios = await context.Usuarios
                .Where(e => e.Usuario == login.Usuario).FirstOrDefaultAsync();

            if (usuarios != null)
            {
                if (login.Pass != usuarios.Pass)
                {
                    return NotFound("Tu usuario y pass no coinciden o no te has registrado.");
                }
                return Ok("Bienvenido " + usuarios.Usuario + "!");
            }
            else
            {
                return NotFound("Tu usuario y pass no coinciden o no te has registrado.");
            }
        }
    }
}
