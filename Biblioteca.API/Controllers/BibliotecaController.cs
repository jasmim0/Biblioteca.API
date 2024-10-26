using Biblioteca.API.Models;
using Biblioteca.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Biblioteca.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BibliotecaController : ControllerBase
    {
        private readonly BibliotecaRepository _bibliotecaRepository;

        public BibliotecaController(BibliotecaRepository bibliotecaRepository)
        {
            _bibliotecaRepository = bibliotecaRepository;
        }

        // GET: api/BibliotecaController>
        [HttpGet]
        [Route("listar")]
        [SwaggerOperation(Summary = "Listar todos os Livros", Description = "Este endpoint retorna um listagem de livros cadastrados.")]
        public async Task<IActionResult> Listar([FromQuery] bool? ativo = null)
        {
            var dados = await _bibliotecaRepository.ListarTodosLivros(ativo);

            if (dados == null)
            {
                return Ok("Não existe Livros cadastradas");
            }

            return Ok(dados);

        }


        //POST api/<ValuesController>
        [HttpPost]
        [SwaggerOperation(
            Summary = "Cadastrar um novo livro",
            Description = "Este endpoint é responsavel por cadastrar  um novo livro no banco")]
        public async Task<IActionResult> Post([FromBody] Livros dados, BibliotecaRepository _bibliotecaRepository)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var LivrosJaExiste = await _bibliotecaRepository.ValidaExistslivros(dados.Livros);

            if (LivrosJaExiste)
            {
                return BadRequest("O Livro informado já está em uso, informe outro.");
            }

            await _bibliotecaRepository.Salvar(dados);

            return Ok("Livro cadastrada com sucesso");
        }

        //PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
