using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FriendlyPetAPI.Data;
using FriendlyPetAPI.Models;

namespace FriendlyPetAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriasController : ControllerBase
    {
        private readonly FriendlyPetContext _context;

        public CategoriasController(FriendlyPetContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categoria>>> Get()
        {
            return await _context.Categorias.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Categoria>> Post(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();

            return categoria;
        }
    }
}