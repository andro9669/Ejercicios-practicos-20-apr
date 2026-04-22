using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2
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

            // Como usuario necesito ingresar mis notas para conocer estadisticas generales de las mismas
            // Como sistema necesito crear un menu para que el usuario pueda conocer estadisticas generales de sus notas

            bool correrAplicacion = true;
            double sumaNotas = 0;
            int cantidadNotas = 0;
            double notaMaxima = double.MinValue;
            double notaMinima = double.MaxValue;

            while (correrAplicacion)
            {
                menu();
                int opcion = validarInput<int>("");
                if (opcion >= 2 && opcion <= 4 && cantidadNotas == 0)
                {
                    Console.WriteLine("Debe ingresar como minimo una nota");
                    continue;
                }
                switch (opcion)
                {
                    case 1:
                        double nota = manejoNotas();
                        actualizarEstadisticas(nota);
                        break;
                    case 2:
                        Console.WriteLine($"Promedio: {sumaNotas / cantidadNotas}");
                        break;
                    case 3:
                        Console.WriteLine($"Nota mayor: {notaMaxima}.\n" +
                                          $"Nota menor: {notaMinima}.");
                        break;
                    case 4:
                        string estadoAcademico;
                        estadoAcademico = (sumaNotas / cantidadNotas >= 6) ? "aprobado" : "desaprobado";
                        Console.WriteLine($"Estado academico: {estadoAcademico}");
                        break;
                    case 5:
                        correrAplicacion = false;
                        break;
                }
            }

            void menu()
            {
                Console.WriteLine("1 - Ingresar nota\n" +
                                  "2 - Mostrar promedio\n" +
                                  "3 - Mostrar mejor y peor nota\n" +
                                  "4 - Indicar estado academico\n" +
                                  "5 - Salir\n");
            }

            T validarInput<T>(string mensaje)
            {
                if (mensaje != "") Console.WriteLine(mensaje);
                while (true)
                {
                    try
                    {
                        return (T)Convert.ChangeType(Console.ReadLine(), typeof(T));
                    }
                    catch
                    {
                        Console.WriteLine("Error: tipo de dato invalido.");
                    }
                }
            }

            double manejoNotas()
            {
                double nota = validarInput<double>("Ingrese una nota: ");
                while (!(nota >= 0 && nota <= 10))
                {
                    Console.WriteLine("Error: nota fuera de rango.");
                    nota = validarInput<double>("");
                }
                Console.WriteLine("Nota ingresada exitosamente.");
                return nota;
            }

            void actualizarEstadisticas(double nota)
            {
                sumaNotas += nota;
                cantidadNotas++;
                if (nota > notaMaxima) notaMaxima = nota;
                if (nota < notaMinima) notaMinima = nota;
            }
        }
    }
}