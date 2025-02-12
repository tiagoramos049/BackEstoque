using BackEstoque.Contexto;
using BackEstoque.Models;
using BackEstoque.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BackEstoque.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutosController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }


        [HttpGet("ObterTodos")]
        public IEnumerable<Produto> Get()
        {
            return _produtoRepository.GetAll(); 
        }


        [HttpGet("{id}")]
        public ActionResult<Produto> GetById(Guid id)
        {
            var produto = _produtoRepository.GetById(id);

            if (produto == null)
            {
                return NotFound();
            }

            return Ok(produto);
        }


        [HttpPost("incluir")]
        public IActionResult Post([FromBody] Produto produto)
        {
            if (produto == null)
            {
                return BadRequest();
            }

            _produtoRepository.Add(produto);
            return CreatedAtAction(nameof(Get), new { id = produto.ProdutoId }, produto);
        }


        [HttpPut("alterar/{id}")]
        public IActionResult Put(Guid id, [FromBody] Produto produto)
        {
            if (produto == null || produto.ProdutoId != id)
            {
                return BadRequest();
            }

            _produtoRepository.Update(produto); 
            return NoContent();
        }

        [HttpDelete("excluir/{id}")]
        public IActionResult Delete(Guid id)
        {
            var produto = _produtoRepository.GetById(id);

            if (produto == null)
            {
                return NotFound();
            }

            _produtoRepository.Delete(id);
            return NoContent();
        }

    }
}
