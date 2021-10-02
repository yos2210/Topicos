using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mensajeria.BL;

namespace Mensajeria.ConsoleApp
{
    public class LogicaPrincipal
    {
        public void GenerarMensaje()
        {
            var mensajeEnviar = new Mensaje("Raquel", "EStefany", "Hello! ;)");
            var servicio = new MensajeriaPlana();
            servicio.Enviar(mensajeEnviar);
        }
    }
}
