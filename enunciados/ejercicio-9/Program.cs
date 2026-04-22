using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 9.
            // Crear un sistema de turnos:
            // - Ingresar turno (M/T/N)  
            // - Contar cantidad por turno  
            // - Mostrar cuál turno tuvo más registros  
            // - Mostrar total general  
            // - Salir

            int mañana = 0;
            int tarde = 0;
            int noche = 0;
            bool salir = false;

            while (!salir)
            {
                MostrarMenuPrincipal();
                int opcion = LeerEntero("Seleccione una opción: ");

                switch (opcion)
                {
                    case 1:
                        char turno = LeerTurno();

                        if (turno == 'M')
                        {
                            mañana++;
                        }
                        else if (turno == 'T')
                        {
                            tarde++;
                        }
                        else
                        {
                            noche++;
                        }
                        Console.WriteLine("Turno registrado correctamente.");
                        break;

                    case 2:
                        MostrarEstadisticas(mañana, tarde, noche);
                        break;

                    case 3:
                        int total = CalcularTotal(mañana, tarde, noche);
                        Console.WriteLine($"El total general de turnos registrados es: {total}");
                        break;

                    case 4:
                        DeterminarTurnoMasConcurrido(mañana, tarde, noche);
                        break;

                    case 5:
                        Console.WriteLine("Saliendo del sistema de turnos...");
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
        static void MostrarMenuPrincipal()
        {
            Console.WriteLine("=== SISTEMA DE CONTROL DE TURNOS ===");
            Console.WriteLine("1. Registrar nuevo turno (M/T/N)");
            Console.WriteLine("2. Ver cantidad por turno");
            Console.WriteLine("3. Ver total general");
            Console.WriteLine("4. Ver turno con más registros");
            Console.WriteLine("5. Salir");
        }
        static void MostrarEstadisticas(int m, int t, int n)
        {
            Console.WriteLine("--- Conteo Actual ---");
            Console.WriteLine($"Mañana (M): {m}");
            Console.WriteLine($"Tarde  (T): {t}");
            Console.WriteLine($"Noche  (N): {n}");
        }
        static void DeterminarTurnoMasConcurrido(int m, int t, int n)
        {
            if (m > t && m > n)
            {
                Console.WriteLine("El turno con más registros es: MAÑANA");
            }
            else if (t > m && t > n)
            {
                Console.WriteLine("El turno con más registros es: TARDE");
            }
            else if (n > m && n > t)
            {
                Console.WriteLine("El turno con más registros es: NOCHE");
            }
            else
            {
                Console.WriteLine("Hay un empate entre dos o más turnos.");
            }
        }
        static int CalcularTotal(int m, int t, int n)
        {
            return m + t + n;
        }
        static int LeerEntero(string mensaje)
        {
            int resultado;
            Console.Write(mensaje);
            while (!int.TryParse(Console.ReadLine(), out resultado))
            {
                Console.Write("Error. Ingrese un número de opción: ");
            }
            return resultado;
        }
        static char LeerTurno()
        {
            Console.Write("Ingrese el turno [M-Mañana / T-Tarde / N-Noche]: ");

            while (true)
            {
                string entrada = Console.ReadLine()?.ToUpper() ?? "";

                // Verificamos si la entrada es válida y tiene la longitud correcta
                if (entrada == "M" || entrada == "T" || entrada == "N")
                {
                    return entrada[0];
                }

                Console.Write("Turno no válido. Ingrese M, T o N: ");
            }
        }
    }
}
