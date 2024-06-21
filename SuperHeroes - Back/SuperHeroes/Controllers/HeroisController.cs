
using SuperHeroes.Interfaces;
using SuperHeroes.Models;
using SuperHeroes.DTOs;
using SuperHeroes.Configuracao;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SuperHeroes.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HeroisController : ControllerBase
    {
        private readonly IHeroi _interfaceHeroi;
        private ContextDb _context;
        public HeroisController(IHeroi InterfaceHeroi, ContextDb ContextDb)
        {
            _interfaceHeroi = InterfaceHeroi;
            _context = ContextDb;
        }

        [HttpGet]
        public async Task<ActionResult<ReadHeroiDto>> ListaHerois()
        {
            if (_context.Herois == null)
            {
                return NotFound("Nenhum Herói Cadastrado");
            }

            var heroisDTO = await _context.Herois
                .Select(h => new ReadHeroiDto
                {
                    Id = h.Id,
                    Nome = h.Nome,
                    NomeHeroi = h.NomeHeroi,
                    DataNascimento = h.DataNascimento,
                    Altura = h.Altura,
                    Peso = h.Peso,
                    Superpoderes = _context.HeroisSuperpoderes
                        .Where(hs => hs.HeroiId == h.Id)
                        .Select(hs => new ReadSuperpoderDto {
                            Id = hs.Superpoder.Id,
                            Superpoder = hs.Superpoder.Superpoder,
                            Descricao = hs.Superpoder.Descricao
                        })
                        .ToList()
                })
                .ToListAsync();

            return Ok(heroisDTO);
        }

        [HttpPost]
        public async Task<ActionResult> CadastroHeroi([FromBody] CreateHeroiDto heroi)
        {
            var heroiConsultado = await _context.Herois.FirstOrDefaultAsync(x => x.NomeHeroi == heroi.NomeHeroi);
            if (heroiConsultado != null)
            {
                return BadRequest($"Nome de Super Herói {heroiConsultado.NomeHeroi}, já existe na base de dados");
            }

            Herois novoHeroi = new()
            {
                Nome = heroi.Nome,
                NomeHeroi = heroi.NomeHeroi,
                DataNascimento = heroi.DataNascimento,
                Altura = heroi.Altura,
                Peso = heroi.Peso,
            };

            try
            {
                await _interfaceHeroi.Add(novoHeroi);
                await InsertSuperpoderes(novoHeroi, heroi);
                _context.SaveChanges();
                return CreatedAtAction(nameof(GetHeroiPorId), new { novoHeroi.Id }, novoHeroi);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReadHeroiDto>> GetHeroiPorId(int id)
        {
            var heroi = _context.Herois
                            .Include(eOne => eOne.Superpoderes).FirstOrDefault(p => p.Id == id);

            if (heroi is null)
            {
                return NotFound();

            }
            return Ok(heroi);
        }

        [HttpPut("{id}")]
        public async Task<object> AtualizaHeroi(int id, [FromBody] UpdateHeroiDto novoHeroi)
        {
            var nomeHeroi = await _context.Herois.FirstOrDefaultAsync(x => x.NomeHeroi == novoHeroi.NomeHeroi);

            if (nomeHeroi != null && nomeHeroi.NomeHeroi == novoHeroi.NomeHeroi && id != nomeHeroi.Id)
            {
                return BadRequest($"Nome de Super Herói {nomeHeroi.NomeHeroi}, já existe na base de dados");
            }

            try
            {
                var heroiConsultado = await _context.Herois.Include(x => x.Superpoderes).FirstOrDefaultAsync(x => x.Id == id);

                heroiConsultado.Nome = novoHeroi.Nome;
                heroiConsultado.NomeHeroi = novoHeroi.NomeHeroi;
                heroiConsultado.DataNascimento = novoHeroi.DataNascimento;
                heroiConsultado.Altura = novoHeroi.Altura;
                heroiConsultado.Peso = novoHeroi.Peso;

                
                await UpdateSuperpoderes(novoHeroi, heroiConsultado);
                await _interfaceHeroi.Update(heroiConsultado);
                await _context.SaveChangesAsync();
                return Ok(heroiConsultado);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            

        }

        [HttpDelete("{id}")]
        public async Task<object> RemoveHeroi(int id)
        {
            var heroi = await _context.Herois.FirstOrDefaultAsync(x => x.Id == id);
            if (heroi == null) return NotFound();

            try
            {
                await _interfaceHeroi.Delete(heroi);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        private async Task InsertSuperpoderes(Herois heroi, CreateHeroiDto heroiDto)
        {

            try
            {
                foreach (var superpoder in heroiDto.Superpoderes)
                {
                    var superpoderConsultada = await _context.Superpoderes.AsNoTracking().FirstAsync(p => p.Id == superpoder.Id);

                    var HeroisSuperpoderes = new HeroisSuperpoderes
                    {
                        HeroiId = heroi.Id,
                        SuperpoderId = superpoderConsultada.Id
                    };

                    _context.HeroisSuperpoderes.Add(HeroisSuperpoderes);
                }
            }
            catch (Exception)
            {
                await _interfaceHeroi.Delete(heroi);
                throw;
            }

        }

        private async Task UpdateSuperpoderes(UpdateHeroiDto novoHeroi, Herois heroiConsultado)
        {

            try
            {
                heroiConsultado.Superpoderes.Clear();
                foreach (var superpoder in novoHeroi.Superpoderes)
                {
                    var superpoderConsultada = await _context.Superpoderes.AsNoTracking().FirstAsync(p => p.Id == superpoder.Id);

                    var HeroisSuperpoderes = new HeroisSuperpoderes
                    {
                        HeroiId = heroiConsultado.Id,
                        SuperpoderId = superpoderConsultada.Id
                    };

                    heroiConsultado.Superpoderes.Add(HeroisSuperpoderes);
                }
            }
            catch (Exception)
            {
             
                throw;
            }

        }

    }
}
