using ExamenDefontana_MomoRobertino.Models;
using System;
using System.Linq;

namespace ExamenDefontana_MomoRobertino
{
    class Program
    {
        private static string connectionString = "Server=lab-defontana-202310.caporvnn6sbh.us-east-1.rds.amazonaws.com,1433;Database=Prueba;User Id=ReadOnly;Password=d*3PSf2MmRX9vJtA5sgwSphCVQ26*T53uU;";

        static void Main(string[] args)
        {
            /*
             contexto database-first

            Scaffold-DbContext "Server=lab-defontana-202310.caporvnn6sbh.us-east-1.rds.amazonaws.com,1433;Database=Prueba;User Id=ReadOnly;Password=d*3PSf2MmRX9vJtA5sgwSphCVQ26*T53uU;" 
            Microsoft.EntityFrameWorkCore.SqlServer -OutputDir Models
             */

            using (var context = new PruebaContext())
            {
                //DateTime fechaAux = DateTime.Today.AddDays(-30);
                //ACLARACION: Entiendo que se piden los ultimos 30 dias desde la fecha actual, para lo que usaría la linea que tengo comentada arriba.
                //Al no haber datos estoy usando los ultimos 30 dias de los que se tenga registro

                Console.WriteLine("El total de ventas de los últimos 30 días (monto total y cantidad total de ventas).");
                Console.WriteLine("");

                DateTime fechaAux = context.Venta.OrderByDescending(x => x.Fecha).Select(x => x.Fecha).FirstOrDefault();
                var ventaDelMes = context.Venta.Where(x => x.Fecha <= fechaAux && x.Fecha >= fechaAux.AddDays(-30));
                Console.WriteLine("-Total: " + ventaDelMes.Sum(x => x.Total) + " -Cantidad de ventas: " + ventaDelMes.Count());


                Console.WriteLine("---------------------------------------------------------------------------------");
                Console.WriteLine("---------------------------------------------------------------------------------");
                Console.WriteLine("El día y hora en que se realizó la venta con el monto más alto (y cuál es aquel monto).");
                Console.WriteLine("");

                var maxDia = context.Venta.OrderByDescending(x => x.Total).FirstOrDefault();
                Console.WriteLine("-Dia/Hora: " + maxDia.Fecha + " -Monto: " + maxDia.Total);


                Console.WriteLine("---------------------------------------------------------------------------------");
                Console.WriteLine("---------------------------------------------------------------------------------");
                Console.WriteLine("Indicar cuál es el producto con mayor monto total de ventas.");
                Console.WriteLine("");

                var productoMayorVenta = context.VentaDetalle.GroupBy(x => x.IdProducto).Select(x => new { total = x.Sum(x => x.TotalLinea), idProducto = x.Key }).OrderByDescending(x => x.total).Take(1).FirstOrDefault();
                var nombreMayorVenta = context.Producto.Where(x => x.IdProducto == productoMayorVenta.idProducto).Select(x => x.Nombre).FirstOrDefault();
                Console.WriteLine("-Producto: " + nombreMayorVenta + " -Monto total: " + productoMayorVenta.total);


                Console.WriteLine("---------------------------------------------------------------------------------");
                Console.WriteLine("---------------------------------------------------------------------------------");
                Console.WriteLine("Indicar el local con mayor monto de ventas.");
                Console.WriteLine("");

                var localMayorVenta = context.Venta.GroupBy(x => x.IdLocal).Select(x => new { total = x.Sum(x => x.Total), idLocal = x.Key }).OrderByDescending(x => x.total).Take(1).FirstOrDefault();
                var nombreLocalMayorVenta = context.Local.Where(x => x.IdLocal == localMayorVenta.idLocal).Select(x => x.Nombre).FirstOrDefault();
                Console.WriteLine("-Local: " + nombreLocalMayorVenta + " -Monto: " + localMayorVenta.total);


                Console.WriteLine("---------------------------------------------------------------------------------");
                Console.WriteLine("---------------------------------------------------------------------------------");
                Console.WriteLine("¿Cuál es la marca con mayor margen de ganancias?");
                Console.WriteLine("");

                var joinProdVenta = context.VentaDetalle.Join(context.Producto, ventaD => ventaD.IdProducto, prod => prod.IdProducto, (ventaD, prod) => new { venta = ventaD, producto = prod }).ToList();
                var marcaMasVentas = joinProdVenta.GroupBy(x => x.producto.IdMarca).Select(x => new { total = x.Sum(x => x.venta.TotalLinea), idMarca = x.Key }).OrderByDescending(x => x.total).Take(1).FirstOrDefault();
                var nombreMarcaMasVentas = context.Marca.Where(x => x.IdMarca == marcaMasVentas.idMarca).Select(x => x.Nombre).FirstOrDefault();
                Console.WriteLine("-Marca: " + nombreMarcaMasVentas + " -Monto: " + marcaMasVentas.total);

                
                Console.WriteLine("---------------------------------------------------------------------------------");
                Console.WriteLine("---------------------------------------------------------------------------------");
                Console.WriteLine("¿Cómo obtendrías cuál es el producto que más se vende en cada local?");
                Console.WriteLine("");

                var ventaDetalleJoins = context.VentaDetalle.Join(context.Venta, ventaDet => ventaDet.IdVenta, vent => vent.IdVenta, (ventaDet, vent) => new { ventaDetalle = ventaDet, ventita = vent }).Join(context.Producto, vvd => vvd.ventaDetalle.IdProducto, prod => prod.IdProducto, (vvd, prod) => new { v_vd = vvd, producto = prod }).ToList();

                foreach (var item in context.Local)
                {
                    var prodMasVendido = ventaDetalleJoins.Where(x => x.v_vd.ventita.IdLocal == item.IdLocal).GroupBy(x => x.v_vd.ventaDetalle.IdProducto).Select(x => new { total = x.Sum(x => x.v_vd.ventaDetalle.Cantidad), idProducto = x.Key}).OrderByDescending(x => x.total).Take(1).FirstOrDefault();
                    var nombreProd = ventaDetalleJoins.Where(x => x.producto.IdProducto == prodMasVendido.idProducto).Select(x => x.producto.Nombre).Take(1).FirstOrDefault();

                    Console.WriteLine("-Local: " + item.Nombre + " -Producto: " + nombreProd + " -Cantidad Vendida: " + prodMasVendido.total);
                }

                Console.ReadKey();
            }
        }




    }
}
