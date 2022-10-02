using Prueba01.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            int opcion;

            
            do
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("1.- Mostrar Kiosco");
                Console.WriteLine("2.- Mostrar pedidos SIN STOCK");
                Console.WriteLine("3.- Mostrar pedidos con prioridad específica");
                Console.WriteLine("0.- Salir");
                Console.WriteLine();
                Console.Write("Elija una opción: ");
                int.TryParse(Console.ReadLine(), out opcion);

                switch (opcion)
                {
                    case 1:
                        MostrarKiosco();
                        break;
                    case 2:
                        PedidosSinStock();
                        break;
                    case 3:
                        MostrarPrioridadEspecifica();
                        break;
                }

            } while (opcion != 0);
        }
        private static void MostrarKiosco()
        {
            Console.Clear();
            Kiosco k1 = new Kiosco(10, 15, 5, "pedidos.txt");
            Console.WriteLine(k1.ToString());
            Console.ReadKey();
        }
        private static void PedidosSinStock()
        {
            Console.Clear();
            Kiosco k1 = new Kiosco(10, 15, 5, "pedidos.txt");
            Console.WriteLine(k1.mostrarSinStock());
            Console.ReadKey();
        }
        private static void MostrarPrioridadEspecifica()
        {
            Console.Clear();
            string prioridad;
            Console.Write("Ingresa prioridad ALTA, MEDIA o BAJA: ");
            prioridad = Console.ReadLine().ToUpper();
            Kiosco k1 = new Kiosco(10, 15, 5, "pedidos.txt");
            Console.WriteLine(k1.PrioridadEspecifica(prioridad));
            Console.ReadKey();
        }
    }
}
