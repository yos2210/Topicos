using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensajeria.BL
{
    public class MensajeriaPlana : IMensajeria
    {
        public void Enviar(Mensaje mensajeEnviar)
        {
            var accion = new Logica.Acciones.MensajeriaPlana();
            accion.Enviar(mensajeEnviar);
        }

        public IList<Mensaje> Leer(string Propietario)
        {
            var accion = new Logica.Acciones.MensajeriaPlana();
            var resultado = accion.Leer(Propietario);
            return resultado;
        }
    }
}
