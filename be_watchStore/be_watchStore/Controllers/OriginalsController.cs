using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using be_watchStore.DATA;
using be_watchStore.Models;

namespace be_watchStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OriginalsController : ControllerBase
    {
        private readonly WatchShopContext _context;

        public OriginalsController(WatchShopContext context)
        {
            _context = context;
        }

        // GET: api/Originals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Original>>> GetOriginals()
        {
          if (_context.Originals == null)
          {
              return NotFound();
          }
            return await _context.Originals.ToListAsync();
        }

        // GET: api/Originals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Original>> GetOriginal(int id)
        {
          if (_context.Originals == null)
          {
              return NotFound();
          }
            var original = await _context.Originals.FindAsync(id);

            if (original == null)
            {
                return NotFound();
            }

            return original;
        }

        // PUT: api/Originals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOriginal(int id, Original original)
        {
            if (id != original.SupplierId)
            {
                return BadRequest();
            }

            _context.Entry(original).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OriginalExists(id))
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

        // POST: api/Originals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Original>> PostOriginal(Original original)
        {
          if (_context.Originals == null)
          {
              return Problem("Entity set 'WatchShopContext.Originals'  is null.");
          }
            _context.Originals.Add(original);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOriginal", new { id = original.SupplierId }, original);
        }

        // DELETE: api/Originals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOriginal(int id)
        {
            if (_context.Originals == null)
            {
                return NotFound();
            }
            var original = await _context.Originals.FindAsync(id);
            if (original == null)
            {
                return NotFound();
            }

            _context.Originals.Remove(original);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("ListOriginal")]
        public async Task<ActionResult<List<ProductModel.getAllOriginal>>> getAllOriginal()
        {
            try
            {
                if(_context.Originals == null)
                {
                    return NotFound();
                }
                var result = _context.Originals.Select(c => new ProductModel.getAllOriginal {
                    id = c.SupplierId,
                    name = c.Name
                });
                return result.ToList();
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        } 

        private bool OriginalExists(int id)
        {
            return (_context.Originals?.Any(e => e.SupplierId == id)).GetValueOrDefault();
        }
    }
}
