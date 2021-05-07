using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A888824.Actividad03
{
    class Asiento
    {
        public int numero { get; set; }
        public DateTime fecha { get; set; }
        public int codigoDeCuenta { get; set; }
        public decimal debe { get; set; }
        public decimal haber { get; set; }

        public Asiento(string linea)
        {
            var datos = linea.Split('|');
            numero = int.Parse(datos[0]);
            fecha = DateTime.Parse(datos[1]);
            codigoDeCuenta = int.Parse(datos[2]);
            debe = decimal.Parse(datos[3]);
            haber = decimal.Parse(datos[4]);
        }

        public override string ToString()
        {
            return $"Numero de asiento: {numero}, Fecha: {fecha:dd/MM/yyyy}, Codigo de cuenta: {codigoDeCuenta} Saldo debe: {debe}, Saldo haber: {haber}";
        }

    }
}
