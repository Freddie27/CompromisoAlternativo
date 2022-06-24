using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
namespace CompromisoAlternativo.Models
{
    public class CN_Participantes
    {
        private CRUD_Participantes objObjeto = new CRUD_Participantes();

        public List<Participantes> ListarParticipantes()
        {
            return objObjeto.ListarParticipantes();
        }


        //public int AñadirPart(Participantes obj, out string Mensaje)
        //{
        //    Mensaje = string.Empty;
        //    if(string.IsNullOrEmpty(obj.PART_RUT) || string.IsNullOrWhiteSpace(obj.PART_RUT)) {
        //        Mensaje = "El rut del usuario no puede ser vacío";
        //    }

        //    return objObjeto.AñadirPart(obj, out Mensaje);

        //}

        public int AñadirPart(Participantes obj, out string Mensaje)
        {
            int idAutoGenerado = 0;

            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(ConexionBD.cn))
                {
                    SqlCommand cmd = new SqlCommand("agregarPart", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@PART_RUT", obj.PART_RUT);
                    cmd.Parameters.AddWithValue("@PART_NOMBRE", obj.PART_NOMBRE);
                    cmd.Parameters.AddWithValue("@PART_FONO", obj.PART_FONO);
                    cmd.Parameters.AddWithValue("@PART_EMAIL", obj.PART_EMAIL);
                    cmd.Parameters.AddWithValue("@PART_INSTITUCION", obj.PART_INSTITUCION);


                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    idAutoGenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }

            }
            catch (Exception ex)
            {
                idAutoGenerado = 0;
                Mensaje = ex.Message;
            }
            return idAutoGenerado;
        }





    }
}