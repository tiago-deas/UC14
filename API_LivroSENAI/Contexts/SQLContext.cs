using API_LivroSENAI.Models;
using Microsoft.EntityFrameworkCore;

namespace API_LivroSENAI.Contexts
{
    public class SQLContext : DbContext
    {
        SQLContext()  {}
        public SQLContext(DbContextOptions<SQLContext> options) : base(options) {}

        // vamos utilizar esse método para configurar o banco de dados 

        protected override void

        OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        {
            if (!optionsBuilder.IsConfigured)

            {
                // cada provedor tem sua sintaxe para especificação 

                optionsBuilder.UseSqlServer("Data Source = LAPTOP-40QOSMVS\\SQLEXPRESS; initial catalog = Chapter; Integrated Security = true");

            }
        }

        // dbsetrepresenta as entidades que serão utilizadas nas operações de leitura, criação, atualização e deleção 

        public DbSet<Livro> Livros { get; set; }

        public DbSet<Usuario> usuarios { get; set; }

    }
}
