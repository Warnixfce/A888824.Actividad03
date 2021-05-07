﻿using System;
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
                        var asiento = new Asiento(linea1);
                        asientos.Add(asiento);
                    }
                }                
            }
        }

        public void MovimientosPosteriores(int codigoCuenta, DateTime fecha, ref decimal debe, ref decimal haber)
        {
            bool existe = Existe();
            if(existe)
            {
                if (asientos.Count == 0)
                {
                    Console.WriteLine("No existen asientos cargados en el libro diario.");
                }
                else
                {
                    foreach (var asiento in asientos) //para cada asiento en el libro diario
                    {
                        if (codigoCuenta == asiento.codigoDeCuenta) //si el codigo de cuenta que le paso es igual al codigo de cuenta del asiento...
                        {
                            if (fecha < asiento.fecha) //... si la fecha que le doy es menor a la fecha del asiento...
                            {
                                debe += asiento.debe; //acumulo en una variable lo que haya en el debe
                                haber += asiento.haber; //acumulo en otra variable lo que haya en el haber                        
                            }
                        }

                    }
                }
            }                        
        }

        public bool Existe()
        {
            bool existe = true;
            if (!File.Exists(archivoDiario))
            {
                Console.WriteLine($"No existe el archivo con la ruta {archivoDiario}. Por favor cierre la aplicación, corrobore la ruta del archivo y vuelva a iniciar el sistema");
                existe = false;
            }
            return existe;
        }
    }
}