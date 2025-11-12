using System;
using System.Collections.Generic;

namespace Proyecto.Clases.Uno
{
    public class JugadorCalculadorUno : JugadorBaseUno
    {
        private int indiceJugadorActual;
        private List<JugadorBaseUno> todosLosJugadores;

        public JugadorCalculadorUno(string nombre) : base(nombre)
        {
            todosLosJugadores = new List<JugadorBaseUno>();
        }

        public void EstablecerJugadores(List<JugadorBaseUno> jugadores, int tuIndice)
        {
            todosLosJugadores = jugadores;
            indiceJugadorActual = tuIndice;
        }

        private JugadorBaseUno ObtenerSiguienteJugador()
        {
            int siguiente = (indiceJugadorActual + 1) % todosLosJugadores.Count;
            return todosLosJugadores[siguiente];
        }

        public override CartaUno SeleccionarCarta(CartaUno cartaEnMesa)
        {
            var validas = ObtenerCartasValidas(cartaEnMesa);
            if (validas.Count == 0)
                return null;

            var siguiente = ObtenerSiguienteJugador();
            if (siguiente.ContarCartas() == 1)
            {
                foreach (var c in validas)
                {
                    if (c.Tipo == "Comodin" || c.Tipo == "+2")
                    {
                        Mano.Remove(c);
                        Console.WriteLine($"{Nombre} jugó especial: {c}");
                        return c;
                    }
                }
            }

            foreach (var c in validas)
            {
                if (c.Tipo == "Número")
                {
                    Mano.Remove(c);
                    Console.WriteLine($"{Nombre} jugó: {c}");
                    return c;
                }
            }

            var elegida = validas[0];
            Mano.Remove(elegida);
            Console.WriteLine($"{Nombre} jugó: {elegida}");
            return elegida;
        }
    }
}




