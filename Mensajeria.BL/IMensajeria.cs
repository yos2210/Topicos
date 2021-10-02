using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensajeria.BL
{
    /// <summary>
    /// Interfas que funcina para enviar y recibir un mensaje 
    /// </summary>
    interface IMensajeria
    {
        /// <summary>
        /// Metodo para enviar un mensaje
        /// </summary>
        /// <param name="mensajeEnviado">Mensaje para enviar</param>
        public void Enviar(Mensaje mensajeEnviar);

        /// <summary>
        /// Metodo para leer los mensajes recividos 
        /// </summary>
        /// <param name="Propietario">nombre del dueño del recipiente del que se quieren leer los mensajes</param>
        /// <returns>Lista de todos los mensajes del buzón</returns>
        public IList<Mensaje> Leer(string Propietario);
    }
}
