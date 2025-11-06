namespace Proyecto.Clases.BlackJack
{
    public class JugadorTemerario : JugadorBaseBlackjack
    {
        public JugadorTemerario(string nombre) : base(nombre) { }

        public override bool DeseaCarta()
        {
            return CalcularPuntos() < 21; 
        }
    }
}
