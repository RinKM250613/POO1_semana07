using prueba_01.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace prueba_01.Controllers
{
    public class HomeController : Controller
    {
        //rebu
        public ActionResult Index()
        {
            string cadenaConexion = "uid=ryllanes; database=semana07; password=Kookmin2506; server=.;";
            List<Persona> lista = new List<Persona>();

            using (SqlConnection con = new SqlConnection(cadenaConexion))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("USP_PERSONA_CRUD", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@indicador", "consultar");
                    cmd.Parameters.AddWithValue("@nombre", "");
                    cmd.Parameters.AddWithValue("@apellido", "");
                    cmd.Parameters.AddWithValue("@codigo", 0);


                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        Persona per;
                        while (reader.Read())
                        {
                            per = new Persona()
                            {
                                codigo = reader.GetInt32(0),
                                nombre = reader.GetString(1),
                                apellido = reader.GetString(2),
                            };
                            lista.Add(per);
                        }
                    }
                }
            }
            return View(lista);
        }

        [HttpGet]
        public ActionResult ACTION_CREAR()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ACTION_CREAR(Persona persona)
        {
            int procesar = -1;
            string cadenaConexion = "uid=ryllanes; database=semana07; password=Kookmin2506; server=.;";

            using (SqlConnection con = new SqlConnection(cadenaConexion))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("USP_PERSONA_CRUD", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@indicador", "insertar");
                    cmd.Parameters.AddWithValue("@nombre", persona.nombre);
                    cmd.Parameters.AddWithValue("@apellido", persona.apellido);
                    cmd.Parameters.AddWithValue("@codigo", 0);
                    procesar = cmd.ExecuteNonQuery();

                }
            }
            return RedirectToAction("Index");
        }





        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}