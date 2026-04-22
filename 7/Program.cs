using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7
{
    // 7.
    // Crear un sistema de descuentos acumulados:
    // - Ingresar precio  
    // - Elegir descuento (10%, 20%, 30%)  
    // - Mostrar precio final  
    // - Acumular total sin descuento y con descuento  
    // - Mostrar ahorro total generado  
    // - Salir

    internal class Program
    {
        static double sumaConDescuento = 0, sumaSinDescuento = 0;
        static void Main(string[] args)
        {
            bool correrAplicacion = true;
            while (correrAplicacion)
            {
                Console.Clear();
                mostrarMenu();
                int opcion = validarInput<int>("");
                switch (opcion)
                {
                    case 1:
                        administrarPrecio();
                        break;
                    case 2:
                        totalAhorrado();
                        break;
                    case 3:
                        correrAplicacion = false;
                        break;
                    default: Console.WriteLine("Error: fuera de rango"); break;
                }
                if (correrAplicacion) Console.ReadKey();
            }
        }
        static void mostrarMenu()
        {
            Console.WriteLine("1 - Ingresar precio\n" +
                              "2 - Mostrar ahorro total generado\n" +
                              "3 - Salir");
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
        static void administrarPrecio()
        {
            double precio = validarInput<double>("Ingrese un precio");
            double descuento = 0;
            bool estaValidando = true;
            while (estaValidando)
            {
                descuento = validarInput<int>("1 - 10%\n" +
                                              "2 - 20%\n" +
                                              "3 - 30%");
                switch (descuento)
                {
                    case 1:
                        descuento = precio * 0.10;
                        break;
                    case 2:
                        descuento = precio * 0.20;
                        break;
                    case 3:
                        descuento = precio * 0.30;
                        break;
                    default:
                        Console.WriteLine("Error: fuera de rango.");
                        break;
                }
                double precioConDescuento = precio - descuento;
                Console.WriteLine($"Precio final: {precioConDescuento}");
                sumaSinDescuento += precio;
                sumaConDescuento += precioConDescuento;
                estaValidando = false;
            }
        }
        static void totalAhorrado()
        {
            double ahorroTotal = sumaSinDescuento - sumaConDescuento;
            Console.WriteLine($"El total ahorrado es {ahorroTotal}");
        }
    }
}
