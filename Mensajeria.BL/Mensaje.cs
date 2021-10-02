using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensajeria.BL
{
    /// <summary>
    /// clase para envío de mensajes
    /// </summary>
    public class Mensaje
    {
        public Mensaje()
        {

        }

        public Mensaje(string Remitente, string Destinatario, string TextoMensaje)
        {
            this.Remitente = Remitente;
            this.Destinatario = Destinatario;
            this.TextoMensaje = TextoMensaje;
        }

        /// <summary>
        /// nombre de quien envía el mensaje
        /// </summary>
        public string Remitente;
        /// <summary>
        /// nombre de quien recibe el mensaje
        /// </summary>
        public string Destinatario;
        /// <summary>
        /// cuerpo del mensaje
        /// </summary>
        public string TextoMensaje;
    }
}
