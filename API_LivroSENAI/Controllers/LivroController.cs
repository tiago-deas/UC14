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
    }
}
