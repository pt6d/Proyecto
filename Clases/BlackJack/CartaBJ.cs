using Proyecto.ClasesComunes;

namespace Proyecto.Clases.Blackjack
{
    public class CartaBlackjack  : CartaBase
    {
        public string Figura { get; private set; }
        public int Puntos { get; private set; }

        public CartaBlackjack(string valor, string figura, string color, int puntos)
            : base(valor, color)
        {
            this.Figura = figura;
            this.Puntos = puntos;
        }

        public override string ToString()
        {
            return $"{Valor} de {Figura} ({Color})";
        }
    }
}
