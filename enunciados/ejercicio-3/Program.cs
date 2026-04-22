using System;

namespace ejercicio_3
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

            decimal totalProductos = 0;
            decimal totalServicios = 0;
            bool salir = false;

            while (!salir)
            {
                MostrarMenu();
                int opcion = LeerEntero("Seleccione una opción: ");

                switch (opcion)
                {
                    case 1:
                        // Registro de ventas
                        int tipo = LeerTipoVenta();
                        decimal monto = LeerDecimal("Ingrese el monto de la venta: ");

                        if (tipo == 1)
                        {
                            totalProductos = AcumularVenta(totalProductos, monto);
                        }
                        else
                        {
                            totalServicios = AcumularVenta(totalServicios, monto);
                        }
                        Console.WriteLine("Venta registrada con éxito.");
                        break;

                    case 2:
                        // Mostrar totales por tipo
                        MostrarTotalesPorTipo(totalProductos, totalServicios);
                        break;

                    case 3:
                        // Mostrar total general
                        decimal totalGeneral = CalcularTotalGeneral(totalProductos, totalServicios);
                        Console.WriteLine($"El monto total general de ventas es: ${totalGeneral}");
                        break;

                    case 4:
                        // Mostrar cuál tipo generó más dinero
                        DeterminarMayorRecaudacion(totalProductos, totalServicios);
                        break;

                    case 5:
                        Console.WriteLine("Saliendo del sistema de ventas...");
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
        static void MostrarMenu()
        {
            Console.WriteLine("=== SISTEMA DE VENTAS POR CATEGORÍA ===");
            Console.WriteLine("1. Ingresar venta");
            Console.WriteLine("2. Mostrar totales por tipo");
            Console.WriteLine("3. Mostrar total general");
            Console.WriteLine("4. Ver categoría con mayor recaudación");
            Console.WriteLine("5. Salir");
        }
        static void MostrarTotalesPorTipo(decimal productos, decimal servicios)
        {
            Console.WriteLine($"Total recaudado en Productos: ${productos}");
            Console.WriteLine($"Total recaudado en Servicios: ${servicios}");
        }
        static void DeterminarMayorRecaudacion(decimal productos, decimal servicios)
        {
            if (productos > servicios)
            {
                Console.WriteLine("La categoría que generó más dinero es: PRODUCTOS");
            }
            else if (servicios > productos)
            {
                Console.WriteLine("La categoría que generó más dinero es: SERVICIOS");
            }
            else
            {
                Console.WriteLine("Ambas categorías generaron la misma cantidad de dinero.");
            }
        }
        static decimal AcumularVenta(decimal acumuladorActual, decimal nuevaVenta)
        {
            return acumuladorActual + nuevaVenta;
        }
        static decimal CalcularTotalGeneral(decimal v1, decimal v2)
        {
            return v1 + v2;
        }
        static int LeerEntero(string mensaje)
        {
            int resultado;
            Console.Write(mensaje);
            while (!int.TryParse(Console.ReadLine(), out resultado))
            {
                Console.Write("Error. Ingrese un número válido: ");
            }
            return resultado;
        }
        static decimal LeerDecimal(string mensaje)
        {
            decimal resultado;
            Console.Write(mensaje);
            while (!decimal.TryParse(Console.ReadLine(), out resultado) || resultado < 0)
            {
                Console.Write("Error. Ingrese un monto numérico positivo: ");
            }
            return resultado;
        }
        static int LeerTipoVenta()
        {
            int tipo;
            Console.WriteLine("Tipo de venta: (1) Producto, (2) Servicio");
            Console.Write("Seleccione tipo: ");
            while (!int.TryParse(Console.ReadLine(), out tipo) || (tipo != 1 && tipo != 2))
            {
                Console.Write("Tipo no válido. Ingrese 1 para Producto o 2 para Servicio: ");
            }
            return tipo;
        }
    }
}
