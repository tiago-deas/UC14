﻿namespace API_LivroSENAI.Models
{
    public class Livro
    {
        public int Id { get; set; }

        public string? Titulo { get; set; }

        public int QuantidadedePaginas { get; set; }

        public bool Disponivel { get; set; }


    }
}
