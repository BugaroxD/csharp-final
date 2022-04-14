using System;
using System.Collections.Generic;
using System.Linq;
using Models;

namespace Controller
{
    public class CategoriaController
    {
        public static Categoria InserirCategoria(
            string Nome,
            string Descricao
        )
        {
            if (String.IsNullOrEmpty(Nome))
            {
                throw new Exception("Nome inválido");
            }

            if (String.IsNullOrEmpty(Descricao))
            {
                throw new Exception("Descrição inválida");
            }

            return new Categoria(Nome, Descricao);
        }

        public static Categoria AlterarCategoria(
            int Id,
            string Nome,
            string Descricao
        )
        {
            Categoria categoria = GetCategorias(Id);

            if (!String.IsNullOrEmpty(Nome))
            {
                categoria.Nome = Nome;
            }

            if (!String.IsNullOrEmpty(Descricao))
            {
                categoria.Descricao = Descricao;
            }

            return categoria;
        }
        public static Categoria ExcluirCategoria(
           int Id
       )
        {
            Categoria categoria = GetCategorias(Id);
            Categoria.RemoverCategoria(categoria);
            return categoria;
        }

        public static IEnumerable<Categoria> VisualizarCategoria()
        {
            return Categoria.GetCategorias();
        }

        public static Categoria GetCategorias(int Id)
        {
            Categoria categoria = (
                from Categoria in Categoria.GetCategorias()
                where Categoria.Id == Id
                select Categoria
            ).First();

            if (categoria == null)
            {
                throw new Exception("Dentista não encontrado");
            }

            return categoria;
        }
    }
}