using API_LivroSENAI.Contexts;
using API_LivroSENAI.Models;

namespace API_LivroSENAI.Repositories
{
    public class LivroRepository
    {

        private readonly SQLContext _context;
        public LivroRepository(SQLContext context)
        {
            _context = context;
        }

        public List<Livro> Listar()
        {
            return _context.Livros.ToList();
        }

    }
}
