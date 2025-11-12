using System;
using System.Collections.Generic;

namespace Proyecto.Clases.Uno
{
    public class RondaUno
    {
        private readonly List<JugadorBaseUno> jugadores;
        private readonly BarajaUno baraja;
        private readonly Stack<CartaUno> descarte;
        private int indicadorJugador;
        private int direccion; 

        public RondaUno(List<JugadorBaseUno> jugadores)
        {
            this.jugadores = jugadores;
            baraja = new BarajaUno();
            descarte = new Stack<CartaUno>();
            indicadorJugador = 0;
            direccion = 1;

            for (int i = 0; i < jugadores.Count; i++)
                if (jugadores[i] is JugadorCalculadorUno calc)
                    calc.EstablecerJugadores(jugadores, i);
        }

        public void Iniciar()
        {
            Console.WriteLine("\n------ Iniciando UNO ------");

            for (int i = 0; i < 4; i++)
                foreach (var jugador in jugadores)
                {
                    var carta = baraja.RepartirCarta();
                    if (carta != null) jugador.RecibirCarta(carta);
                }

            var primera = baraja.RepartirCarta();
            if (primera != null)
            {
                descarte.Push(primera);
                Console.WriteLine($"Carta inicial: {primera}\n");
            }

            while (true)
            {
                var jugadorActual = jugadores[indicadorJugador];
                Console.WriteLine($"\n--- Turno de {jugadorActual.Nombre} ---");
                jugadorActual.MostrarMano();

                var cartaEnMesa = descarte.Peek();
                var cartaJugada = jugadorActual.SeleccionarCarta(cartaEnMesa);

                if (cartaJugada == null)
                {
                    if (baraja.CartasRestantes() == 0) RebarajearDescarte();
                    var cartaTomada = baraja.RepartirCarta();
                    if (cartaTomada != null) jugadorActual.RecibirCarta(cartaTomada);
                    Console.WriteLine($"{jugadorActual.Nombre} tomó una carta.");
                }
                else
                {
                    if (!cartaJugada.PuedeJugarseSobre(cartaEnMesa))
                    {
                        Console.WriteLine("Movimiento inválido, se revierte y toma carta.");
                        jugadorActual.RecibirCarta(cartaJugada);
                        if (baraja.CartasRestantes() == 0) RebarajearDescarte();
                        var cartaTomada = baraja.RepartirCarta();
                        if (cartaTomada != null) jugadorActual.RecibirCarta(cartaTomada);
                    }
                    else
                    {
                        AplicarEfectoCarta(cartaJugada);
                        descarte.Push(cartaJugada);
                        jugadorActual.GritarUno();

                        if (jugadorActual.ContarCartas() == 0)
                        {
                            Console.WriteLine($"\n¡{jugadorActual.Nombre} GANA!");
                            return;
                        }
                    }
                }

                AvanzarTurno();
            }
        }

        private void AplicarEfectoCarta(CartaUno carta)
        {
            if (carta.Tipo == "Reversa")
            {
                direccion *= -1;
                Console.WriteLine("Dirección invertida");
            }
            else if (carta.Tipo == "Bloqueo")
            {
                AvanzarTurno();
                Console.WriteLine("Jugador saltado");
            }
            else if (carta.Tipo == "+2")
            {
                AvanzarTurno();
                var siguiente = jugadores[indicadorJugador];
                DarCartas(siguiente, 2);
                Console.WriteLine($"{siguiente.Nombre} tomó 2 cartas");
            }
            else if (carta.Tipo == "Comodin")
            {
                if (carta.Valor == "+4")
                {
                    AvanzarTurno();
                    var siguiente = jugadores[indicadorJugador];
                    DarCartas(siguiente, 4);
                    Console.WriteLine($"{siguiente.Nombre} tomó 4 cartas");
                }
                Console.WriteLine("Color cambiado a Azul");
            }
        }

        private void AvanzarTurno()
        {
            indicadorJugador = (indicadorJugador + direccion + jugadores.Count) % jugadores.Count;
        }

        private void RebarajearDescarte()
        {
            if (descarte.Count == 0) return;

            var cartaSuperior = descarte.Pop();     
            var tmp = new List<CartaUno>();

            while (descarte.Count > 0)
                tmp.Add(descarte.Pop());

            foreach (var c in tmp)
                baraja.AgregarCarta(c);

            baraja.Barajear();
            descarte.Push(cartaSuperior);
        }

        private void DarCartas(JugadorBaseUno jugador, int cantidad)
        {
            for (int i = 0; i < cantidad; i++)
            {
                if (baraja.CartasRestantes() == 0)
                    RebarajearDescarte();

                var c = baraja.RepartirCarta();
                if (c != null) jugador.RecibirCarta(c);
                else break;
            }
        }
    }
}