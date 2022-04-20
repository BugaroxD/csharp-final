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
            Senha senha = GetSenha(Id);

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
} // namespace Controllers
/*
namespace Models
{
    public class Senha
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
        public string Url { get; set; }
        public string Usuario { get; set; }
        public string SenhaEncrypt { get; set; }
        public string Procedimento { get; set; }


        public Senha() { }

        public Senha(
            string Nome,
            int CategoriaId,
            string Url,
            string Usuario,
            string SenhaEncrypt,
            string Procedimento
        )
        {
            this.Nome = Nome;
            this.CategoriaId = CategoriaId;
            this.Url = Url;
            this.Usuario = Usuario;
            this.SenhaEncrypt = SenhaEncrypt;
            this.Procedimento = Procedimento;

            Context db = new Context();
            db.Senhas.Add(this);
            db.SaveChanges();
        }

        public override string ToString()
        {
            return $"\n ---------------------------------------"
                + $"\n ID: {this.Id}"
                + $"\n Nome: {this.Nome}"
                + $"\n Categoria: {this.Categoria.Nome}"
                + $"\n Url: {this.Url}"
                + $"\n Usuario: {this.Usuario}"
                + $"\n Procedimento: {this.Procedimento}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!Senha.ReferenceEquals(this, obj))
            {
                return false;
            }
            Senha it = (Senha) obj;
            return it.Id == this.Id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }


        public static void AlterarSenha(
            int Id,
            string Nome,
            int CategoriaId,
            string Url,
            string Usuario,
            string SenhaEncrypt,
            string Procedimento
        )
        {
            Senha senha = GetSenha(Id);
            senha.Nome = Nome;
            senha.CategoriaId = CategoriaId;
            senha.Url = Url;
            senha.Usuario = Usuario;
            senha.SenhaEncrypt = SenhaEncrypt;
            senha.Procedimento = Procedimento;

            Context db = new Context();
            db.Senhas.Update(senha);
            db.SaveChanges();
        }


        public static IEnumerable<Senha> GetSenhas()
        {
            Context db = new Context();
            return db.Senhas.Include("Categoria");
        }

        public static Senha GetSenha(int Id)
        {
            Context db = new Context();
            IEnumerable<Senha> senhas = from Senha in db.Senhas
                            where Senha.Id == Id
                            select Senha;

            return senhas.First();
        }

        public static void RemoverSenha(Senha senha)
        {
            foreach (SenhaTag item in SenhaTag.GetBySenhaId(senha.Id))
            {
                SenhaTag.RemoverSenhaTag(item);
            }
            Context db = new Context();
            db.Senhas.Remove(senha);
            db.SaveChanges();
        }
    }
}
*/