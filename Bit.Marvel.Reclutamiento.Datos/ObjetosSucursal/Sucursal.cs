using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bit.Marvel.Reclutamiento.Datos.ObjetosSucursal
{
    public class Sucursal
    {
        private Sucursal(Guid id, string nombre, string direccion)
        {
            Id = id;
            Nombre = nombre;
            Direccion = direccion;
        }

        public Guid Id { get; private set; }
        public string Nombre { get; private set; }
        public string Direccion { get; private set; }

        public static Sucursal Create(Guid id, string nombre, string direccion)
        {
            return new Sucursal(id, nombre,direccion);
        }
    }
}
