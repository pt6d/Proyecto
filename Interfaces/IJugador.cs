using Proyecto.Interfaces;

namespace Proyecto.Interfaces
{
    public interface IJugador
    {
        string Nombre { get; }

        void RecibirCarta(ICarta carta);
        void MostrarMano();
        void Reiniciar();

        bool DeseaCarta();
        int CalcularPuntos();
    }
}
