using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bit.Marvel.Reclutamiento.Negocio.Auxiliares
{
    public class ConnectionString
    {
        public ConnectionString(string @default)
        {
            Default = @default;
        }

        public string Default { get; set; }
    }
}
