using API_LivroSENAI.Contexts;
using API_LivroSENAI.Interfaces;
using API_LivroSENAI.Models;

namespace API_LivroSENAI.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly SQLContext _context;

        public UsuarioRepository(SQLContext context)
        { 
            _context = context;
        }
        public void Atualizar(int id, Usuario usuario)
        {
            Usuario usuarioEncontrado = _context.usuarios.Find(id);

            if (usuarioEncontrado != null)
            {
                usuarioEncontrado.Email = usuario.Email;
                usuarioEncontrado.Senha = usuario.Senha;    
                usuarioEncontrado.Tipo = usuario.Tipo;  
                _context.usuarios.Update(usuarioEncontrado);    

                _context.SaveChanges();
            }
        }

        public Usuario BuscarPorId(int id)
        {
          
            return _context.usuarios.Find(id);
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            _context.usuarios.Add(novoUsuario);

            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            Usuario usuario = _context.usuarios.Find(id);

            _context.usuarios.Remove(usuario);

            _context.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            return _context.usuarios.ToList();
        }

        public Usuario Login(string email, string senha)
        {
            throw new NotImplementedException();
        }
    }
}
