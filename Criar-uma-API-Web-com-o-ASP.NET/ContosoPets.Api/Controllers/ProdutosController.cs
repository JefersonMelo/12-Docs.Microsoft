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

        // POST action

        // PUT action

        // DELETE action
    }
}