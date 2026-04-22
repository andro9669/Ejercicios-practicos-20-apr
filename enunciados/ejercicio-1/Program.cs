using System;

namespace ejercicio_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1.
            // Crear un sistema de cajero automático con menú:
            // - Ingresar PIN (máximo 3 intentos, si falla se bloquea)
            // - Depositar dinero  
            // - Retirar dinero (validar saldo)  
            // - Ver saldo  
            // - Salir

            decimal saldo = 1000.00m;
            int pinCorrecto = 1234;
            int intentosMaximos = 3;
            bool autenticado = false;
            bool salir = false;

            autenticado = RealizarAutenticacion(pinCorrecto, intentosMaximos);

            if (autenticado)
            {
                while (!salir)
                {
                    MostrarMenu();
                    int opcion = LeerEntero("Seleccione una opción: ");

                    switch (opcion)
                    {
                        case 1:
                            decimal montoDeposito = LeerDecimal("Monto a depositar: ");
                            saldo = Depositar(saldo, montoDeposito);
                            break;

                        case 2:
                            decimal montoRetiro = LeerDecimal("Monto a retirar: ");
                            if (ValidarSaldoSuficiente(saldo, montoRetiro))
                            {
                                saldo = Retirar(saldo, montoRetiro);
                                Console.WriteLine("Retiro exitoso.");
                            }
                            else
                            {
                                Console.WriteLine("Saldo insuficiente.");
                            }
                            break;

                        case 3:
                            MostrarSaldo(saldo);
                            break;

                        case 4:
                            Console.WriteLine("Cerrando sesión. Gracias por usar el sistema.");
                            salir = true;
                            break;

                        default:
                            Console.WriteLine("Opción no válida.");
                            break;
                    }

                    if (!salir)
                    {
                        Console.WriteLine("\nPresione cualquier tecla para continuar...");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
            }
            else
            {
                Console.WriteLine("Sistema bloqueado por demasiados intentos fallidos.");
            }

            Console.WriteLine("Fin del programa.");
            Console.ReadKey();
        }
        

        static void MostrarMenu()
        {
            Console.WriteLine("=== CAJERO AUTOMÁTICO ===");
            Console.WriteLine("1. Depositar dinero");
            Console.WriteLine("2. Retirar dinero");
            Console.WriteLine("3. Ver saldo");
            Console.WriteLine("4. Salir");
        }

        static void MostrarSaldo(decimal saldo)
        {
            Console.WriteLine($"Su saldo actual es: ${saldo}");
        }

        static decimal Depositar(decimal saldoActual, decimal monto)
        {
            if (monto > 0)
            {
                return saldoActual + monto;
            }
            Console.WriteLine("El monto debe ser positivo.");
            return saldoActual;
        }

        static decimal Retirar(decimal saldoActual, decimal monto)
        {
            return saldoActual - monto;
        }

        static bool ValidarSaldoSuficiente(decimal saldoActual, decimal monto)
        {
            return monto > 0 && monto <= saldoActual;
        }

        static bool RealizarAutenticacion(int pinCorrecto, int intentosMaximos)
        {
            int intentos = 0;
            while (intentos < intentosMaximos)
            {
                int pinIngresado = LeerEntero($"Ingrese su PIN (Intento {intentos + 1}/{intentosMaximos}): ");

                if (pinIngresado == pinCorrecto)
                {
                    Console.WriteLine("Acceso concedido.\n");
                    return true;
                }

                intentos++;
                Console.WriteLine("PIN incorrecto.");
            }
            return false;
        }

        static int LeerEntero(string mensaje)
        {
            int resultado;
            Console.Write(mensaje);
            while (!int.TryParse(Console.ReadLine(), out resultado))
            {
                Console.Write("Entrada no válida. Ingrese un número entero: ");
            }
            return resultado;
        }

        static decimal LeerDecimal(string mensaje)
        {
            decimal resultado;
            Console.Write(mensaje);
            while (!decimal.TryParse(Console.ReadLine(), out resultado))
            {
                Console.Write("Entrada no válida. Ingrese un monto numérico: ");
            }
            return resultado;
        }
    }
}
