using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Paneles;
using MVC;

namespace Ventas
{
    public partial class Form1 : Form
    {
        public delegate void DisparaEventoActualizarCliente(MVC.VistaEventArgs args);
        public delegate void DisparaEventoBorrarCliente(MVC.VistaEventArgs args);
        public delegate void DisparaEventoAgregarCliente(MVC.VistaEventArgs args);
        public delegate void DisparaEventoObtenerCliente(MVC.VistaEventArgs args);
        public delegate void DisparaEventoObtenerTodosLosClientes(MVC.VistaEventArgs args);



        private DisparaEventoAgregarCliente agregarCliente;
        private DisparaEventoBorrarCliente borrarCliente;
        private DisparaEventoActualizarCliente modificarCliente;
        private DisparaEventoObtenerCliente obtenerCliente;
        private DisparaEventoObtenerTodosLosClientes obtenerTodosLosClientes;


        public Form1(IModeloVentas modelo)
        {
            InitializeComponent();
            panelCliente1.RegistrarModelo(modelo);
            panelTodosLosClientes1.RegistrarModelo(modelo);
            panelTodosLosClientes1.Refrescar();

            //// 1 Suscribir el manejador para el evento declarado en el panel 
            //    de detalles de clientes que actualiza al cliente
            //    Ejemplo: AddHandler PanelCliente1.EventoActualizarCliente, AddressOf Me.ManejadorEventoPanelActualizar
            panelCliente1.EventoActualizarCliente += ManejadorEventoPanelActualizar;
            //// 2 Suscribir el manejador para el evento declarado en el panel 
            //    de detalles de clientes que agrega un cliente
            panelCliente1.EventoAgregarCliente += ManejadorEventoPanelAgregar;
            //// 3 Suscribir el manejador para el evento declarado en el panel 
            //    de detalles de clientes que borra un cliente
            panelCliente1.EventoBorrarCliente += ManejadorEventoPanelBorrar;
            //// 4 Suscribir el manejador para el evento declarado en el panel 
            //    de detalles de clientes que obtiene al cliente
            panelCliente1.EventoObtenerCliente += ManejadorEventoPanelObtener;

            //// 5 Suscribir el manejador para el evento declarado en el panel 
            //    de todos los clientes que obtiene la lista de clientes
            panelTodosLosClientes1.EventoObtenerTodosLosClientes += ManejadorEventoPanelObtenerTodos;

        }


        public void RegistraEventosVista(DisparaEventoActualizarCliente metodo)
        {
            //// 6 Suscribir el manejador para el delegate declarado en esta clase que  
            //    recibe como parámetro el método manejador para actualizar al cliente  
            //    desde la clase ImplementacionVistaVentas
            //    Ejemplo: modificarCliente = metodo
            modificarCliente = metodo;
        }

        public void RegistraEventosVista(DisparaEventoBorrarCliente metodo)
        {
            //// 7 Suscribir el manejador para el delegate declarado en esta clase que  
            //    recibe como parámetro el método manejador para borrar al cliente  
            //    desde la clase ImplementacionVistaVentas
            borrarCliente = metodo;
        }

        public void RegistraEventosVista(DisparaEventoAgregarCliente metodo)
        {
            //// 8 Suscribir el manejador para el delegate declarado en esta clase que  
            //    recibe como parámetro el método manejador para Agregar un cliente  
            //    desde la clase ImplementacionVistaVentas
            agregarCliente = metodo;
        }

        public void RegistraEventosVista(DisparaEventoObtenerCliente metodo)
        {
            //// 9 Suscribir el manejador para el delegate declarado en esta clase que  
            //    recibe como parámetro el método manejador que dispara el evento para 
            //    Obtener un cliente desde la clase ImplementacionVistaVentas
            obtenerCliente = metodo;
        }

        public void RegistraEventosVista(DisparaEventoObtenerTodosLosClientes metodo)
        {
            //// 10 Suscribir el manejador para el delegate declarado en esta clase que  
            //     recibe como parámetro el método manejador que dispara el evento para 
            //     Obtener todos los clientes desde la clase ImplementacionVistaVentas
            obtenerTodosLosClientes = metodo;
        }

        private void ManejadorEventoPanelAgregar(System.Object sender, VistaEventArgs args)
        {
            //// 11 Invocar al manejador que referencia el delegate declarado en esta clase   
            //     para que dispare el evento para agregar un cliente en  
            //     la clase ImplementacionVistaVentas
            //     Ejemplo: agregarCliente(args)
            agregarCliente(args);
        }

        private void ManejadorEventoPanelBorrar(System.Object sender, VistaEventArgs args)
        {
            //// 12 Invocar al manejador que referencia el delegate declarado en esta clase   
            //     para que dispare el evento para borrar un cliente en  
            //     la clase ImplementacionVistaVentas
            borrarCliente(args);
        }

        private void ManejadorEventoPanelActualizar(System.Object sender, VistaEventArgs args)
        {
            //// 13 Invocar al manejador que referencia el delegate declarado en esta clase   
            //     para que dispare el evento para actualizar un cliente en  
            //     la clase ImplementacionVistaVentas
            modificarCliente(args);
        }

        private void ManejadorEventoPanelObtener(System.Object sender, VistaEventArgs args)
        {
            //// 14 Invocar al manejador que referencia el delegate declarado en esta clase   
            //     para que dispare el evento para obtener un cliente en  
            //     la clase ImplementacionVistaVentas
            obtenerCliente(args);
        }

        private void ManejadorEventoPanelObtenerTodos(System.Object sender, VistaEventArgs args)
        {
            //// 15 Invocar al manejador que referencia el delegate declarado en esta clase   
            //     para que dispare el evento para obtener todos los clientes en  
            //     la clase ImplementacionVistaVentas
            obtenerTodosLosClientes(args);
        }




        public void actualizarLog(string p)
        {
            rtxtLog.AppendText(p + Environment.NewLine);
        }

        public void MostrarObjetoPorPantalla(ClienteEventArgs args)
        {
            if (args == null)
            {
                Console.WriteLine("El objeto a mostrar es nulo.");
                return;
            }
            panelCliente1.MostrarPorPantalla(args.Cliente);
        }

        public void MostrarObjetoPorPantalla(TodosLosClientesEventArgs args)
        {
            if (args == null)
            {
                Console.WriteLine("El objeto a mostrar es nulo.");
                return;
            }
            panelTodosLosClientes1.MostrarPorPantalla(args.TodosLosClientes);
        }

        public void MostrarObjetoPorPantalla(ExcepcionEventArgs args)
        {
            rtxtLog.AppendText(args.Excepcion.ToString() + Environment.NewLine);
        }



        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

    }
}
