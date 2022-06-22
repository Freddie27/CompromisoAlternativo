using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CompromisoAlternativo.Models;


namespace CompromisoAlternativo.Models
{
    public class CRUD_Participantes
    {

        //METODO PARA LISTAR PARTICIPANTES
        public List<Participantes> ListarParticipantes()
        {
            List<Participantes> lista = new List<Participantes>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(ConexionBD.cn))
                {
                    SqlCommand cmd = new SqlCommand("LeerPart", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                                new Participantes()
                                {
                                    PART_RUT = Convert.ToString(dr["PART_RUT"]),
                                    PART_NOMBRE = dr["PART_NOMBRE"].ToString(),
                                    PART_FONO = dr["PART_FONO"].ToString(),
                                    PART_EMAIL = dr["PART_EMAIL"].ToString(),
                                    PART_INSTITUCION = dr["PART_INSTITUCION"].ToString()
                                }

                                );
                        }
                    }

                }
            

            }
            catch
            {
                lista = new List<Participantes>();
            }


            return lista;
        }

        public bool AñadirPart(Participantes smodel)
        {
            using (SqlConnection oconexion = new SqlConnection(ConexionBD.cn))
            {
                SqlCommand cmd = new SqlCommand("agregarPart", oconexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@PART_RUT", smodel.PART_RUT);
                cmd.Parameters.AddWithValue("@PART_NOMBRE", smodel.PART_NOMBRE);
                cmd.Parameters.AddWithValue("@PART_FONO", smodel.PART_FONO);
                cmd.Parameters.AddWithValue("@PART_EMAIL", smodel.PART_EMAIL);
                cmd.Parameters.AddWithValue("@PART_INSTITUCION", smodel.PART_INSTITUCION);


                oconexion.Open();
                int i = cmd.ExecuteNonQuery();
                oconexion.Close();

                if (i >= 1)
                    return true;
                else
                    return false;
            }
        }
    }
}