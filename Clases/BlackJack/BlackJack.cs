using System.Collections.Generic;
using Proyecto.Interfaces;

namespace Proyecto.Clases.BlackJack
{
    public class JuegoBlackjack
    {
        private List<IJugador> jugadores = new List<IJugador>();
        private IDealer dealer = new DealerBlackjack();
        private BarajaBlackjack baraja = new BarajaBlackjack();
        private int rondas;

        public JuegoBlackjack(int rondas)
        {
            this.rondas = rondas;
        }

        public void AgregarJugador(IJugador jugador)
        {
            jugadores.Add(jugador);
        }

        public void IniciarJuego()
        {
            for (int i = 0; i < rondas; i++)
            {
                var ronda = new RondaBlackjack(jugadores, dealer, baraja);
                ronda.Iniciar();

                foreach (var jugador in jugadores)
                    jugador.Reiniciar();

                dealer.Reiniciar();
            }
        }
    }
}