using Proyecto.ClasesComunes;

namespace Proyecto.Clases.Uno
{
    public class BarajaUno : BarajaBase<CartaUno>
    {
        public BarajaUno()
        {
            CrearBaraja();
            Barajear();
        }

        public override void CrearBaraja()
        {
            string[] colores = { "Azul", "Rojo", "Verde", "Amarillo" };

            foreach (string color in colores)
            {
                Cartas.Add(new CartaUno("0", color, "Número", 0));

                for (int num = 1; num <= 9; num++)
                {
                    Cartas.Add(new CartaUno(num.ToString(), color, "Número", num));
                    Cartas.Add(new CartaUno(num.ToString(), color, "Número", num));
                }

                Cartas.Add(new CartaUno("Bloqueo", color, "Bloqueo", -1));
                Cartas.Add(new CartaUno("Bloqueo", color, "Bloqueo", -1));

                Cartas.Add(new CartaUno("Reversa", color, "Reversa", -1));
                Cartas.Add(new CartaUno("Reversa", color, "Reversa", -1));

                Cartas.Add(new CartaUno("+2", color, "+2", -1));
                Cartas.Add(new CartaUno("+2", color, "+2", -1));
            }

            for (int i = 0; i < 4; i++)
            {
                Cartas.Add(new CartaUno("Cambio de Color", "Ninguno", "Comodin", -1));
                Cartas.Add(new CartaUno("+4", "Ninguno", "Comodin", -1));
            }
        }
    }
}




