using System;
using System.Collections.Generic;

namespace Proyecto.Clases.Uno
{
    public class JuegoUno
    {
        private readonly List<JugadorBaseUno> jugadores;

        public JuegoUno()
        {
            jugadores = new List<JugadorBaseUno>();
        }

        public void AgregarJugador(JugadorBaseUno jugador)
        {
            jugadores.Add(jugador);
        }

        public void IniciarJuego()
        {
            if (jugadores.Count < 2)
            {
                Console.WriteLine("Se necesitan al menos 2 jugadores");
                return;
            }

            foreach (var j in jugadores) //reiniciar jugadores
            {
                j.Reiniciar();
            } 

            var ronda = new RondaUno(jugadores);
            ronda.Iniciar();

            foreach (var j in jugadores)
            {
                j.Reiniciar();
            } 
        }
    }
}



