using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompromisoAlternativo.Models
{
    public class CN_Participantes
    {
        private CRUD_Participantes objObjeto = new CRUD_Participantes();

        public List<Participantes> ListarParticipantes()
        {
            return objObjeto.ListarParticipantes();
        }


        public bool AñadirPart(Participantes obj)
        {
            

            return objObjeto.AñadirPart(obj);

        }
    }
}