using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A888824.Actividad03
{
    class Program
    {
        static void Main(string[] args)
        {
            //                     --------------------------------
            // ACLARACIONES:
            // 1) En el sistema, para las fechas de ambos libros consideré la forma de escritura "dd/mm/yyyy".
            // 2) Asumo que los archivos del libro Diario y del Mayor ya existen con una ruta (aún así valido que existan con ESA ruta).
            // 3) Asumo que las cuentas que están en el Mayor son las que se usan en el Diario (espero estar interpretando bien).
            // 4) Cuando bajo el proyecto de Github, no aparecen los archivos de texto del libro Diario ni del Mayor en la carpeta "bin\Debug" del proyecto.
            //    Si bien existen en mi pc al subirlo a Github, no aparecen cuando lo bajo. Dejo el contenido de los archivos que usé para probar acá escrito
            //    (para que puedas probar el sistema):
            //  Diario.txt:   NroAsiento|Fecha|CodigoCuenta|Debe|Haber
            //                1|03/04/2020|01|200|900
            //                1|03/04/2020|02|1000|300
            //                2|01/10/2020|02|2000|1000
            //                2|11/26/2020|03|500|1500
            //                3|11/20/2020|01|3000|3000
            //
            //  Mayor.txt:   CodigoCuenta|Fecha|Debe|Haber
            //               01|04/02/2020|2000|100
            //               02|03/04/2020|4000|200
            //               03|06/15/2020|6000|300
            // Considerar que mi pc está en INGLÉS (dejo el contenido con ese formato porque entiendo que tu pc también está en inglés).
            // Por favor si podes poner los archivos en la ruta "bin\Debug" del proyecto para probarlo,
            // te lo agradecería (no es mi idea tener mal la actividad por este motivo).
            // Entiendo que según la consigna, ya existen los archvos.
            //                     --------------------------------

            bool salir = false;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Menú Principal" + System.Environment.NewLine);
                Console.WriteLine("1 - Consultar datos");
                Console.WriteLine("2 - Actualizar datos");
                Console.WriteLine("9 - Salir");
 
                Console.WriteLine("Ingrese una opción y presione Enter: ");
                string opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "1":
                        MostrarMayor();
                        break;

                    case "2":
                        Console.WriteLine("Se procederá a actualizar los datos, ¿Está seguro? s/n");
                        var ingreso = Console.ReadKey(intercept: true);
                        if(ingreso.Key == ConsoleKey.S)
                        {
                            ActualizarMayor();                            
                        }
                        else
                        {
                            Console.WriteLine("Actualización no realizada.");
                        }
                        break;

                    case "9":
                        salir = true;                        
                        break;
                        
                    default:
                        Console.WriteLine("No ha ingresado una opción del menú.");
                        break;
                }
            } while (!salir);
        }

        //No sé trabajar bien con clases estáticas, así que las hice públicas. Sé que es redundante instanciar al libro mayor en cada método de esta clase y
        // también conceptualmente el libro mayor debería ser una clase estática (y el diario también), pero me funciona de esta manera
        // (y el programa corre aunque sea). Prefiero dejarlo así
        private static void MostrarMayor()
        {
            var libroMayor = new LibroMayor();
            libroMayor.Mostrar();
        }

        private static void ActualizarMayor()
        {
            var libroMayor = new LibroMayor();
            bool pudoActualizar = libroMayor.Actualizar();
            if(pudoActualizar)
            {
                libroMayor.MostrarDatosActualizados(); //Si pudo actualizar el libro mayor, implica que existe. Entonces muestro los datos que se actualizaron
                                                       // (ya se valido que existiera el archivo con el metodo Actualizar)
            }
        }

    }
}
