using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 4.
// Crear un sistema de temperaturas:
// - Ingresar temperatura  
// - Contar cuántas están bajo 0, entre 0 y 25, y mayores a 25  
// - Mostrar promedio  
// - Salir

// Como usuario necesito ingresar temperaturas para conocer sus estadisticas y promedio
// Como sistema necesito crear un menu interactivo para que el usuario pueda conocer estadisticas de sus temperaturas

namespace _4_remake
{
    public class conteoTemperatura
    {
        public int cantidadTemperaturas, mayor25, entre0y25, bajo0;
        double sumaTemperaturas, promedio;
        
    }
    internal class Program
    {

        static void Main(string[] args)
        {
            conteoTemperatura reporte = new conteoTemperatura();
        }
    }
}
