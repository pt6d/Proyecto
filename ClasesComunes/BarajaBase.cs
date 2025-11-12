using System;
using System.Collections.Generic;

namespace Proyecto.ClasesComunes
{
    public abstract class BarajaBase<T> where T : CartaBase
    {
        protected List<T> Cartas;
        protected Random random;

        public BarajaBase()
        {
            Cartas = new List<T>();
            random = new Random();
        }

        public abstract void CrearBaraja();

        public void Barajear()
        {
            for (int i = 0; i < Cartas.Count; i++)
            {
                int j = random.Next(Cartas.Count);
                T temp = Cartas[i];
                Cartas[i] = Cartas[j];
                Cartas[j] = temp;
            }
        }

        public T RepartirCarta()
        {
            if (Cartas.Count == 0)
                return null;

            T carta = Cartas[0];
            Cartas.RemoveAt(0);
            return carta;
        }

        public int CartasRestantes()
        {
            return Cartas.Count;
        }

        public void AgregarCarta(T carta)
        {
            Cartas.Add(carta);
        }
    }
}
