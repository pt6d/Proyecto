using Proyecto.ClasesComunes;

namespace Proyecto.Interfaces
{
    public interface IDealer : IJugador
    {
        void Barajear<T>(BarajaBase<T> baraja) where T : CartaBase;

    }
}
