using System;
//using Proyecto.Clases;
//using Proyecto.Interfaces;

namespace Proyecto
{
    class Program
    {
        static void Main()
        {
            bool salir = false;

            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("-------- Menu --------");
                Console.WriteLine("1. BlackJack");
                Console.WriteLine("2. UNO");
                Console.WriteLine("3. Salir");
                Console.WriteLine("Seleccione una opcion:");

                try
                {
                    int opcion = int.Parse(Console.ReadLine());

                    switch (opcion)
                    {
                        case 1:
                            Console.WriteLine("Eduardo es gay");
                            //IniciarBlackJack();
                            Console.ReadLine();
                            break;
                        case 2:
                            Console.WriteLine("Gabriel es gay");
                            //IniciarUNO();
                            Console.ReadLine();
                            break;
                        case 3:
                            salir = true;
                            break;
                        default:
                            Console.WriteLine("ERROR, opción invalida");
                            Console.ReadLine();
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("Opcion no valida");
                    Console.ReadLine();
                }
            }



        }





    }

}