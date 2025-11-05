namespace ProyectoBlackjack.Cartas
{
    public class Carta
    {
        public string Valor { get; private set; }      // A,J,K,Q,2,3,4,5,6,7,8,9,10
        public string Figura { get; private set; }       // espadas, corazones, diamantes, treboles
        public int Puntos { get; private set; }       // puntos numericos --- A = 1 o 11 --- J,K,Q = 10

        public Carta(string valor, string figura, int puntos) // Constructor para inicializr la carta
        {
            Valor = valor;                              
            Figura = figura;                              
            Puntos = puntos;                            // (A = 11 inicialmente)
        }

        public override string ToString()               // Método para mostrar la carta en consola
        {
            return $"{Valor} de {Figura}";                // Ejemplo: "A de Corazones"
        }
    }
}
