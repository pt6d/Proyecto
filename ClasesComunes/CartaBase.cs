using Proyecto.Interfaces;

namespace Proyecto.ClasesComunes
{
    public abstract class CartaBase : ICarta
    {
        public string Valor { get; protected set; }
        public string Color { get; protected set; }

        public CartaBase(string valor, string color)
        {
            Valor = valor;
            Color = color;
        }

        public override string ToString()
        {
            return $"{Valor} ({Color})";
        }
    }
}
