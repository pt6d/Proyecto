using System;
using System.Collections.Generic;
using Proyecto.Interfaces;

namespace Proyecto.Clases.BlackJack
{
    public class RondaBlackjack
    {
        private List<IJugador> jugadores;
        private IDealer dealer;
        private BarajaBlackjack baraja;

        public RondaBlackjack(List<IJugador> jugadores, IDealer dealer, BarajaBlackjack baraja)
        {
            this.jugadores = jugadores;
            this.dealer = dealer;
            this.baraja = baraja;
        }

        public void Iniciar()
        {
            Console.WriteLine("\n----- Nueva Ronda -----\n");

            dealer.Barajear(baraja);

    
            foreach (var jugador in jugadores)
            {
                jugador.RecibirCarta(baraja.RepartirCarta());
                jugador.RecibirCarta(baraja.RepartirCarta());
            }

            dealer.RecibirCarta(baraja.RepartirCarta());
            dealer.RecibirCarta(baraja.RepartirCarta());

       
            foreach (var jugador in jugadores)
            {
                while (jugador.DeseaCarta() && ((JugadorBaseBlackjack)jugador).CalcularPuntos() <= 21)
                    jugador.RecibirCarta(baraja.RepartirCarta());

                jugador.MostrarMano();
            }

    
            while (dealer.DeseaCarta())
                dealer.RecibirCarta(baraja.RepartirCarta());

            dealer.MostrarMano();

            int puntosDealer = ((JugadorBaseBlackjack)dealer).CalcularPuntos();

            // Compara los resultados de cada juagdor
            foreach (var jugador in jugadores)
            {
                int puntosJugador = ((JugadorBaseBlackjack)jugador).CalcularPuntos();

                if (puntosJugador > 21)
                    Console.WriteLine($"{jugador.Nombre} se pasó de 21. Ha perdido");
                else if (puntosDealer > 21 || puntosJugador > puntosDealer)
                    Console.WriteLine($"{jugador.Nombre} gana la ronda");
                else if (puntosJugador == puntosDealer)
                    Console.WriteLine($"{jugador.Nombre} empata con el dealer");
                else
                    Console.WriteLine($"{jugador.Nombre} ha perdido");
            }

            Console.WriteLine("\n----- FIN DE LA RONDA -----\n");
        }
    }
}
