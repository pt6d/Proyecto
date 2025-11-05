using Proyecto.ClasesComunes;

namespace Proyecto.Interfaces
{
    public interface IDealer : IJugador
    {
        void Barajar(BarajaBase<CartaBase> baraja);
    }
}
