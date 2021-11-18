using System;
using System.Linq;
using API.Data;
using API.Models;
using API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly DataContext _context;
        //Construtor
        public UsuarioController(DataContext context) => _context = context;

        //POST: api/usuario/create
        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] Usuario usuario)
        {
            Usuario usuarioBuscado = _context.Usuarios.FirstOrDefault(u => u.Email == usuario.Email);
            if (usuarioBuscado != null)
            {
                return BadRequest(new { message = "Usuário já cadastrado" });
            }
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            usuario.Senha = "";
            return Created("", usuario);
        }

        // GET: api/usuario/login
        [HttpGet]
        [Route("login")]
        public IActionResult Login([FromBody] Usuario usuario)
        {
            usuario = _context.Usuarios.FirstOrDefault
                (u => u.Email == usuario.Email && u.Senha == usuario.Senha);

            if (usuario == null)
            {
                return BadRequest(new { message = "Usuário ou senha inválidos" });
            }
            usuario.Senha = "";
            usuario.Token = TokenService.CriarToken(usuario);
            return Ok(usuario);
        }

        // GET: api/usuario/sem
        [HttpGet]
        [Route("sem")]
        [AllowAnonymous]
        public IActionResult Sem()
        {
            return Ok(new { message = "Acesso sem autenticação" });
        }

        // GET: api/usuario/com
        [HttpGet]
        [Route("com")]
        [Authorize]
        public IActionResult Com()
        {
            return Ok(new { message = User.Identity.Name });
        }

        // GET: api/usuario/permissao
        [HttpGet]
        [Route("permissao")]
        [Authorize(Roles = "adm")]
        public IActionResult permissao()
        {
            return Ok(new { message = "ADM" });
        }

    }
}