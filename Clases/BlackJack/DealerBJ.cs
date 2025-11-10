using System;
using Proyecto.Interfaces;
using Proyecto.ClasesComunes;

namespace Proyecto.Clases.BlackJack
{
    public class DealerBlackjack : JugadorBaseBlackjack, IDealer
    {
        public DealerBlackjack() : base("Dealer") { }

        public void Barajear<T>(BarajaBase<T> baraja) where T : CartaBase
        {
            baraja.Barajear();
            Console.WriteLine("\nEl dealer barajeó las cartas.\n");
        }

        public override bool DeseaCarta()
        {
            return CalcularPuntos() < 17;
        }
    }
}
