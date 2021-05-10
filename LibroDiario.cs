using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A888824.Actividad03
{
    class LibroDiario
    {       
        string archivoDiario = "Diario.txt";
        List<Asiento> asientos = new List<Asiento>();
        
        public LibroDiario()
        {
            if (File.Exists(archivoDiario))
            {
                using (var reader = new StreamReader(archivoDiario))
                {
                    while (!reader.EndOfStream)
                    {
                        var linea1 = reader.ReadLine();
                        if (linea1 == "NroAsiento|Fecha|CodigoCuenta|Debe|Haber")
                        {
                            continue;
                        }
                        else
                        {
                            try
                            {
                                var asiento = new Asiento(linea1);
                                asientos.Add(asiento);
                            }
                            catch (Exception e)
                            { Console.WriteLine("Error al leer cuenta. Existe un dato inválido."); }
                        }                       
                    }
                }                
            }
            else
            {
                using (StreamWriter w = File.AppendText("Diario.txt"))
                Console.WriteLine($"El archivo {archivoDiario} no fue encontrado. Se creó un nuevo archivo vacío con dicho nombre en la ruta definida.");
            }
        }

        public void MovimientosPosteriores(int codigoCuenta, DateTime fecha, ref decimal debe, ref decimal haber)
        {
            foreach (var asiento in asientos) //para cada asiento en el libro diario
            {
                if (asiento.codigoDeCuenta == codigoCuenta) //si el codigo de cuenta que le paso es igual al codigo de cuenta del asiento...
                {
                    if (fecha < asiento.fecha) //... si la fecha que le doy es menor a la fecha del asiento...
                    {
                        debe += asiento.debe; //acumulo en una variable lo que haya en el debe
                        haber += asiento.haber; //acumulo en otra variable lo que haya en el haber                        
                    }
                }
            }                     
        }

        public bool HayAsientos()
        {
            if(asientos.Count == 0)
            {
                return false;
            }
            return true;
        }

    }
}
