using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10
{
    // 10.
    // Crear un juego de adivinanza mejorado:
    // - Número fijo (ej: 25)  
    // - Indicar si está “cerca” (diferencia ≤ 5)  
    // - Limitar a 5 intentos por ronda  
    // - Mostrar si ganó o perdió  
    // - Permitir reiniciar juego  
    // - Salir
    internal class Program
    {
        static void Main(string[] args)
        {
            bool correrAplicacion = true;
            int numeroAdivinanza = 25;
            int maxIntentos = 5;
            int intentosUsuario = 0;
            while (correrAplicacion)
            {
                Console.Clear();
                MostrarMenu();
                int opcion = ValidarEntero("");
                switch (opcion)
                {
                    case 1:
                        bool enJuego = true;
                        while (enJuego)
                        {
                            if (intentosUsuario < maxIntentos)
                            {
                                intentosUsuario++;
                                int numeroUsuario = ValidarEntero("Ingrese un numero:");
                                bool gano = comprobarVictoria(numeroUsuario, numeroAdivinanza);
                                if (gano)
                                {
                                    Console.WriteLine($"Ganaste, el numero era {numeroUsuario}");
                                    enJuego = false;
                                }
                                else
                                {
                                    bool estaCerca = comprobarCercania(numeroUsuario, numeroAdivinanza);
                                    if (estaCerca)
                                    {
                                        Console.WriteLine("Estas cerca.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Lejos del numero verdadero.");
                                    }
                                }
                            }
                            else { Console.WriteLine($"Sobrepasaste los intentos maximos. El numero era {numeroAdivinanza}."); enJuego = false; }
                        }
                        break;
                    case 2:
                        correrAplicacion = true;
                        break;
                    default: Console.WriteLine("Error: fuera de rango"); break;
                }
                if (correrAplicacion) Console.ReadKey();
            }
        }
        static void MostrarMenu()
        {
            Console.WriteLine("1 - Adivinar numero\n" +
                              "2 - Salir");
        }
        static int ValidarEntero(string mensaje)
        {
            if (mensaje != "") Console.WriteLine(mensaje);
            int input = 0;
            while (!int.TryParse(Console.ReadLine(), out input)) Console.WriteLine("Error: dato invalido.");
            return input;
        }
        static bool comprobarVictoria(int n, int n_a)
        {
            if (n == n_a) return true;
            else return false;
        }
        static bool comprobarCercania(int n, int n_a)
        {
            if (n > n_a)
            {
                if ((n - n_a) <= 5) return true;
                else return false;
            }
            else
            {
                if ((n_a - n) <= 5) return true;
                else return false;
            }
        }
    }
}