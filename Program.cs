using ExamenDefontana_MomoRobertino.Models;
using System;
using System.Linq;

namespace ExamenDefontana_MomoRobertino
{
    class Program
    {
        private static string connectionStringCliente = "Server=lab-defontana-202310.caporvnn6sbh.us-east-1.rds.amazonaws.com,1433;Database=Prueba;User Id=ReadOnly;Password=d*3PSf2MmRX9vJtA5sgwSphCVQ26*T53uU;";

        static void Main(string[] args)
        {
            /*
            Scaffold-DbContext "Server=lab-defontana-202310.caporvnn6sbh.us-east-1.rds.amazonaws.com,1433;Database=Prueba;User Id=ReadOnly;Password=d*3PSf2MmRX9vJtA5sgwSphCVQ26*T53uU;" 
            Microsoft.EntityFrameWorkCore.SqlServer -OutputDir Models
             */

            using (var context = new PruebaContext())
            {
                var venta = context.Venta.Where(x => x.Fecha);
                

                foreach (var item in context.Marca.ToList())
                {
                    Console.WriteLine(item.Nombre);
                }
            }

                //Console.WriteLine();
        }



        //public static string getIdProximaEntidad()
        //{
        //    string ret = "TESTEANDO:    ";

        //    //var query = "select TOP 10 * from Producto";

        //    //SqlConnection connection = new SqlConnection(connectionStringCliente);

        //    //using (connection)
        //    //{
        //    //    SqlCommand comando = new SqlCommand(query, connection);

        //    //    try
        //    //    {
        //    //        connection.Open();
        //    //        SqlDataReader reader = comando.ExecuteReader();
        //    //        while (reader.Read())
        //    //        {
        //    //            ret = ret + reader[1].ToString();
        //    //        }
        //    //        reader.Close();
        //    //        connection.Close();

        //    //    }
        //    //    catch (Exception ex)
        //    //    {

        //    //        throw new Exception(ex.Message);
        //    //    }


        //    //}

        //    return ret;
        //}



    }
}
