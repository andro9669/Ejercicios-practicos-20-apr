using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9
{
    // 9.
    // Crear un sistema de turnos:
    // - Ingresar turno (M/T/N)  
    // - Contar cantidad por turno
    // - Mostrar cuál turno tuvo más registros  
    // - Mostrar total general  
    // - Salir
    internal class Program
    {
        static void Main(string[] args)
        {
            int contadorM = 0, contadorT = 0, contadorN = 0;
            bool correrAplicacion = true;
            while (correrAplicacion)
            {
                Console.Clear();
                mostrarMenu();
                int opcion = validarInput<int>("");
                switch (opcion)
                {
                    case 1:
                        IngresoTurno(ref contadorM, ref contadorT, ref contadorN);
                        Console.WriteLine("Turno ingresado correctamente.");
                        break;
                    case 2:
                        mostrarMayor(contadorM, contadorT, contadorN);
                        break;
                    case 3:
                        mostrarGeneral(contadorM, contadorT, contadorN);
                        break;
                    case 4:
                        correrAplicacion = false;
                        break;
                }
                if (correrAplicacion) Console.ReadKey();
            }
        }
        static void mostrarMenu()
        {
            Console.WriteLine("1 - Ingresar turno\n" +
                              "2 - Mostrar cuál turno tuvo más registros\n" +
                              "3 - Mostrar total general\n" +
                              "4 - Salir");
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
        static void IngresoTurno(ref int M, ref int T, ref int N)
        {
            bool estaValidando = true;
            while (estaValidando)
            {
                string turno = validarInput<string>("Ingrese un turno. (M/T/N)").ToUpper();
                switch (turno)
                {
                    case "M":
                        M++;
                        break;
                    case "T":
                        T++;
                        break;
                    case "N":
                        N++;
                        break;
                    default: Console.WriteLine("Error: Fuera de rango"); break;
                }
                break;
            }
        }
        static void mostrarMayor(int M, int T, int N)
        {
            if (M > T && M > N) Console.WriteLine("Mayor registro: mañana");
            else if (T > M && T > N) Console.WriteLine("Mayor registro: tarde");
            else if (N > T && N > M) Console.WriteLine("Mayor registro: noche");
            else Console.WriteLine("Todos tienen la misma cantidad de turnos registrados.");
        }
        static void mostrarGeneral(int M, int T, int N)
        {
            Console.WriteLine($"Mañana: {M}\n" +
                              $"Tarde: {T}\n" +
                              $"Noche: {N}");
        }
    }
}