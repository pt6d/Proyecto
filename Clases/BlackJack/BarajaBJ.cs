using Proyecto.ClasesComunes;

namespace Proyecto.Clases.Blackjack
{
    public class BarajaBlackjack : BarajaBase<CartaBlackjack>
    {
        public BarajaBlackjack()
        {
            CrearBaraja();
            Barajear();
        }

        public override void CrearBaraja()
        {
            string[] figuras = { "Corazones", "Espadas", "Tréboles", "Diamantes" };
            string[] valores = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

            foreach (string figura in figuras)
            {
                // Determina el color según la figura
                string color = (figura == "Corazones" || figura == "Diamantes") ? "Rojo" : "Negro";

                foreach (string valor in valores)
                {
                    int puntos;

                    // Asigna puntos 
                    switch (valor)
                    {
                        case "J":
                        case "Q":
                        case "K":
                            puntos = 10;
                            break;

                        case "A":
                            puntos = 11;
                            break;

                        default:
                            puntos = int.Parse(valor);
                            break;
                    }

                    // Agrega la carta creada a la lista
                    Cartas.Add(new CartaBlackjack(valor, figura, color, puntos));
                }
            }
        }
    }
}