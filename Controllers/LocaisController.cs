using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FriendlyPetAPI.Data;
using FriendlyPetAPI.Models;

namespace FriendlyPetAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocaisController : ControllerBase
    {
        private readonly FriendlyPetContext _context;

        public LocaisController(FriendlyPetContext context)
        {
            _context = context;
        }

        // GET: api/locais
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Local>>> GetLocais()
        {
            return await _context.Locais
                .Include(l => l.Categoria)
                .ToListAsync();
        }

        // GET: api/locais/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Local>> GetLocal(int id)
        {
            var local = await _context.Locais
                .Include(l => l.Categoria)
                .FirstOrDefaultAsync(l => l.Id == id);

            if (local == null)
                return NotFound();

            return local;
        }

        // POST: api/locais
        [HttpPost]
        public async Task<ActionResult<Local>> PostLocal(Local local)
        {
            if (local.Latitude == null || local.Longitude == null)
                return BadRequest("Latitude e Longitude são obrigatórios para o mapa.");

            _context.Locais.Add(local);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetLocal), new { id = local.Id }, local);
        }

        // PUT: api/locais/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocal(int id, Local local)
        {
            if (id != local.Id)
                return BadRequest("ID inconsistente");

            _context.Entry(local).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Locais.Any(e => e.Id == id))
                    return NotFound();

                throw;
            }

            return NoContent();
        }

        // DELETE: api/locais/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocal(int id)
        {
            var local = await _context.Locais.FindAsync(id);

            if (local == null)
                return NotFound();

            _context.Locais.Remove(local);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}