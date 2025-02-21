using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace semana_07
{
    internal class Program
    {
        static void Main(string[] args)
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
                    cmd.Parameters.AddWithValue("@nombre", "Jeikei");
                    cmd.Parameters.AddWithValue("@apellido", "Jeonshi");
                    cmd.Parameters.AddWithValue("@codigo", 0);
                    procesar = cmd.ExecuteNonQuery();
                    Console.WriteLine(procesar);

                }
            }



                Console.ReadKey();
        }
    }
}
