using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8
{

    internal class Program
    {
        // 8.
        // Crear un sistema de control de intentos:
        // - Ingresar número  
        // - Indicar si es par/impar y positivo/negativo  
        // - Contar cuántos cumplen ambas condiciones (ej: par y positivo)  
        // - Mostrar estadísticas completas
        // - Salir
        static void Main(string[] args)
        {
            bool correrAplicacion = true;
            int Pares = 0, Impares = 0, Positivos = 0, Negativos = 0, Ceros = 0;
            int ParesPositivos = 0, ParesNegativos = 0, ImparesPositivos = 0, ImparesNegativos = 0;
            while (correrAplicacion)
            {
                Console.Clear();
                mostrarMenu();
                int opcion = validarNumero("");
                switch (opcion)
                {
                    case 1:
                        int num = validarNumero("Ingrese un numero");
                        bool esPar = validarPar(num);
                        bool esPositivo = validarPositivo(num);
                        if (num == 0)
                        {
                            Console.WriteLine("El numero es cero.");
                            Ceros++;
                        }
                        else if (esPar)
                        {
                            if (esPositivo)
                            {
                                Console.WriteLine("El numero es par y positivo");
                                ParesPositivos++;
                            }
                            else
                            {
                                Console.WriteLine("El numero es par y negativo.");
                                ParesNegativos++;
                            }
                        }
                        else
                        {
                            if (esPositivo)
                            {
                                Console.WriteLine("El numero es impar y positivo");
                                ImparesPositivos++;
                            }
                            else
                            {
                                Console.WriteLine("El numero es impar y negativo");
                                ImparesNegativos++;
                            }
                        }
                        break;
                    case 2:
                        mostrarEstadisticas(ParesPositivos, ParesNegativos, ImparesPositivos, ImparesNegativos);
                        break;
                    case 3:
                        correrAplicacion = false;
                        break;
                }
                if (correrAplicacion == true) Console.ReadKey();
            }
        }
        static void mostrarMenu()
        {
            Console.WriteLine("1 - Ingresar número\n" +
                              "2 - Mostrar estadísticas completas\n" +
                              "3 - Salir");
        }
        static int validarNumero(string mensaje)
        {
            const bool estaValidando = true;
            if (mensaje != "") Console.WriteLine(mensaje);
            while (estaValidando)
            {
                if (!int.TryParse(Console.ReadLine(), out int input)) Console.WriteLine("Error: dato invalido");
                else return input;
            }
        }
        static bool validarPar(int n)
        {
            bool r;
            if (n % 2 == 0) r = true;
            else r = false;
            return r;
        }
        static bool validarPositivo(int n)
        {
            bool r;
            if (n > 0) r = true;
            else r = false;
            return r;
        }
        static void mostrarEstadisticas(int pp, int pn, int ip, int i_n)
        {
            Console.WriteLine($"Pares y positivos: {pp}\n" +
                              $"Pares y negativos: {pn}\n" +
                              $"Impares y positivos: {ip}\n" +
                              $"Impares y negativos: {i_n}");
        }
    }
}