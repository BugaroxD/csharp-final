using System;
using System.Linq;
using System.Collections.Generic;
using Models;

namespace Controllers
{
    public class TagSenhaController
    {
        public static SenhaTag InserirSenhaTag(
            int SenhaId,
            int TagId
        )
        {
            return new SenhaTag(SenhaId, TagId);
        }

        public static SenhaTag ExcluirSenhaTag(
            int Id
        )
        {
            SenhaTag SenhaTag = GetSenhaTag(Id);
            SenhaTag.RemoverSenhaTag(SenhaTag);
            return SenhaTag;
        }
         public static IEnumerable<SenhaTag> GetBySenhaId(int Id)
        {
            return SenhaTag.GetBySenhaId(Id);
        }
        public static SenhaTag GetBySenhaTag(int SenhaId, int TagId)
        {
            return SenhaTag.GetSenhaTag(SenhaId, TagId);
        }
        public static SenhaTag GetById(int Id)
        {
            SenhaTag SenhaTag = SenhaTag.GetById(Id);

            return SenhaTag;
        }

         public static IEnumerable<SenhaTag> VisualizarSenhaTag()
        {
            return SenhaTag.GetSenhaTags();
        }

        public static SenhaTag GetSenhaTag(
            int Id
        )
        {
            SenhaTag SenhaTag = (
                from senhaTag in SenhaTag.GetSenhaTags()
                    where senhaTag.Id == Id
                    select senhaTag
            ).First();

            if(SenhaTag == null)
            {
                throw new Exception("Tag da senha não encontrada");
            }
            return SenhaTag;
        }
    } // public class SenhaTagController
} // namespace Controller