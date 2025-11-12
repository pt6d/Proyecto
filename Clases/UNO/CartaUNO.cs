using Proyecto.ClasesComunes;

namespace Proyecto.Clases.Uno
{
    public class CartaUno : CartaBase
    {
        public string Tipo { get; private set; }  
        public int Numero { get; private set; }   

        public CartaUno(string valor, string color, string tipo, int numero)
            : base(valor, color)
        {
            Tipo = tipo;
            Numero = numero;
        }

        public override string ToString()
        {
            return $"{Valor} {Color} ({Tipo})";
        }

        public bool PuedeJugarseSobre(CartaUno cartaEnMesa)
        {
            if (Tipo == "Comodin")
                return true;

            if (Color != "Ninguno" && cartaEnMesa.Color != "Ninguno" && Color == cartaEnMesa.Color)
                return true;

            if (Tipo == "Número" && cartaEnMesa.Tipo == "Número" && Numero == cartaEnMesa.Numero)
                return true;

            if (Tipo != "Número" && Tipo == cartaEnMesa.Tipo)
                return true;

            return false;
        }
    }
}

