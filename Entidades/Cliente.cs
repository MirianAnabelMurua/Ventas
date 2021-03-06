using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Ventas
{
    public class Cliente 
    {
        private String id;
        private String nombre;
        private String dir;


        // Constructores
        public Cliente(String id, String nombre, String direccion)
        {
            this.id = id;
            this.nombre = nombre;
            this.dir = direccion;
        }

        public Cliente(String id)
        {
            this.id = id;
            this.nombre = null;
            this.dir = null;

        }

        public Cliente()
        {
            this.id = null;
            this.nombre = null;
            this.dir = null;
        }

        public String Id
        {
            get { return id; }
            set { id = value; }
        }

        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public String Direccion
        {
            get { return dir; }
            set { dir = value; }
        }


        public override String ToString()
        {
            return "Cliente:  " + id + "  " + nombre + "  " + dir;
        }

    }

}
