using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ventas;
using System.Windows.Forms;

namespace Paneles
{
    public interface IPanelVentas
    {
        void RegistrarControlador(IControladorVentas controlador);
        void RegistrarModelo(IModeloVentas modelo);
        void MostrarPorPantalla(Object obj);
        void Refrescar();
        
    }
}
