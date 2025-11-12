using System;
using Proyecto.Clases.BlackJack;
using Proyecto.Clases.Uno;

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
                            IniciarUNO();
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
            Console.WriteLine("========== BLACKJACK ==========");
            
            var juego = new JuegoBlackjack(2);
            
            juego.AgregarJugador(new JugadorCauteloso("Erick", 17));
            juego.AgregarJugador(new JugadorTemerario("Eduardo "));
            
            juego.IniciarJuego();
            
            Console.WriteLine("\nPresiona enter para regresar");
            Console.ReadLine();
        }

        static void IniciarUNO()
        {
            Console.Clear();
            Console.WriteLine("============= UNO =============");
            
            var juego = new JuegoUno();
            
            juego.AgregarJugador(new JugadorAleatorioUno("Jugador 1"));
            juego.AgregarJugador(new JugadorCalculadorUno("Jugador 2"));
            juego.AgregarJugador(new JugadorAleatorioUno("Jugador 3"));
            
            juego.IniciarJuego();
            
            Console.WriteLine("\nPresiona enter para regresar");
            Console.ReadLine();
        }
    }
}
