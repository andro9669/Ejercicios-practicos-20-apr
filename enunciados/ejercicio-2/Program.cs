using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 2.
            // Crear un sistema de notas:
            // - Ingresar nota  
            // - Mostrar promedio  
            // - Mostrar mejor y peor nota  
            // - Indicar si el alumno está aprobado (aprueba con un promedio de 6 o más)
            // - Salir

            double sumaNotas = 0;
            int cantidadNotas = 0;
            double notaMasAlta = double.MinValue;
            double notaMasBaja = double.MaxValue;
            bool salir = false;

            while (!salir)
            {
                MostrarMenu();
                int opcion = LeerEntero("Seleccione una opción: ");

                switch (opcion)
                {
                    case 1:
                        double nuevaNota = LeerNota("Ingrese la nota del alumno (1-10): ");

                        // Actualización de estadísticas
                        sumaNotas += nuevaNota;
                        cantidadNotas++;
                        notaMasAlta = CalcularMaximo(notaMasAlta, nuevaNota);
                        notaMasBaja = CalcularMinimo(notaMasBaja, nuevaNota);

                        Console.WriteLine("Nota registrada con éxito.");
                        break;

                    case 2:
                        if (cantidadNotas > 0)
                        {
                            double promedio = CalcularPromedio(sumaNotas, cantidadNotas);
                            Console.WriteLine($"El promedio actual es: {promedio:F2}");
                        }
                        else
                        {
                            Console.WriteLine("No hay notas registradas aún.");
                        }
                        break;

                    case 3:
                        if (cantidadNotas > 0)
                        {
                            Console.WriteLine($"La nota más alta es: {notaMasAlta}");
                            Console.WriteLine($"La nota más baja es: {notaMasBaja}");
                        }
                        else
                        {
                            Console.WriteLine("No hay notas registradas aún.");
                        }
                        break;

                    case 4:
                        if (cantidadNotas > 0)
                        {
                            double promedioFinal = CalcularPromedio(sumaNotas, cantidadNotas);
                            DeterminarEstadoFinal(promedioFinal);
                        }
                        else
                        {
                            Console.WriteLine("No hay datos suficientes para determinar el estado.");
                        }
                        break;

                    case 5:
                        Console.WriteLine("Saliendo del sistema de gestión académica...");
                        salir = true;
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

                if (!salir)
                {
                    Console.WriteLine("\nPresione una tecla para volver al menú...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
        static void MostrarMenu()
        {
            Console.WriteLine("=== SISTEMA DE GESTIÓN DE NOTAS ===");
            Console.WriteLine("1. Ingresar nota");
            Console.WriteLine("2. Mostrar promedio");
            Console.WriteLine("3. Mostrar mejor y peor nota");
            Console.WriteLine("4. Consultar estado (Aprobado/Desaprobado)");
            Console.WriteLine("5. Salir");
        }
        static void DeterminarEstadoFinal(double promedio)
        {
            Console.WriteLine($"Promedio obtenido: {promedio:F2}");
            if (promedio >= 6)
            {
                Console.WriteLine("Estado: APROBADO");
            }
            else
            {
                Console.WriteLine("Estado: DESAPROBADO");
            }
        }
        static double CalcularPromedio(double suma, int cantidad)
        {
            return suma / cantidad;
        }
        static double CalcularMaximo(double actual, double nueva)
        {
            if (nueva > actual)
            {
                return nueva;
            }
            else
            {
                return actual;
            }
        }
        static double CalcularMinimo(double actual, double nueva)
        {
            if (nueva < actual)
            {
                return nueva;
            }
            else
            {
                return actual;
            }
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
        static double LeerNota(string mensaje)
        {
            double nota;
            Console.Write(mensaje);
            // Valida que sea número y que esté en el rango académico (ej. 1 a 10)
            while (!double.TryParse(Console.ReadLine(), out nota) || nota < 0 || nota > 10)
            {
                Console.Write("Nota inválida. Ingrese un valor entre 0 y 10: ");
            }
            return nota;
        }
    }
}
