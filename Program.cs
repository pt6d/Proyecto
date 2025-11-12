using System;
using Proyecto.Clases.BlackJack;

namespace Proyecto
{
    class Program
    {
        static void Main()
        {
            bool salir = false;

            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("-------- MENU --------");
                Console.WriteLine("1. Blackjack");
                Console.WriteLine("2. UNO");
                Console.WriteLine("3. Salir");
                Console.Write("Seleccione una opción: ");

                try
                {
                    int opcion = int.Parse(Console.ReadLine());

                    switch (opcion)
                    {
                        case 1:
                            IniciarBlackjack();
                            break;
                        case 2:
                            //IniciarUNO();
                            break;
                        case 3:
                            salir = true;
                            break;
                        default:
                            Console.WriteLine("ERROR, opción invalida");
                            Console.ReadLine();
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("Opción no valida");
                    Console.ReadLine();
                }
            }
        }

        static void IniciarBlackjack()
        {
            Console.Clear();
            Console.WriteLine("--- BLACKJACKK ---\n");

            var juego = new JuegoBlackjack(2);
            juego.AgregarJugador(new JugadorCauteloso("Erik", 17));
            juego.AgregarJugador(new JugadorTemerario("Eduardo GAY"));

            juego.IniciarJuego();

            Console.WriteLine("Presiona enter para regresar");
            Console.ReadLine();
        }

        
    }
}