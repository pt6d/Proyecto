using Proyecto.ClasesComunes;
using System.Collections.Generic;

namespace Proyecto.Clases.UNO
{
    public class BarajaUNO : BarajaBase<CartaUNO>
    {
        public BarajaUNO()
        {
            CrearBaraja();
            Barajear();
        }

        public override void CrearBaraja()
        {
            string[] colores = { "Rojo", "Azul", "Verde", "Amarillo" };
            string[] valores = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "Bloqueo", "Reversa", "+2" };
            string[] especiales = { "CambioDeColor", "+4" };

            foreach (string color in colores)
            {
                foreach (string valor in valores)
                {
                    Cartas.Add(new CartaUNO(valor, color, "Normal"));
                }
            }

            foreach (string especial in especiales)
            {
                for (int i = 0; i < 4; i++)
                {
                    Cartas.Add(new CartaUNO(especial, "Negro", "Especial"));
                }
            }
        }
    }
}
