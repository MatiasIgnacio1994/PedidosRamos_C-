using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Prueba01.Clases
{
    //@author Matias Alarcon
    public class Kiosco
    {
        //Atributos
        private int stockRamo1;
        private int stockRamo2;
        private int stockRamo3;
        public List<Pedido> pedidosFactibles;
        public List<Pedido> pedidosSinStock;

        //Propiedades
        public int StockRamo1
        {
            get { return stockRamo1; }
            set { stockRamo1 = value; }
        }
        public int StockRamo2
        {
            get { return stockRamo2; }
            set { stockRamo2 = value; }
        }
        public int StockRamo3
        {
            get { return stockRamo3; }
            set { stockRamo3 = value; }
        }

        //Constructores
        //Constructor por defecto
        public Kiosco()
        {
            this.stockRamo1 = 10;
            this.stockRamo2 = 15;
            this.stockRamo3 = 5;
            this.pedidosFactibles = new List<Pedido>();
            this.pedidosSinStock = new List<Pedido>();
        }
        //Constructor que recibe datos
        public Kiosco(int sr1, int sr2, int sr3)
        {
            this.stockRamo1 = sr1;
            this.stockRamo2 = sr2;
            this.stockRamo3 = sr3;
            this.pedidosFactibles = new List<Pedido>();
            this.pedidosSinStock = new List<Pedido>();
        }
        //Constructor que recibe el archivo de texto
        public Kiosco(int sr1, int sr2, int sr3, string archivo)
        {
            List<Pedido> pedidosTotales = new List<Pedido>();
            this.pedidosFactibles = new List<Pedido>();
            this.pedidosSinStock = new List<Pedido>();

            this.stockRamo1 = sr1;
            this.stockRamo2 = sr2;
            this.stockRamo3 = sr3;

            string[] campo;
            string linea;
            try
            {
                FileStream f = new FileStream(archivo, FileMode.Open, FileAccess.Read);
                StreamReader rf = new StreamReader(f);

                while (!rf.EndOfStream)
                {
                    linea = rf.ReadLine();
                    campo = linea.Split(',');

                    var p = new Pedido()
                    {
                        NombreCliente = campo[0],
                        TipoRamo = campo[1],
                        UnidadesSolicitadas = int.Parse(campo[2]),
                        Correo = campo[3],
                        Prioridad = campo[4]
                    };
                    pedidosTotales.Add(p);
                }
                rf.Close();
                f.Close();
            }
            catch (IOException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            for (int i = 0; i < pedidosTotales.Count; i++)
            {
                if (pedidosTotales[i].TipoRamo == "Ramo1" && pedidosTotales[i].UnidadesSolicitadas <= this.stockRamo1)
                {
                    this.pedidosFactibles.Add(pedidosTotales[i]);
                    this.stockRamo1 -= pedidosTotales[i].UnidadesSolicitadas;
                }
                else if (pedidosTotales[i].TipoRamo == "Ramo2" && pedidosTotales[i].UnidadesSolicitadas <= this.stockRamo2)
                {
                    this.pedidosFactibles.Add(pedidosTotales[i]);
                    this.stockRamo2 -= pedidosTotales[i].UnidadesSolicitadas;
                }
                else if (pedidosTotales[i].TipoRamo == "Ramo3" && pedidosTotales[i].UnidadesSolicitadas <= this.stockRamo3)
                {
                    this.pedidosFactibles.Add(pedidosTotales[i]);
                    this.stockRamo3 -= pedidosTotales[i].UnidadesSolicitadas;
                }
                else
                {
                    this.pedidosSinStock.Add(pedidosTotales[i]);
                }
            }
        }
        //Sobreescribir método ToString()
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("\nStock Ramo 1: ");
            sb.Append(this.stockRamo1);
            sb.Append("\nStock Ramo 2 ");
            sb.Append(this.stockRamo2);
            sb.Append("\nStock Ramo 3: ");
            sb.Append(this.stockRamo3);
            sb.Append("\n\n------ PEDIDOS FACTIBLES -------- : \n");
            for(int i = 0; i < this.pedidosFactibles.Count; i++)
            {
                sb.Append(this.pedidosFactibles[i].ToString());
            }
            sb.Append("\n\n------ PEDIDOS SIN STOCK -------- : \n");
            for(int i = 0; i < this.pedidosSinStock.Count; i++)
            {
                sb.Append(this.pedidosSinStock[i].ToString());
            }
            return sb.ToString();
        }
        //Métodos propios de la clase
        public void asignarStocks(int r1, int r2, int r3)
        {
            this.stockRamo1 = r1;
            this.stockRamo2 = r2;
            this.stockRamo3 = r3;
            Console.WriteLine("Stocks asignados!");
        }
        public string mostrarPedidos()
        {
            StringBuilder sb = new StringBuilder();
            Console.WriteLine("Pedidos atendidos: ");
            Console.WriteLine();
            for (int i = 0; i < this.pedidosFactibles.Count; i++)
            {
                sb.Append(this.pedidosFactibles[i].ToString());
            }
            Console.Write("\n");
            for (int i = 0; i < this.pedidosSinStock.Count; i++)
            {
                sb.Append(this.pedidosSinStock[i].ToString());
            }
            return sb.ToString();
        }
        public string mostrarSinStock()
        {
            StringBuilder sb = new StringBuilder();
            Console.WriteLine("Pedidos sin stock: ");
            Console.WriteLine();
            for (int i = 0; i < this.pedidosSinStock.Count; i++)
            {
                sb.Append(this.pedidosSinStock[i].ToString());
            }
            return sb.ToString();
        }
        public string mostrarPrioritarios()
        {
            StringBuilder sb = new StringBuilder();
            Console.WriteLine("Pedidos con prioridad 1: ");
            Console.WriteLine();
            for (int i = 0; i < this.pedidosFactibles.Count; i++)
            {
                if (this.pedidosFactibles[i].Prioridad == "ALTA")
                {
                    sb.Append(this.pedidosFactibles[i].ToString());
                }
            }
            Console.Write("\n");
            for (int i = 0; i < this.pedidosSinStock.Count; i++)
            {
                if (this.pedidosSinStock[i].Prioridad == "ALTA")
                {
                    sb.Append(this.pedidosSinStock[i].ToString());
                }
            }
            return sb.ToString();
        }
        public string PrioridadEspecifica(string prio)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < this.pedidosFactibles.Count; i++)
            {
                if (this.pedidosFactibles[i].Prioridad == prio)
                {
                    sb.Append(this.pedidosFactibles[i].ToString());
                }
            }
            Console.Write("\n");
            for (int i = 0; i < this.pedidosSinStock.Count; i++)
            {
                if (this.pedidosSinStock[i].Prioridad == prio)
                {
                    sb.Append(this.pedidosSinStock[i].ToString());
                }
            }
            return sb.ToString();
        }
    }
}
