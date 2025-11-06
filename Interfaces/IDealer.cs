using Proyecto.ClasesComunes;

namespace Proyecto.Interfaces
{
    public interface IDealer : IJugador
    {
        void Barajear(BarajaBase<CartaBase> baraja);
    }
}
