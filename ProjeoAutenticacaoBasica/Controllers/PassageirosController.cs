using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProjeoAutenticacaoBasica.Data;
using ProjeoAutenticacaoBasica.Models;
using ProjeoAutenticacaoBasica.Models.DTOs;

namespace ProjeoAutenticacaoBasica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassageirosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PassageirosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Passageiro>>> GetPassageiros([FromQuery] string? nome)
        {
            var passageiros = await _context.Passageiros.AsNoTracking().Where(p => string.IsNullOrEmpty(nome) || p.Nome.Contains(nome)).OrderBy(p => p.Nome).Select(p => new Passageiro
            {
                Id = p.Id,
                Nome = p.Nome,
                CPF = p.CPF
            }).ToListAsync();
            return Ok(passageiros);
        }

        [HttpPost]
        public async Task<IActionResult>CriarPassageiro(CriarPassageiroDTOs passageiro)
        {
            var novoPassageiro = new Passageiro
            {
                Nome = passageiro.Nome,
                CPF = passageiro.CPF
            };
            _context.Passageiros.Add(novoPassageiro);
            await _context.SaveChangesAsync();
            return Ok(novoPassageiro);
        }

        [HttpGet("cpf/{cpf}")]
        public async Task<ActionResult<PassageiroInfoDTOs>>GetPassageiroPorCpf(string cpf)
        {
            var passageiro = await _context.Passageiros
                .AsNoTracking()
                .Where(p => p.CPF == cpf)
                .Select(p => new PassageiroInfoDTOs
                {
                Id = p.Id,
                Nome = p.Nome
                }).FirstOrDefaultAsync();
            if (passageiro is null)
            {
                return NotFound(new { mensagem = "Passageiros não escontrado" });
            }

            return Ok(passageiro);
        }

    }
}
