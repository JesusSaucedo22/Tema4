using System;
using Banco.Modelos;

namespace Banco
{
    class Program
    {
        static void Main(string[] args)
        {
            // Inicializar las cuentas
            CuentaBasica cuentaBasica = new CuentaBasica(300);
            CuentaAhorro cuentaAhorro = new CuentaAhorro(3000);
            CuentaCheques cuentaCheques = new CuentaCheques(5000);

            bool continuar = true;

            while (continuar)  //bucle para seleccionar la operacion deseada
            {
                Console.Clear();
                Console.WriteLine("Tipo de cuenta:");
                Console.WriteLine("1. Cuenta Básica");
                Console.WriteLine("2. Cuenta de Ahorro");
                Console.WriteLine("3. Cuenta de Cheques");
                Console.WriteLine("4. Salir");
                Console.Write("Digite la operación que desee realizar: ");
                int opcionCuenta = int.Parse(Console.ReadLine());

                if (opcionCuenta == 4)
                {
                    continuar = false;
                    break;
                }

                Console.Clear();
                Console.WriteLine("Seleccione la operación:");
                Console.WriteLine("1. Depositar");
                Console.WriteLine("2. Retirar");
                if (opcionCuenta == 3)
                {
                    Console.WriteLine("3. Emitir Cheque");
                }
                Console.WriteLine("4. Realizar Corte Mensual");
                int opcionOperacion = int.Parse(Console.ReadLine());

                switch (opcionCuenta)
                {
                    case 1: // Cuenta Básica
                        RealizarOperacion(cuentaBasica, opcionOperacion);
                        break;
                    case 2: // Cuenta de Ahorro
                        RealizarOperacion(cuentaAhorro, opcionOperacion);
                        break;
                    case 3: // Cuenta de Cheques
                        RealizarOperacion(cuentaCheques, opcionOperacion);
                        break;
                }

                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }

        static void RealizarOperacion(CuentaBancaria cuenta, int opcionOperacion)
        {
            decimal cantidad;
            switch (opcionOperacion)
            {
                case 1: // Depositar
                    Console.Write("Ingrese la cantidad a depositar: ");
                    cantidad = decimal.Parse(Console.ReadLine());
                    cuenta.Depositar(cantidad);
                    Console.WriteLine($"Depósito realizado. Saldo actual: {cuenta.Saldo}");
                    break;
                case 2: // Retirar
                    Console.Write("Ingrese la cantidad a retirar: ");
                    cantidad = decimal.Parse(Console.ReadLine());
                    if (cuenta.Retirar(cantidad))
                    {
                        Console.WriteLine($"Retiro realizado. Saldo actual: {cuenta.Saldo}");
                    }
                    else
                    {
                        Console.WriteLine("Fondos insuficientes.");
                    }
                    break;
                case 3: // Emitir Cheque (solo para Cuenta de Cheques)
                    if (cuenta is CuentaCheques cuentaCheques)
                    {
                        Console.Write("Ingrese la cantidad del cheque: ");
                        cantidad = decimal.Parse(Console.ReadLine());
                        if (cuentaCheques.EmitirCheque(cantidad))
                        {
                            Console.WriteLine($"Cheque emitido. Saldo actual: {cuentaCheques.Saldo}");
                        }
                        else
                        {
                            Console.WriteLine("Cheque rebotado. Fondos insuficientes.");
                        }
                    }
                    break;
                case 4: // Realizar Corte Mensual
                    cuenta.RealizarCorteMensual();
                    Console.WriteLine($"Corte mensual realizado. Saldo actual: {cuenta.Saldo}");
                    break;
            }
        }
    }
}