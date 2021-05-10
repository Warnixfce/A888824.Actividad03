using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A888824.Actividad03
{
    class Cuenta
    {       
        public int Codigo { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Debe { get; set; }
        public decimal Haber { get; set; }

        public Cuenta(string linea)
        {           
            var datos = linea.Split('|');
            Codigo = int.Parse(datos[0]);
            Fecha = DateTime.Parse(datos[1]);
            Debe = decimal.Parse(datos[2]);
            Haber = decimal.Parse(datos[3]);
        }

        public string ObtenerLineaDatos() => $"{Codigo}|{Fecha:dd/MM/yyyy}|{Debe}|{Haber}";

        public override string ToString()
        {
            return $"Codigo de cuenta: {Codigo}, Fecha: {Fecha:dd/MM/yyyy}, Saldo debe: ${Debe}, Saldo haber: ${Haber}";
        }

    }
}
