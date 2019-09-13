using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BasicCore;
using BasicData;

namespace basic.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantesController : ControllerBase
    {
        private readonly BasicDbContext _context;

        public RestaurantesController(BasicDbContext context)
        {
            _context = context;
        }

        // GET: api/Restaurantes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Restaurante>>> Getrestaurantes()
        {
            return await _context.restaurantes.ToListAsync();
        }

        // GET: api/Restaurantes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Restaurante>> GetRestaurante(int id)
        {
            var restaurante = await _context.restaurantes.FindAsync(id);

            if (restaurante == null)
            {
                return NotFound();
            }

            return restaurante;
        }

        // PUT: api/Restaurantes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRestaurante(int id, Restaurante restaurante)
        {
            if (id != restaurante.Id)
            {
                return BadRequest();
            }

            _context.Entry(restaurante).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestauranteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Restaurantes
        [HttpPost]
        public async Task<ActionResult<Restaurante>> PostRestaurante(Restaurante restaurante)
        {
            _context.restaurantes.Add(restaurante);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRestaurante", new { id = restaurante.Id }, restaurante);
        }

        // DELETE: api/Restaurantes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Restaurante>> DeleteRestaurante(int id)
        {
            var restaurante = await _context.restaurantes.FindAsync(id);
            if (restaurante == null)
            {
                return NotFound();
            }

            _context.restaurantes.Remove(restaurante);
            await _context.SaveChangesAsync();

            return restaurante;
        }

        private bool RestauranteExists(int id)
        {
            return _context.restaurantes.Any(e => e.Id == id);
        }
    }
}
