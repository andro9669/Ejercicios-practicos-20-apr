using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace _5
{
    // 5.
    // Crear un sistema de sueldos:
    // - Ingresar sueldo  
    // - Contar cuántos superan 800000  
    // - Mostrar promedio  
    // - Mostrar porcentaje de sueldos altos  
    // - Salir


    // Como usuario necesito ingresar sueldos para saber estadisticas de los mismos
    // Como sistema necesito crear un menu interactivo para que el usuario pueda conocer estadisticas de los sueldos que ingrese
    internal class Program
    {
        static double sumaSueldos = 0, sumaSuperiores800000 = 0;
        static int cantidadSueldos = 0, superiores800000 = 0;
        static void Main(string[] args)
        {
            bool correrAplicacion = true;
            while (correrAplicacion)
            {
                Console.Clear();
                menu();
                int opcion = validarInput<int>("");
                switch (opcion)
                {
                    case 1:
                        ingresarSueldo();
                        break;
                    case 2:
                        mostrarSuperiores800000();
                        break;
                    case 3:
                        mostrarPromedio();
                        break;
                    case 4:
                        mostrarPorcentaje();
                        break;
                    case 5:
                        correrAplicacion = false;
                        break;
                    default:
                        Console.WriteLine("Error: fuera de rango.");
                        break;
                }
                if (correrAplicacion == true) Console.ReadKey();
            }
        }
        static void menu()
        {
            Console.WriteLine("1 - Ingresar sueldo\n" +
                              "2 - Mostrar cuantos superan los 800000\n" +
                              "3 - Mostrar promedio\n" +
                              "4 - Mostrar porcentaje de sueldos altos\n" +
                              "5 - Salir");
        }
        static T validarInput<T>(string mensaje)
        {
            if (mensaje != "") Console.WriteLine(mensaje);
            T input;
            const bool estaValidando = true;
            while (estaValidando)
            {
                try
                {
                    input = (T)Convert.ChangeType(Console.ReadLine(), typeof(T));
                    return input;
                }
                catch
                {
                    Console.WriteLine("Error: Tipo de dato invalido.");
                }

            }
        }
        static void ingresarSueldo()
        {
            const bool estaValidando = true;
            while (estaValidando)
            {
                double sueldo = validarInput<double>("Ingrese un sueldo.");
                if (sueldo >= 0)
                {
                    cantidadSueldos++;
                    sumaSueldos += sueldo;
                    if (sueldo > 800000) 
                    {
                        superiores800000++;
                        sumaSuperiores800000 += sueldo;
                    }
                    Console.WriteLine("Sueldo registrado correctamente.");
                    break;
                }
                Console.WriteLine("Error: fuera de rango.");
            }
        }
        static void mostrarSuperiores800000()
        {
            if (cantidadSueldos > 0) Console.WriteLine($"Superiores a 800000: {superiores800000}");
            else Console.WriteLine("Error: Debe ingresar minimamente un sueldo.");
        }
        static void mostrarPromedio()
        {
            if (cantidadSueldos > 0)
            {
                double promedioSueldos = sumaSueldos / cantidadSueldos;
                Console.WriteLine($"Promedio: {promedioSueldos}");
            }
            else Console.WriteLine("Error: Debe ingresar minimamente un sueldo.");
        }
        static void mostrarPorcentaje()
        {
            if (cantidadSueldos > 0)
            {
                double porcentajeAltos = superiores800000 * 100 / cantidadSueldos;
                Console.WriteLine($"Porcentaje: {porcentajeAltos}%");
            }
            else Console.WriteLine("Error: Debe ingresar minimamente un sueldo.");
        }

    }
}
