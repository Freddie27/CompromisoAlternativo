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


        public int AñadirPart(Participantes obj, out string Mensaje)
        {
            if(string.IsNullOrEmpty(obj.PART_RUT) || string.IsNullOrWhiteSpace(obj.PART_RUT)) {
                Mensaje = "El rut del usuario no puede ser vacío";
            }

            return objObjeto.AñadirPart(obj, out Mensaje);

        }
    }
}