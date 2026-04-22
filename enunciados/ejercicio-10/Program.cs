using System;

namespace ejercicio_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 10.
            // Crear un juego de adivinanza mejorado:
            // - Número fijo (ej: 25)  
            // - Indicar si está “cerca” (diferencia ≤ 5)  
            // - Limitar a 5 intentos por ronda  
            // - Mostrar si ganó o perdió  
            // - Permitir reiniciar juego  
            // - Salir

            int numeroSecreto = 25;
            int maxIntentos = 5;
            bool cerrarAplicacion = false;

            while (!cerrarAplicacion)
            {
                MostrarMenuPrincipal();
                int opcionMenu = LeerEntero("Seleccione una opción: ");

                switch (opcionMenu)
                {
                    case 1:
                        // Iniciar una ronda de juego
                        JugarRonda(numeroSecreto, maxIntentos);
                        break;

                    case 2:
                        Console.WriteLine("Gracias por jugar.");
                        cerrarAplicacion = true;
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

                if (!cerrarAplicacion)
                {
                    Console.WriteLine("\nPresione una tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }
        static void MostrarMenuPrincipal()
        {
            Console.WriteLine("=== JUEGO DE ADIVINANZA MEJORADO ===");
            Console.WriteLine("1. Nueva Partida");
            Console.WriteLine("2. Salir");
        }
        static void JugarRonda(int secreto, int limite)
        {
            int intentosUsados = 0;
            bool adivino = false;

            Console.WriteLine($"\nTienes {limite} intentos para adivinarlo.");

            while (intentosUsados < limite && !adivino)
            {
                int numeroUsuario = LeerEntero($"Intentos {intentosUsados + 1}/{limite}. Ingrese su número: ");
                intentosUsados++;

                if (numeroUsuario == secreto)
                {
                    adivino = true;
                }
                else
                {
                    // Lógica para indicar si está cerca (Sin Math.Abs)
                    if (VerificarCercania(secreto, numeroUsuario))
                    {
                        Console.WriteLine("¡Estás cerca! (Diferencia de 5 o menos)");
                    }
                    else
                    {
                        Console.WriteLine("Estás lejos.");
                    }
                }
            }

            // Resultado final de la ronda
            if (adivino)
            {
                Console.WriteLine("\n¡FELICITACIONES! Adivinaste el número.");
            }
            else
            {
                Console.WriteLine($"\nTe quedaste sin intentos. El número era {secreto}.");
            }
        }
        static bool VerificarCercania(int secreto, int usuario)
        {
            int diferencia;

            if (secreto > usuario)
            {
                diferencia = secreto - usuario;
            }
            else
            {
                diferencia = usuario - secreto;
            }

            if (diferencia <= 5) return true;
            else return false;
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
