using API_LivroSENAI.Models;
using API_LivroSENAI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_LivroSENAI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {

        private readonly LivroRepository _livroRepository;

        public LivroController(LivroRepository livroRepo)
        {
            _livroRepository = livroRepo;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_livroRepository.Listar());
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
               Livro LivroBuscado =  _livroRepository.BuscarPorId(id);

                if (LivroBuscado == null)
                {
                    return NotFound();
                }
                return Ok(LivroBuscado);    
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        [HttpPost]

        public IActionResult Cadastrar(Livro n)
        {
            try
            {
                _livroRepository.Cadastrar(n);  

                return StatusCode(201); 
                
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        [HttpDelete("{id}")]

        public IActionResult Deletar(int id)
        {
            try
            {
                _livroRepository.Deletar(id);

                return Ok("Livro removido");
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        [HttpPut("{id")]
        public IActionResult Alterar(int id, Livro n)
        {
            try
            {
              _livroRepository.Alterar(id, n);

                return StatusCode(204);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
