using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ventas;

namespace Modelo
{
    class TestImplementacionDAOVentas
    {
        public static void Main()
        {
            Console.WriteLine("TestImplementacionDAOVentas: verificando ImplementacionDAOVentas");

            ImplementacionDAOVentas dao = null;
            Cliente cliente = null;

            try
            {
                dao = new ImplementacionDAOVentas("localhost");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            try
            {
                // verificar la obtención de todos los clientes
                Console.WriteLine("TestImplementacionDAOVentas: recuperando todos los clientes");
                Cliente[] allCustomers = dao.GetTodosLosClientes();
                Console.WriteLine("TestImplementacionDAOVentas: imprimiendo todos los clientes");
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
                Console.WriteLine("TestImplementacionDAOVentas: verificando la obtención un cliente válido");
                cliente = dao.GetCliente("16828325");
                Console.WriteLine("TestImplementacionDAOVentas: " + cliente);

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
                Console.WriteLine("TestImplementacionDAOVentas: verificar la obtención de un cliente inválido BASURA");
                cliente = dao.GetCliente("BASURA");
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
                Console.WriteLine("TestImplementacionDAOVentas: verificando la actualización de un cliente válido ");
                cliente = dao.GetCliente("16828325");
                cliente.Direccion = "Cabildo 1111, 2° 60";

                dao.ModificarCliente(cliente);

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
                Console.WriteLine("TestImplementacionDAOVentas:  insertando un cliente nuevo");
                cliente = new Cliente("16828999", "Cliente Nuevo", "Santa Fe 2112 5° 99");

                dao.crearCliente(cliente);

            }
            catch (Exception e)
            {
                Console.WriteLine("TestImplementacionDAOVentas:  excepción");
                Console.WriteLine(e);
                Console.WriteLine("TestImplementacionDAOVentas:  la inserción falla si el cliente esta en la bdd");
            }

            Console.WriteLine();
            Console.WriteLine();

            try
            {

                // borrando el registro previamente insertado
                Console.WriteLine("TestImplementacionDAOVentas:  borrando al nuevo cliente");
                cliente = new Cliente("16828999", "Cliente Nuevo", "Santa Fe 2112 5° 99");

                dao.RemoverCliente(cliente);

            }
            catch (Exception e)
            {
                Console.WriteLine("TestImplementacionDAOVentas:  excepción");
                Console.WriteLine(e);
            }
            Console.ReadKey();
        }
    }
}
