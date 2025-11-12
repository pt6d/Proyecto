using System;
using System.Collections.Generic;
using Proyecto.Interfaces;

namespace Proyecto.Clases.Uno
{
    public abstract class JugadorBaseUno : IJugador
    {
        public string Nombre { get; protected set; }
        protected List<CartaUno> Mano;

        public JugadorBaseUno(string nombre)
        {
            Nombre = nombre;
            Mano = new List<CartaUno>();
        }

        public void RecibirCarta(ICarta carta)
        {
            if (carta is CartaUno c)
            {
                Mano.Add(c);
                Console.WriteLine($"{Nombre} recibió una carta.");
            }
        }

        public void MostrarMano()
        {
            Console.WriteLine($"Mano de {Nombre}:");
            for (int i = 0; i < Mano.Count; i++)
                Console.WriteLine($"  {i + 1}. {Mano[i]}");
        }

        public void Reiniciar() => Mano.Clear();
        public bool DeseaCarta() => false;
        public int CalcularPuntos() => Mano.Count;
        public List<CartaUno> ObtenerCartasValidas(CartaUno cartaEnMesa)
        {
            var validas = new List<CartaUno>();
            foreach (var carta in Mano)
                if (carta.PuedeJugarseSobre(cartaEnMesa))
                    validas.Add(carta);
            return validas;
        }

        public abstract CartaUno SeleccionarCarta(CartaUno cartaEnMesa);

        public void GritarUno()
        {
            if (Mano.Count == 1)
                Console.WriteLine($"¡{Nombre} grita UNO!");
        }

        public int ContarCartas() => Mano.Count;
    }
}
