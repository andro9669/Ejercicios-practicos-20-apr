using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 6.
            // Crear un sistema de números:
            // - Ingresar número  
            // - Contar positivos, negativos y ceros  
            // - Mostrar suma de positivos y suma de negativos  
            // - Mostrar cuál grupo tiene mayor suma  
            // - Salir

            int contadorPositivos = 0;
            int contadorNegativos = 0;
            int contadorCeros = 0;
            double sumaPositivos = 0;
            double sumaNegativos = 0;
            bool salir = false;

            while (!salir)
            {
                MostrarMenu();
                int opcion = LeerEntero("Seleccione una opción: ");

                switch (opcion)
                {
                    case 1:
                        double num = LeerNumero("Ingrese un número: ");

                        if (num > 0)
                        {
                            contadorPositivos++;
                            sumaPositivos += num;
                        }
                        else if (num < 0)
                        {
                            contadorNegativos++;
                            sumaNegativos += num;
                        }
                        else
                        {
                            contadorCeros++;
                        }
                        Console.WriteLine("Número registrado.");
                        break;

                    case 2:
                        MostrarConteo(contadorPositivos, contadorNegativos, contadorCeros);
                        break;

                    case 3:
                        Console.WriteLine($"Suma de positivos: {sumaPositivos}");
                        Console.WriteLine($"Suma de negativos: {sumaNegativos}");
                        break;

                    case 4:
                        DeterminarGrupoMayor(sumaPositivos, sumaNegativos);
                        break;

                    case 5:
                        Console.WriteLine("Saliendo del programa...");
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
            Console.WriteLine("=== SISTEMA DE ANÁLISIS NUMÉRICO ===");
            Console.WriteLine("1. Ingresar número");
            Console.WriteLine("2. Ver conteo (Positivos, Negativos, Ceros)");
            Console.WriteLine("3. Ver sumas por grupo");
            Console.WriteLine("4. Ver cuál grupo tiene la mayor suma");
            Console.WriteLine("5. Salir");
        }
        static void MostrarConteo(int pos, int neg, int ceros)
        {
            Console.WriteLine("--- Resultados de Conteo ---");
            Console.WriteLine($"Positivos: {pos}");
            Console.WriteLine($"Negativos: {neg}");
            Console.WriteLine($"Ceros: {ceros}");
        }
        static void DeterminarGrupoMayor(double sumaP, double sumaN)
        {
            double negativos = sumaN;
            if (negativos < 0)
            {
                negativos = negativos * -1;
            }

            if (sumaP > negativos)
            {
                Console.WriteLine($"El grupo de POSITIVOS tiene una mayor suma ({sumaP}).");
            }
            else if (negativos > sumaP)
            {
                Console.WriteLine($"El grupo de NEGATIVOS tiene una mayor magnitud de suma ({sumaN}).");
            }
            else
            {
                Console.WriteLine("Ambas sumas tienen la misma magnitud o son cero.");
            }
        }
        static int LeerEntero(string mensaje)
        {
            int resultado;
            Console.Write(mensaje);
            while (!int.TryParse(Console.ReadLine(), out resultado))
            {
                Console.Write("Error. Ingrese una opción válida: ");
            }
            return resultado;
        }
        static double LeerNumero(string mensaje)
        {
            double resultado;
            Console.Write(mensaje);
            while (!double.TryParse(Console.ReadLine(), out resultado))
            {
                Console.Write("Error. Ingrese un valor numérico: ");
            }
            return resultado;
        }
    }

}
