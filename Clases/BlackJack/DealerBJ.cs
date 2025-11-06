using System;
using Proyecto.Interfaces;
using Proyecto.ClasesComunes;

namespace Proyecto.Clases.BlackJack
{
    public class DealerBlackjack : JugadorBaseBlackjack, IDealer
    {
        public DealerBlackjack() : base("Dealer") { }
        public void Barajear(BarajaBase<CartaBase> baraja)
        {
            baraja.Barajear();
            Console.WriteLine("\nEl dealer ha barajeado las cartas\n");
        }

        public override bool DeseaCarta()
        {
            return CalcularPuntos() < 17;
        }
    }
}
