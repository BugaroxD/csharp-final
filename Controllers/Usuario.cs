using System;
using System.Collections.Generic;
using System.Linq;
using Models;

namespace Controllers
{
    public class UsuarioController
    {
        public static Usuario InserirUsuario(
            string Nome,
            string Email,
            string Senha
        )
        {
            if (String.IsNullOrEmpty(Nome))
            {
                throw new Exception("Nome inválido");
            }

            if (String.IsNullOrEmpty(Email))
            {
                throw new Exception("Descrição inválida");
            }

            if (String.IsNullOrEmpty(Senha))
            {
                throw new Exception("Senha inválido");
            }
            else
            {
                Senha = BCrypt.Net.BCrypt.HashPassword(Senha);
            }

            return new Usuario(Nome, Email, Senha);
        }
        public static Usuario AlterarUsuario(
            int Id,
            string Nome,
            string Email,
            string Senha
        )
        {
            Usuario usuario = GetUsuarios(Id);

            if (!String.IsNullOrEmpty(Nome))
            {
                usuario.Nome = Nome;
            }

            if (!String.IsNullOrEmpty(Email))
            {
                usuario.Email = Email;
            }
            if (!String.IsNullOrEmpty(Senha))
            {
                usuario.Senha = BCrypt.Net.BCrypt.HashPassword(Senha);
            }

            return usuario;
        }
        public static Usuario ExcluirUsuario(
           int Id
       )
        {
            Usuario usuario = GetUsuarios(Id);
            Usuario.RemoverUsuario(usuario);
            return usuario;
        }
        public static IEnumerable<Usuario> VisualizarUsuario()
        {
            return Usuario.GetUsuarios();
        }
        public static Usuario GetUsuarios(int Id)
        {
            Usuario usuario = (
                from Usuario in Usuario.GetUsuarios()
                where Usuario.Id == Id
                select Usuario
            ).First();

            if (usuario == null)
            {
                throw new Exception("Dentista não encontrado");
            }

            return usuario;
        }
    }
}