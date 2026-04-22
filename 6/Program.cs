using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace _6
{
    // 6.
    // Crear un sistema de números:
    // - Ingresar número  
    // - Contar positivos, negativos y ceros  
    // - Mostrar suma de positivos y suma de negativos  
    // - Mostrar cuál grupo tiene mayor suma  
    // - Salir
    internal class Program
    {
        static int cantidadPositivos = 0, cantidadNegativos = 0, Cantidad0 = 0;
        static double sumaPositivos = 0, sumaNegativos = 0, suma0 = 0;
        static void Main(string[] args)
        {
            bool correrAplicacion = true;
            while (correrAplicacion)
            {
                Console.Clear();
                mostarMenu();
                double opcion = validarInput<double>("");
                switch (opcion)
                {
                    case 1:
                        clasificarNumero();
                        break;
                    case 2:
                        mostarCantidades();
                        break;
                    case 3:
                        mostrarSumas();
                        break;
                    case 4:
                        mostrarSumaMayor();
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
        static void mostarMenu()
        {
            Console.WriteLine("1 - Ingresar número\n" +
                              "2 - Mostrar cantidad de positivos, negativos y ceros\n" +
                              "3 - Mostrar suma de positivos y suma de negativos\n" +
                              "4 - Mostrar cuál grupo tiene mayor suma\n" +
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
        static void clasificarNumero()
        {
            double numero = validarInput<double>("Ingrese un numero.");
            if (numero > 0)
            {
                cantidadPositivos++;
                sumaPositivos += numero;
            }
            else if (numero == 0)
            {
                Cantidad0++;
                suma0 += numero;
            }
            else
            {
                cantidadNegativos++;
                sumaNegativos += Math.Abs(numero);
            }
            Console.WriteLine("Numero registrado correctamente.");

        }
        static void mostarCantidades()
        {
            Console.WriteLine($"Positivos: {cantidadPositivos}\n" +
                              $"Iguales a 0: {Cantidad0}\n" +
                              $"Negativos: {cantidadNegativos}");
        }
        static void mostrarSumas()
        {
            Console.WriteLine($"Suma de positivos: {sumaPositivos}\n" +
                              $"Suma de negativos: {sumaNegativos}");
        }
        static void mostrarSumaMayor()
        {
            if (sumaPositivos > sumaNegativos) Console.WriteLine("La suma de numeros positivos es mayor.");
            else if (sumaNegativos > sumaPositivos) Console.WriteLine("La suma de numeros negativos es mayor");
            else Console.WriteLine("Ambas sumas son iguales");
        }
    }
}
