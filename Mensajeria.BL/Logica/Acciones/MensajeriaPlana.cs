using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensajeria.BL.Logica.Acciones
{
    class MensajeriaPlana
    {
        /// <summary>
        /// para enviar mensajes
        /// </summary>
        /// <param name="mensajeEnviar">el mensaje enviado</param>
        public void Enviar(Mensaje mensajeEnviar)
        {
            System.Console.WriteLine($"Mensaje de {mensajeEnviar.Remitente} para {mensajeEnviar.Destinatario}: {mensajeEnviar.TextoMensaje}");
        }

        /// <summary>
        /// para leer los mensajes
        /// </summary>
        /// <param name="Propietario">nombre del propietario cuyos mensajes deseamos leer</param>
        /// <returns>la lista de los mensajes</returns>
        public IList<Mensaje> Leer(string Propietario)
        {
            List<Mensaje> resultadoMensaje = new List<Mensaje> { new Mensaje("Yoselyn", "Samir", "Hola! :)") };
            return resultadoMensaje;
        }
    }
}
