using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A888824.Actividad03
{
    public class LibroMayor
    {   
        string archivo = "Mayor.txt";
        List<Cuenta> cuentas = new List<Cuenta>();
        LibroDiario diario = new LibroDiario();        

        public LibroMayor()
        {
            if (File.Exists(archivo))
            {
                using (var reader = new StreamReader(archivo))
                {
                    while (!reader.EndOfStream)
                    {
                        var linea = reader.ReadLine();                        
                        if (linea == "CodigoCuenta|Fecha|Debe|Haber")
                        {
                            continue;
                        }
                        else
                        {
                            try
                            {
                                var cuenta = new Cuenta(linea);
                                cuentas.Add(cuenta);
                            }
                            catch (Exception e)
                            { Console.WriteLine("Error al leer cuenta. Existe un dato inválido."); }                            
                        }
                        
                    }
                }                
            } 
        }

        public void Mostrar()
        {
            bool existe = Existe();
            if (existe)
            {
                if (cuentas.Count == 0)
                {
                    Console.WriteLine("No hay cuentas en el libro mayor.");
                }
                else
                {
                    Console.WriteLine("Las cuentas y sus datos en el libro mayor son: ");
                    foreach (var c in cuentas)
                    {
                        Console.WriteLine(c.ToString());
                    }
                }
            }      
        }

        public bool Actualizar()
        {            
            bool existe = Existe();
            if(!existe)
            {
                return false;
            }
            if(cuentas.Count == 0)
            {
                Console.WriteLine("No es posible actualizar las cuentas del libro mayor puesto que no hay cuentas cargadas.");
                return false;
            }
            if(diario.HayAsientos() == false)
            {
                Console.WriteLine("No existen asientos cargados en el libro diario.");
                return false;
            }
            if (diario.Existe() == false)
            {
                return false;
            }
            foreach (var cuenta in cuentas)
            {
                var fechaCuenta = cuenta.Fecha;
                var codigoCuenta = cuenta.Codigo;
                decimal debe = 0;
                decimal haber = 0;

                diario.MovimientosPosteriores(codigoCuenta, fechaCuenta, ref debe, ref haber);

                if (debe != 0 || haber != 0)
                {
                    cuenta.Debe += debe;
                    cuenta.Haber += haber;
                    cuenta.Fecha = DateTime.Today;
                }
                Grabar();                             
            }
            return true;
        }

        private void Grabar()
        {
            using (var writer = new StreamWriter(archivo, append: false))
            {
                writer.WriteLine("CodigoCuenta|Fecha|Debe|Haber");
                foreach (var cuenta in cuentas)
                {
                    var linea = cuenta.ObtenerLineaDatos();
                    writer.WriteLine(linea);
                }
            }
        }

        public void MostrarDatosActualizados() //Entiendo que si la cuenta tiene fecha de hoy es porque se actualizó (digamos que ya está actualizada)
        {
            string Mensaje = "";
            foreach (var cu in cuentas) //Recorro el libro mayor...
            {
                if (cu.Fecha == DateTime.Today) //... si la fecha de la cuenta coincide con la fecha de hoy...
                {
                    //... implica que se actualizó la cuenta y por ende su debe y haber
                    Mensaje += $"-Cuenta: {cu.Codigo}, Saldo del Debe: {cu.Debe} y Saldo del Haber: {cu.Haber}" + System.Environment.NewLine;
                }
            }
            if (Mensaje == "")
            {
                Console.WriteLine("No se actualizó ninguna cuenta.");
            }
            if (Mensaje != "")
            {
                Console.WriteLine("Las cuentas y los datos que fueron actualizados son: " + System.Environment.NewLine + Mensaje);
            }
        }

        public bool Existe()
        {
            bool existe = true;
            if (!File.Exists(archivo))
            {
                Console.WriteLine($"No existe el archivo con la ruta {archivo}. Por favor cierre la aplicación, corrobore la ruta del archivo y vuelva a iniciar el sistema");
                existe = false;
            }
            return existe;
        }
    }
}
