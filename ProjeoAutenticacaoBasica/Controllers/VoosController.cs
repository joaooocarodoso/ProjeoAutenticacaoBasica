using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjeoAutenticacaoBasica.Data;
using ProjeoAutenticacaoBasica.Models;
using ProjeoAutenticacaoBasica.Models.DTOs;

namespace ProjeoAutenticacaoBasica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VoosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CriarVoo(CriarVooDTO criarVooDTO)
        {
            var novoVoo = new Voo
            {
                Codigo = criarVooDTO.Codigo,
                Origem = criarVooDTO.Origem,
                Destino = criarVooDTO.Destino
            };

            _context.Voos.Add(novoVoo);
            await _context.SaveChangesAsync();

            return Ok(novoVoo);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResumoVooDTO>>> GetVoos()
        {
            var voos = await _context.Voos.AsNoTracking().OrderBy(v => v.Codigo).Select(v => new ResumoVooDTO
            {
                Id = v.Id,
                Codigo = v.Codigo,
                Trajeto = v.Origem + " -> " + v.Destino
            }).ToListAsync();

            return Ok(voos);
        }

            [HttpGet("codigo/{codigo}")]
            public async Task<ActionResult<VooManifestoDTO>> GetVooPorCodigo(string codigo)
            {
                var voo = await _context.Voos
                    .AsNoTracking()
                    .Where(v => v.Codigo == codigo)
                    .Select(v => new VooManifestoDTO
                    {
                        Id = v.Id,
                        Codigo = v.Codigo,
                        Trajeto = v.Origem + " -> " + v.Destino,
                        Passageiro = v.Passagens
                        .Select(p => new PassageiroNoVooDTO
                        {
                            Nome = p.Passageiro.Nome,
                            Assento = p.Assento
                        }).ToList()
                    })
                    .FirstOrDefaultAsync();

                if (voo is null)
                {
                    return NotFound(new { mensagem = "Voo não encontrado" });
                }

                return Ok(voo);
            }

     }
}
