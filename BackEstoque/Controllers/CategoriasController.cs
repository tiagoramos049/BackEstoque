using BackEstoque.Contexto;
using BackEstoque.Models;
using BackEstoque.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BackEstoque.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriasController(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }


        [HttpGet("ObterTodos")]
        public IEnumerable<Categoria> Get()
        {
            return _categoriaRepository.GetAll(); 
        }


        [HttpGet("{id}")]
        public ActionResult<Categoria> GetById(Guid id)
        {
            var categoria = _categoriaRepository.GetById(id);

            if (categoria == null)
            {
                return NotFound();
            }

            return Ok(categoria);
        }


        [HttpPost("incluir")]
        public IActionResult Post([FromBody] Categoria categoria)
        {
            if (categoria == null)
            {
                return BadRequest();
            }

            _categoriaRepository.Add(categoria);
            return CreatedAtAction(nameof(Get), new { id = categoria.CategoriaId }, categoria);
        }


        [HttpPut("alterar/{id}")]
        public IActionResult Put(Guid id, [FromBody] Categoria categoria)
        {
            if (categoria == null || categoria.CategoriaId != id)
            {
                return BadRequest();
            }

            _categoriaRepository.Update(categoria); 
            return NoContent();
        }

        [HttpDelete("excluir/{id}")]
        public IActionResult Delete(Guid id)
        {
            var categoria = _categoriaRepository.GetById(id);

            if (categoria == null)
            {
                return NotFound();
            }

            _categoriaRepository.Delete(id);
            return NoContent();
        }
    }
}
