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

        public Livro BuscarPorId(int id)
        {
            return _context.Livros.Find(id);
        }

        public void Cadastrar(Livro n)
        {
            _context.Livros.Add(n);

            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            Livro n = _context.Livros.Find(id);

            _context.Livros.Remove(n);

            _context.SaveChanges();
        }

        public void Alterar(int id, Livro n)
        {
            Livro livroBuscado = _context.Livros.Find(id);

            if (livroBuscado != null)
            {
                livroBuscado.Titulo = n.Titulo;
                livroBuscado.QuantidadedePaginas = n.QuantidadedePaginas;
                livroBuscado.Disponivel = n.Disponivel;

                _context.Livros.Update(livroBuscado);

                _context.SaveChanges();
            }
        }

    }
}
