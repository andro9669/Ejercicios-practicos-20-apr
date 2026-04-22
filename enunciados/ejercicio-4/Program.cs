using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 4.
            // Crear un sistema de temperaturas:
            // - Ingresar temperatura  
            // - Contar cuántas están bajo 0, entre 0 y 25, y mayores a 25  
            // - Mostrar promedio  
            // - Salir

            double sumaTemperaturas = 0;
            int totalIngresos = 0;
            int bajoCero = 0;
            int entreCeroYVeinticinco = 0;
            int mayorAVeinticinco = 0;
            bool salir = false;

            while (!salir)
            {
                MostrarMenu();
                int opcion = LeerEntero("Seleccione una opción: ");

                switch (opcion)
                {
                    case 1:
                        double temp = LeerTemperatura("Ingrese el valor de la temperatura: ");

                        sumaTemperaturas += temp;
                        totalIngresos++;
                        
                        if (temp < 0)
                        {
                            bajoCero++;
                        }
                        else if (temp <= 25)
                        {
                            entreCeroYVeinticinco++;
                        }
                        else
                        {
                            mayorAVeinticinco++;
                        }

                        Console.WriteLine("Temperatura registrada.");
                        break;

                    case 2:
                        if (totalIngresos > 0)
                        {
                            MostrarEstadisticas(bajoCero, entreCeroYVeinticinco, mayorAVeinticinco);
                        }
                        else
                        {
                            Console.WriteLine("No hay datos registrados.");
                        }
                        break;

                    case 3:
                        if (totalIngresos > 0)
                        {
                            double promedio = CalcularPromedio(sumaTemperaturas, totalIngresos);
                            Console.WriteLine($"El promedio de las temperaturas es: {promedio:F2}°C");
                        }
                        else
                        {
                            Console.WriteLine("No se puede calcular el promedio sin datos.");
                        }
                        break;

                    case 4:
                        Console.WriteLine("Saliendo del sistema...");
                        salir = true;
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

                if (!salir)
                {
                    Console.WriteLine("\nPresione una tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
        static void MostrarMenu()
        {
            Console.WriteLine("=== SISTEMA DE MONITOREO DE TEMPERATURAS ===");
            Console.WriteLine("1. Ingresar temperatura");
            Console.WriteLine("2. Ver conteo por categorías");
            Console.WriteLine("3. Ver promedio general");
            Console.WriteLine("4. Salir");
        }
        static void MostrarEstadisticas(int bajo, int medio, int alto)
        {
            Console.WriteLine("--- Conteo de Temperaturas ---");
            Console.WriteLine($"Bajo 0°C: {bajo}");
            Console.WriteLine($"Entre 0°C y 25°C: {medio}");
            Console.WriteLine($"Mayores a 25°C: {alto}");
        }
        static double CalcularPromedio(double suma, int cantidad)
        {
            return suma / cantidad;
        }
        static int LeerEntero(string mensaje)
        {
            int resultado;
            Console.Write(mensaje);
            while (!int.TryParse(Console.ReadLine(), out resultado))
            {
                Console.Write("Error. Ingrese un número de opción válido: ");
            }
            return resultado;
        }
        static double LeerTemperatura(string mensaje)
        {
            double resultado;
            Console.Write(mensaje);
            while (!double.TryParse(Console.ReadLine(), out resultado))
            {
                Console.Write("Error. Ingrese un valor numérico para la temperatura: ");
            }
            return resultado;
        }
    }
}