using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 3.
            // Crear un sistema de ventas con categorías:
            // - Ingresar venta indicando tipo (1-Producto, 2-Servicio)  
            // - Mostrar total por tipo  
            // - Mostrar total general  
            // - Mostrar cuál tipo generó más dinero  
            // - Salir

            // Como usuario necesito ingresar tipos de ventas para conocer estadisticas generales de las mismas
            // Como sistema necesito crear un menu interactivo para que el usuario pueda conocer estadisticas generales de sus ventas

            double totalProductos = 0, totalServicios = 0, totalGeneral = 0;
            bool correrAplicacion = true;

            while (correrAplicacion)
            {
                mostarMenu();
                int opcion = validarInput<int>("");
                switch (opcion)
                {
                    case 1:
                        int tipoDeVenta = validarVenta();
                        double valorVenta = validarValorDeVenta(tipoDeVenta);
                        if (tipoDeVenta == 1) totalProductos += valorVenta;
                        else totalServicios += valorVenta;
                        totalGeneral += valorVenta;
                        Console.WriteLine("Venta registrada correctamente.");
                        break;
                    case 2:
                        Console.WriteLine($"Total de productos: {totalProductos}");
                        Console.WriteLine($"Total de servicios: {totalServicios}");
                        break;
                    case 3:
                        Console.WriteLine($"Total general: {totalGeneral}");
                        break;
                    case 4:
                        mostarGeneralQueMasGenero();
                        break;
                    case 5:
                        correrAplicacion = false;
                        break;
                    default:
                        Console.WriteLine("Error: fuera de rango.");
                        break;
                }
            }

            T validarInput<T>(string mensaje)
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

            int validarVenta()
            {
                Console.WriteLine("Ingrese el tipo de venta:\n" +
                                  "1 - Productos\n" +
                                  "2 - Servicios");
                int input = 0;
                const bool estaValidando = true;
                while (estaValidando)
                {
                    input = validarInput<int>("");
                    if (input == 1 || input == 2) return input;
                    Console.WriteLine("Error: Fuera de rango.");
                }
            }

            double validarValorDeVenta(int tipoDeVenta)
            {

                const bool estaValidando = true;
                if (tipoDeVenta == 1)
                {
                    Console.WriteLine("Ingrese el valor de la venta del producto.");
                }
                else Console.WriteLine("Ingrese el valor de la venta del servicio.");
                while (estaValidando)
                {
                    double valorDeVenta = validarInput<double>("");
                    if (!(valorDeVenta < 0)) return valorDeVenta;
                    Console.WriteLine("Error: valor invalido.");
                }
            }

            void mostarGeneralQueMasGenero()
            {
                if (totalProductos > totalServicios) Console.WriteLine("La venta que mas genero es la de productos.");
                else if (totalServicios > totalProductos) Console.WriteLine("La venta que mas genero es la de servicios.");
                else Console.WriteLine("Ambas generaron la misma venta");
            }

            void mostarMenu()
            {
                Console.WriteLine("1 - Ingresar venta\n" +
                                  "2 - Mostrar total por tipo\n" +
                                  "3 - Mostrar total general\n" +
                                  "4 - Mostrar cuál tipo generó más dinero\n" +
                                  "5 - Salir");
            }
        }
    }
}