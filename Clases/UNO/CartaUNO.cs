using Proyecto.ClasesComunes;

namespace Proyecto.Clases.UNO
{
    public class CartaUNO : CartaBase
    {
        public string Tipo { get; private set; } // Tipos de cartas 
        public string ColorCarta { get; private set; } 

        public CartaUNO(string valor, string colorCarta, string tipo)
            : base(valor, colorCarta)
        {
            Tipo = tipo;
            ColorCarta = colorCarta;
        }

        public override string ToString()
        {
            return $"{Valor} de color {ColorCarta} ({Tipo})";
        }
    }
}
