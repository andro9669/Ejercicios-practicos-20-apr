using System;

namespace ejercicio_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 7.
            // Crear un sistema de descuentos acumulados:
            // - Ingresar precio  
            // - Elegir descuento (10%, 20%, 30%)  
            // - Mostrar precio final  
            // - Acumular total sin descuento y con descuento  
            // - Mostrar ahorro total generado  
            // - Salir

            decimal acumuladoSinDescuento = 0;
            decimal acumuladoConDescuento = 0;
            bool salir = false;

            while (!salir)
            {
                MostrarMenuPrincipal();
                int opcion = LeerEntero("Seleccione una opción: ");

                switch (opcion)
                {
                    case 1:
                        decimal precioOriginal = LeerDecimal("Ingrese el precio del producto: ");
                        int tipoDescuento = ElegirPorcentajeDescuento();

                        decimal montoDescontado = CalcularMontoDescuento(precioOriginal, tipoDescuento);
                        decimal precioFinal = precioOriginal - montoDescontado;

                        acumuladoSinDescuento += precioOriginal;
                        acumuladoConDescuento += precioFinal;

                        Console.WriteLine($"\nPrecio Original: ${precioOriginal}");
                        Console.WriteLine($"Descuento aplicado: {tipoDescuento}% (-${montoDescontado})");
                        Console.WriteLine($"Precio Final: ${precioFinal}");
                        break;

                    case 2:
                        if (acumuladoSinDescuento > 0)
                        {
                            MostrarReporte(acumuladoSinDescuento, acumuladoConDescuento);
                        }
                        else
                        {
                            Console.WriteLine("No hay ventas registradas todavía.");
                        }
                        break;

                    case 3:
                        Console.WriteLine("Saliendo del sistema...");
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
            Console.WriteLine("=== SISTEMA DE DESCUENTOS ACUMULADOS ===");
            Console.WriteLine("1. Registrar nueva venta con descuento");
            Console.WriteLine("2. Mostrar totales y ahorro generado");
            Console.WriteLine("3. Salir");
        }
        static void MostrarReporte(decimal sinDesc, decimal conDesc)
        {
            decimal ahorroTotal = sinDesc - conDesc;
            Console.WriteLine("--- REPORTE ACUMULADO ---");
            Console.WriteLine($"Total bruto (sin descuentos): ${sinDesc}");
            Console.WriteLine($"Total neto (con descuentos): ${conDesc}");
            Console.WriteLine($"Ahorro total para los clientes: ${ahorroTotal}");
        }
        static decimal CalcularMontoDescuento(decimal precio, int porcentaje)
        {
            return precio * (porcentaje / 100.0m);
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
            while (!decimal.TryParse(Console.ReadLine(), out resultado) || resultado <= 0)
            {
                Console.Write("Error. Ingrese un precio mayor a 0: ");
            }
            return resultado;
        }
        static int ElegirPorcentajeDescuento()
        {
            int opcion;
            Console.WriteLine("\nSeleccione el descuento a aplicar:");
            Console.WriteLine("1. 10%");
            Console.WriteLine("2. 20%");
            Console.WriteLine("3. 30%");
            Console.Write("Opción: ");

            while (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > 3)
            {
                Console.Write("Opción inválida (1, 2 o 3): ");
            }

            if (opcion == 1)
            {
                return 10;
            }
            else if (opcion == 2)
            {
                return 20;
            }
            else
            {
                return 30;
            }
        }
    }
}
