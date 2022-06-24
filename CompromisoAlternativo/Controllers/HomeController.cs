using CompromisoAlternativo.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CompromisoAlternativo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        //LOGIN DEL FUNCIONARIO
        [HttpPost]
        public ActionResult Login(Funcionario lc)
        {
            if (ModelState.IsValid)
            {

                string mainconn = ConfigurationManager.ConnectionStrings["LOCAL_BD"].ConnectionString;
                SqlConnection sqlconn = new SqlConnection(mainconn);
                string sqlquery = "select FUNC_ID, FUNC_UTRABAJO from [dbo].[FUNCIONARIO] where FUNC_ID=@FUNC_ID and FUNC_UTRABAJO=@FUNC_UTRABAJO";
                sqlconn.Open();
                SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
                sqlcomm.Parameters.AddWithValue("FUNC_ID", lc.FUNC_ID);
                sqlcomm.Parameters.AddWithValue("FUNC_UTRABAJO", lc.FUNC_UTRABAJO);

                SqlDataReader sdr = sqlcomm.ExecuteReader();
                if (sdr.Read())
                {
                    Session["FUNC_ID"] = lc.FUNC_ID.ToString();
                    return RedirectToAction("Inicio");
                }
                else
                {
                    ViewData["Message"] = "Fallo el inicio de sesion !";
                }
                sqlconn.Close();
            }
            return View();
        }

        //PAGINA DE INICIO DESPUES DEL LOGIN
        public ActionResult Inicio()
        {
            return View();

        }

        //PAGINA DE ACTIVIDAD
        public ActionResult Actividad()
        {
            return View();

        }

        //LISTAR PARTICIPANTES
        [HttpGet]
        public JsonResult ListarParticipantes()
        {
            List<Participantes> olista = new List<Participantes>();

            olista = new CN_Participantes().ListarParticipantes();

            return Json(new { data = olista }, JsonRequestBehavior.AllowGet);
        }
        //INTENTO DE AGREGAR PARTICIPANTES EXTERNOS
        //[HttpPost]
        //public JsonResult AñadirPart(Select objeto)
        //{
        //    object resultado;
        //    resultado = new CN_Participantes().AñadirPart(objeto, out Mensaje);


        //    return Json(new { resultado = resultado }, JsonRequestBehavior.AllowGet);
        //}
        [HttpPost]
        public JsonResult AñadirPart(Participantes objeto)
        {
            object resultado;
            string mensaje = string.Empty;
            resultado = new CN_Participantes().AñadirPart(objeto, out mensaje);


            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
















        //INTENTO GENERAR ARRAY FUNCIONARIO
        [HttpGet]
        public JsonResult ListarFuncionario()
        {
            List<Funcionario_test> olista = new List<Funcionario_test>();

            olista = new CN_Funcionario().ListarFuncionario();

            return Json(new { data = olista }, JsonRequestBehavior.AllowGet);
        }
       

    }
}