using System;
using System.Collections.Generic;
using Proyecto.Interfaces;
 
namespace Proyecto.Clases.BlackJack
{
    public abstract class JugadorBaseBlackjack : IJugador

    {
        public string Nombre { get; private set; }
        protected List<CartaBlackjack> Mano;

        public JugadorBaseBlackjack(string nombre)
        {
            Nombre = nombre;
            Mano = new List<CartaBlackjack>();
        }
        
        public void RecibirCarta(ICarta carta)
        {
            if (carta is CartaBlackjack cartaBJ)
            {
                Mano.Add(cartaBJ);
                Console.WriteLine($"{Nombre} recibió {cartaBJ}");
            }

        }
 
        public void MostrarMano()
        {
            Console.WriteLine($"\n{Nombre} tiene:");
            foreach (var carta in Mano)
            {
                Console.WriteLine($" - {carta}");
            }    
            Console.WriteLine($"Total: {CalcularPuntos()} puntos\n");
        }
 
        public void Reiniciar()
        {
            Mano.Clear();
        }

        public int CalcularPuntos()
        {
            int total = 0;
            int ases = 0;
            foreach (var carta in Mano)
            {
                total += carta.Puntos;
                if (carta.Valor == "A")
                {
                    ases++;
                }
            }
            while (total > 21 && ases > 0)  //Si se pasa, convierte el AS a 1
            {
                total -= 10;
                ases--;
            }
            return total;
        }
        
        public abstract bool DeseaCarta();

    }

}

 