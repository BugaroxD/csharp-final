using System;
using System.Collections.Generic;
using System.Linq;
using Models;

namespace Controllers
{
    public class SenhaController
    {
        public static Senha InserirSenha(
            string Nome,
            int CategoriaId,
            string Url,
            string Usuario,
            string SenhaEncrypt,
            string Procedimento

        )
        {
            if (String.IsNullOrEmpty(Nome))
            {
                throw new Exception("Nome inválido");
            }

            if (String.IsNullOrEmpty(Url))
            {
                throw new Exception("Url inválida");
            }

            if (String.IsNullOrEmpty(Usuario))
            {
                throw new Exception("Usuário inválido");
            }
            if (String.IsNullOrEmpty(SenhaEncrypt))
            {
                throw new Exception("Senha inválido");
            }
            else
            {
                SenhaEncrypt = BCrypt.Net.BCrypt.HashPassword(SenhaEncrypt);
            }

            if (String.IsNullOrEmpty(Procedimento))
            {
                throw new Exception("Procedimento inválido");
            }

             return new Senha(Nome, CategoriaId, Url, Usuario, SenhaEncrypt, Procedimento);
        }

        public static Senha AlterarSenha(
            int Id,
            string Nome,
            int CategoriaId,
            string Url,
            string Usuario,
            string SenhaEncrypt,
            string Procedimento
        )
        {
            Senha senha = GetSenhas(Id);

            if (!String.IsNullOrEmpty(Nome))
            {
                senha.Nome = Nome;
            }
            
            if (!String.IsNullOrEmpty(Url))
            {
               senha.Url = Url;
            }

            if (!String.IsNullOrEmpty(Usuario))
            {
                senha.Usuario = Usuario;
            }
            if (!String.IsNullOrEmpty(SenhaEncrypt))
            {
                senha.SenhaEncrypt = BCrypt.Net.BCrypt.HashPassword(SenhaEncrypt);
            }

            if (!String.IsNullOrEmpty(Procedimento))
            {
                senha.Procedimento = Procedimento;
            }

            return senha;
        }

        public static Senha ExcluirSenha(
            int Id
        )
        {
            Senha senha = GetSenhas(Id);
            Senha.RemoverSenha(senha);
            return senha;
        }

        public static IEnumerable<Senha> VisualizarSenha()
        {
            return Senha.GetSenhas();
        }

        public static Senha GetSenhas(int Id)
        {
            Senha senha = (
                from Senha in Senha.GetSenhas()
                where Senha.Id == Id
                select Senha
            ).First();

            if (senha == null)
            {
                throw new Exception("Senha não encontrada");
            }

            return senha;
        }

    } // public class SenhaController
} // namespace Controllerss