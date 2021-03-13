using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContosoPets.Api.Data;
using ContosoPets.Api.Models;

namespace ContosoPets.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly ContosoPetsContext _context;

        public ProdutosController(ContosoPetsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Produto>> GetAll( ) =>
            _context.Produtos.ToList();

        // GET by ID action
        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> GetById(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);

            if ( produto == null )
            {
                return NotFound();
            }

            return produto;
        }

        // POST action
        [HttpPost]
        public async Task<IActionResult> Create(Produto prod)
        {
            _context.Produtos.Add(prod);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = prod.Id }, prod);
        }

        // PUT action
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Produto prod)
        {
            if ( id != prod.Id )
            {
                return BadRequest();
            }

            _context.Entry(prod).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE action
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var prod = await _context.Produtos.FindAsync(id);

            if ( prod == null )
            {
                return NotFound();
            }

            _context.Produtos.Remove(prod);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}