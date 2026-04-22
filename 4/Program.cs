using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4
{
    internal class Program
    {
        // 4.
        // Crear un sistema de temperaturas:
        // - Ingresar temperatura  
        // - Contar cuántas están bajo 0, entre 0 y 25, y mayores a 25  
        // - Mostrar promedio  
        // - Salir

        // Como usuario necesito ingresar temperaturas para conocer sus estadisticas y promedio
        // Como sistema necesito crear un menu interactivo para que el usuario pueda conocer estadisticas de sus temperaturas

        static int bajoCero = 0, entreCeroVenticinco = 0, mayorAVenticinco = 0, temperaturasTotales = 0;
        static double sumaTemperaturas = 0;
        static bool correrAplicacion = true;
        static void Main(string[] args)
        {
            while (correrAplicacion)
            {
                Console.Clear();
                mostarMenu();
                int opcion = validarInput<int>("");
                switch (opcion)
                {
                    case 1:
                        double temperatura = administrarTemperatura();
                        if (temperatura > 25) mayorAVenticinco++;
                        else if (temperatura >= 0 && temperatura <= 25) entreCeroVenticinco++;
                        else bajoCero++;
                        Console.WriteLine("Temperatura registrada correctamente.");
                        break;
                    case 2:
                        mostrarTemperatura();
                        break;
                    case 3:
                        mostrarPromedio();
                        break;
                    case 4:
                        Console.WriteLine("Saliendo...");
                        correrAplicacion = false;
                        break;
                }
                Console.ReadKey();
            }
        }
        static void mostarMenu()
        {
            Console.WriteLine("1 - Ingresar temperatura\n" +
                              "2 - Ver conteo en catetgorias\n" +
                              "3 - Ver promedio\n" +
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
        static double administrarTemperatura()
        {
            const bool estaValidando = true;
            while (estaValidando)
            {
                try
                {
                    double temperatura = validarInput<double>("Ingresa una temperatura:");
                    if (temperatura < 56.7 && temperatura > -89.2)
                    {
                        sumaTemperaturas += temperatura;
                        temperaturasTotales++;
                        return temperatura;
                    }
                    else Console.WriteLine("Error: fuera de rango.");
                }
                catch
                {
                    Console.WriteLine("Error: dato invalido.");
                }
            }
        }
        static void mostrarTemperatura()
        {
            if (temperaturasTotales > 0)
            {
                Console.WriteLine($"Temperaturas altas: {mayorAVenticinco}\n" +
                                  $"Temperaturas medias: {entreCeroVenticinco}\n" +
                                  $"Temperaturas bajo cero: {bajoCero}");
            }
            else Console.WriteLine("Error: debe ingresar una temperatura como minimo.");
        }
        static void mostrarPromedio()
        {
            if (temperaturasTotales > 0)
            {
                double promedio = sumaTemperaturas / temperaturasTotales;
                Console.WriteLine($"Promedio: {promedio}");
            }
            else Console.WriteLine("Error: debe ingresar una temperatura como minimo.");
        }
    }
}