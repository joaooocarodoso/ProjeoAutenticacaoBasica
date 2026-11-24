using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjeoAutenticacaoBasica.Models;
using ProjeoAutenticacaoBasica.Data;
using Microsoft.EntityFrameworkCore;
using ProjeoAutenticacaoBasica.Models.DTOs;

namespace ProjeoAutenticacaoBasica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly AppDbContext _context;
        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register( Register register)
        {
            var usuario = new Usuario
            {
                Nome = register.Nome,
                Username = register.Username,
                Password = register.Password,
                CreatedAt = DateTime.UtcNow
            };
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return Ok("Usuário registrado com sucesso.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Username == loginDto.Username && u.Password == loginDto.Password);
            if (usuario == null)
            {
                return Unauthorized("Credenciais inválidas.");
            }
            return Ok("Login bem-sucedido.");
        }
    }
}
