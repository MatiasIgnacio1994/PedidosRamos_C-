using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba01.Clases
{
    //@author Matias Alarcon
    public class Pedido
    {
        //Atributos
        private string nombreCliente;
        private string tipoRamo;
        private int unidadesSolicitadas;
        private string correo;
        private string prioridad;

        //Propiedades
        public string NombreCliente
        {
            get { return nombreCliente; }
            set { nombreCliente = value; }
        }
        public string TipoRamo
        {
            get { return tipoRamo; }
            set { tipoRamo = value; }
        }
        public int UnidadesSolicitadas
        {
            get { return unidadesSolicitadas; }
            set { unidadesSolicitadas = value; }
        }
        public string Correo
        {
            get { return correo; }
            set { correo = value; }
        }
        public string Prioridad
        {
            get { return prioridad; }
            set { prioridad = value; }
        }
        //Constructores
        //Constructor por defecto
        public Pedido()
        {
            this.nombreCliente = "Sin definir";
            this.tipoRamo = "Sin definir";
            this.unidadesSolicitadas = 0;
            this.correo = "Sin definir";
            this.prioridad = "Sin definir";
        }
        //Constructor que recibe cada uno de los datos
        public Pedido(string nc, string tr, int us, string c, string p)
        {
            this.nombreCliente = nc;
            this.tipoRamo = tr;
            this.unidadesSolicitadas = us;
            this.correo = c;
            this.prioridad = p;
        }
        //RECIBE UN STRING
        public Pedido(string cadena)
        {
            //recibe un string
        }
        //Constructor de copia.
        public Pedido(Pedido p)
        {
            this.nombreCliente = p.nombreCliente;
            this.tipoRamo = p.tipoRamo;
            this.unidadesSolicitadas = p.unidadesSolicitadas;
            this.correo = p.correo;
            this.prioridad = p.prioridad;
        }
        //Sobreescribir método ToString()
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("\nNombre Cliente: ");
            sb.Append(this.nombreCliente);
            sb.Append("\nTipo Ramo: ");
            sb.Append(this.tipoRamo);
            sb.Append("\nUnidades Solicitadas: ");
            sb.Append(this.unidadesSolicitadas);
            sb.Append("\nCorreo: ");
            sb.Append(this.correo);
            sb.Append("\nPrioridad: ");
            sb.Append(this.prioridad);
            sb.Append("\n");
            return sb.ToString();
        }

        //Métodos
    }
}
