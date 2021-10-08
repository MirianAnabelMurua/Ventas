using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ventas;

namespace Modelo
{
    class TestImplementacionModeloVentas
    {
        public static void Main()
        {
            Console.WriteLine("BrokerModelImplTest.main: testing BrokerModelImplTest");

            IModeloVentas modelo = null;
            IDAOVentas dao = null;
            Cliente cliente = null;

            try
            {
                dao = new ImplementacionDAOVentas("localhost");
                modelo = new ImplementacionModeloVentas(dao);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            try
            {
                // verificar la obtención de todos los clientes
                Console.WriteLine("TestImplementacionModeloVentas.Main: recuperando todos los clientes");
                Cliente[] allCustomers = modelo.ObtenerTodosLosClientes();
                Console.WriteLine("TestImplementacionModeloVentas.Main: imprimiendo todos los clientes");
                foreach (Cliente c in allCustomers)
                {
                    Console.WriteLine(c);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine();
            Console.WriteLine();

            try
            {
                // verificar la obtención de un cliente válido
                Console.WriteLine("TestImplementacionModeloVentas.Main: verificando la obtención un cliente válido");
                cliente = modelo.ObtenerCliente("16828325");
                Console.WriteLine("TestImplementacionModeloVentas.Main: " + cliente);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine();
            Console.WriteLine();

            try
            {
                // verificar la obtención de un cliente inválido
                Console.WriteLine("TestImplementacionModeloVentas.Main: verificar la obtención de un cliente inválido BASURA");
                cliente = modelo.ObtenerCliente("BASURA");
                Console.WriteLine(cliente);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine();
            Console.WriteLine();

            try
            {
                // verificando la actualización de un cliente válido
                Console.WriteLine("TestImplementacionModeloVentas.Main: verificando la actualización de un cliente válido ");
                cliente = modelo.ObtenerCliente("16828325");
                cliente.Direccion = "Cabildo 1111, 2° 60";

                modelo.ActualizarCliente(cliente);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine();
            Console.WriteLine();

            try
            {
                // insertando un nuevo registro
                Console.WriteLine("TestImplementacionModeloVentas.Main:  insertando un cliente nuevo");
                cliente = new Cliente("16828999", "Cliente Nuevo", "Santa Fe 2112 5° 99");

                modelo.AgregarCliente(cliente);
            }
            catch (Exception e)
            {
                Console.WriteLine("TestImplementacionModeloVentas.Main:  excepción");
                Console.WriteLine(e);
                Console.WriteLine("TestImplementacionModeloVentas.Main:  la inserción falla si el cliente esta en la bdd");
            }

            Console.WriteLine();
            Console.WriteLine();

            try
            {
                // borrando el registro previamente insertado
                Console.WriteLine("TestImplementacionModeloVentas.Main:  borrando al nuevo cliente");
                cliente = new Cliente("16828999", "Cliente Nuevo", "Santa Fe 2112 5° 99");

                modelo.BorrarCliente(cliente);
            }
            catch (Exception e)
            {
                Console.WriteLine("TestImplementacionModeloVentas.Main:  excepción");
                Console.WriteLine(e);
            }
            Console.ReadKey();
        }
    }
}
