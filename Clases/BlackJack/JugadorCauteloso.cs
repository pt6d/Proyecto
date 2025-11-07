namespace Proyecto.Clases.BlackJack
{
    public class JugadorCauteloso : JugadorBaseBlackjack
    {
        private readonly int _limite; //Punto de corte 
        public JugadorCauteloso(string nombre, int limite) : base(nombre)
        {
            _limite = limite;
        }

        public override bool DeseaCarta()
        {
            return CalcularPuntos() < _limite;
        }
    }
}
