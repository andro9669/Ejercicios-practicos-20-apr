using System;

namespace ejercicio_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 5.
            // Crear un sistema de sueldos:
            // - Ingresar sueldo  
            // - Contar cuántos superan 800000  
            // - Mostrar promedio  
            // - Mostrar porcentaje de sueldos altos  
            // - Salir

            decimal sumaSueldos = 0;
            int totalSueldos = 0;
            int sueldosAltos = 0;
            bool salir = false;

            while (!salir)
            {
                MostrarMenu();
                int opcion = LeerEntero("Seleccione una opción: ");

                switch (opcion)
                {
                    case 1:
                        decimal sueldo = LeerDecimal("Ingrese el monto del sueldo: ");

                        sumaSueldos += sueldo;
                        totalSueldos++;

                        if (sueldo > 800000)
                        {
                            sueldosAltos++;
                        }

                        Console.WriteLine("Sueldo registrado correctamente.");
                        break;

                    case 2:
                        if (totalSueldos > 0)
                        {
                            Console.WriteLine($"Cantidad de sueldos que superan los $800.000: {sueldosAltos}");
                        }
                        else
                        {
                            Console.WriteLine("No hay sueldos registrados.");
                        }
                        break;

                    case 3:
                        if (totalSueldos > 0)
                        {
                            decimal promedio = CalcularPromedio(sumaSueldos, totalSueldos);
                            Console.WriteLine($"El promedio de sueldos es: ${promedio:N2}");
                        }
                        else
                        {
                            Console.WriteLine("No hay datos para calcular el promedio.");
                        }
                        break;

                    case 4:
                        if (totalSueldos > 0)
                        {
                            double porcentaje = CalcularPorcentaje(sueldosAltos, totalSueldos);
                            Console.WriteLine($"El porcentaje de sueldos altos (> $800.000) es: {porcentaje}%");
                        }
                        else
                        {
                            Console.WriteLine("No hay datos para calcular el porcentaje.");
                        }
                        break;

                    case 5:
                        Console.WriteLine("Saliendo del sistema de sueldos...");
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
            Console.WriteLine("=== SISTEMA DE GESTIÓN DE SUELDOS ===");
            Console.WriteLine("1. Ingresar sueldo");
            Console.WriteLine("2. Contar sueldos mayores a $800.000");
            Console.WriteLine("3. Mostrar promedio general");
            Console.WriteLine("4. Mostrar porcentaje de sueldos altos");
            Console.WriteLine("5. Salir");
        }
        static decimal CalcularPromedio(decimal suma, int cantidad)
        {
            return suma / cantidad;
        }

        static double CalcularPorcentaje(int parte, int total)
        {
            return (double)parte * 100 / total;
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

        static decimal LeerDecimal(string mensaje)
        {
            decimal resultado;
            Console.Write(mensaje);
            while (!decimal.TryParse(Console.ReadLine(), out resultado) || resultado < 0)
            {
                Console.Write("Error. Ingrese un monto de sueldo válido: ");
            }
            return resultado;
        }
    }
}

