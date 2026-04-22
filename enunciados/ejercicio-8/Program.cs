using System;

namespace ejercicio_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 8.
            // Crear un sistema de control de intentos:
            // - Ingresar número  
            // - Indicar si es par/impar y positivo/negativo  
            // - Contar cuántos cumplen ambas condiciones (ej: par y positivo)  
            // - Mostrar estadísticas completas
            // - Salir

            int parPositivo = 0;
            int parNegativo = 0;
            int imparPositivo = 0;
            int imparNegativo = 0;
            int contadorCeros = 0;
            bool salir = false;

            while (!salir)
            {
                MostrarMenu();
                int opcion = LeerEntero("Seleccione una opción: ");

                switch (opcion)
                {
                    case 1:
                        int num = LeerEntero("Ingrese un número entero: ");

                        if (num == 0)
                        {
                            Console.WriteLine("El número es CERO.");
                            contadorCeros++;
                        }
                        else
                        {
                            bool esPar = VerificarSiEsPar(num);
                            bool esPositivo = VerificarSiEsPositivo(num);

                            if (esPar)
                            {
                                if (esPositivo)
                                {
                                    Console.WriteLine("Resultado: PAR y POSITIVO.");
                                    parPositivo++;
                                }
                                else
                                {
                                    Console.WriteLine("Resultado: PAR y NEGATIVO.");
                                    parNegativo++;
                                }
                            }
                            else
                            {
                                if (esPositivo)
                                {
                                    Console.WriteLine("Resultado: IMPAR y POSITIVO.");
                                    imparPositivo++;
                                }
                                else
                                {
                                    Console.WriteLine("Resultado: IMPAR y NEGATIVO.");
                                    imparNegativo++;
                                }
                            }
                        }
                        break;

                    case 2:
                        MostrarEstadisticas(parPositivo, parNegativo, imparPositivo, imparNegativo, contadorCeros);
                        break;

                    case 3:
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
            Console.WriteLine("=== SISTEMA DE CLASIFICACIÓN DE NÚMEROS ===");
            Console.WriteLine("1. Ingresar número y clasificar");
            Console.WriteLine("2. Mostrar estadísticas completas");
            Console.WriteLine("3. Salir");
        }
        static void MostrarEstadisticas(int pp, int pn, int ip, int ine, int c)
        {
            Console.WriteLine("--- ESTADÍSTICAS DE INGRESOS ---");
            Console.WriteLine($"Pares Positivos:   {pp}");
            Console.WriteLine($"Pares Negativos:   {pn}");
            Console.WriteLine($"Impares Positivos: {ip}");
            Console.WriteLine($"Impares Negativos: {ine}");
            Console.WriteLine($"Ceros ingresados:  {c}");
        }
        static bool VerificarSiEsPar(int n)
        {
            if (n % 2 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static bool VerificarSiEsPositivo(int n)
        {
            if (n > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static int LeerEntero(string mensaje)
        {
            int resultado;
            Console.Write(mensaje);
            while (!int.TryParse(Console.ReadLine(), out resultado))
            {
                Console.Write("Error. Ingrese un número entero: ");
            }
            return resultado;
        }
    }
}
