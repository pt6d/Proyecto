using System;
using System.Collections.Generic;

namespace Proyecto.Clases.Uno
{
    public class JugadorAleatorioUno : JugadorBaseUno
    {
        private readonly Random random;

        public JugadorAleatorioUno(string nombre) : base(nombre)
        {
            random = new Random();
        }

        public override CartaUno SeleccionarCarta(CartaUno cartaEnMesa)
        {
            var validas = ObtenerCartasValidas(cartaEnMesa);

            if (validas.Count == 0)
                return null;

            var idx = random.Next(validas.Count);
            var elegida = validas[idx];
            Mano.Remove(elegida);
            Console.WriteLine($"{Nombre} jugó: {elegida}");
            return elegida;
        }
    }
}



