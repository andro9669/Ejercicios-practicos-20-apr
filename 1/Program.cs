using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
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

            // Como usuario necesito ingresar un pin para poder acceder a un menu donde administrar mi dinero
            // Como sistema necesito implementar un menu para que el usuario una vez valide su pin pueda administrar su dinero

            validarPIN(3);
            bool correrAplicacion = true;
            double saldo = 0;
            while (correrAplicacion)
            {
                Menu();
                int opcion = validarInput<int>("");
                switch (opcion)
                {
                    case 1:
                        while (true)
                        {
                            double dineroDepositado = validarInput<double>("Ingrese su deposito");
                            if (dineroDepositado > 0)
                            {
                                saldo += dineroDepositado;
                                Console.WriteLine("Cantidad de dinero ingresada exitosamente.");
                                break;
                            }
                            Console.WriteLine("Error: cantidad de dinero invalida");
                        }
                        break;
                    case 2:
                        while (true)
                        {
                            double dineroRetirado = validarInput<double>("Ingrese su retiro");
                            if (dineroRetirado > 0 && dineroRetirado <= saldo)
                            {
                                saldo -= dineroRetirado;
                                Console.WriteLine("Cantidad de dinero retirada exitosamente.");
                                break;
                            }
                            Console.WriteLine("Error: cantidad de dinero invalida");
                        }
                        break;
                    case 3:
                        Console.WriteLine($"Saldo: {saldo}");
                        break;
                    case 4:
                        correrAplicacion = false;
                        Console.WriteLine("Saliendo. . .");
                        break;
                }
            }

            void Menu()
            {
                Console.WriteLine("1 - Depositar dinero\n" +
                                  "2 - Retirar dinero\n" +
                                  "3 - Ver saldo\n" +
                                  "4 - Salir");
            }

            bool validarPIN(int maximosIntentos)
            {
                int PIN = 1234;
                int usuarioPIN;
                int intentosUsuario = 0;
                bool PINValido = false;
                while (!PINValido)
                {
                    usuarioPIN = validarInput<int>("Ingrese el PIN: ");
                    if (usuarioPIN == PIN)
                    {
                        PINValido = true;
                        Console.WriteLine("PIN correcto ingresado exitosamente.");
                        return PINValido;
                    }
                    intentosUsuario++;
                    Console.WriteLine("PIN invalido");
                    if (intentosUsuario == maximosIntentos)
                    {
                        Console.WriteLine("Se excedio la cantidad maxima de intentos. Se va a cerrar la aplicacion.");
                        break;
                    }
                }
                return PINValido;
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
        }
    }
}