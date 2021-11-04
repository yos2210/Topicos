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

        public void HagaLaMagia()
        {
            ConsultaPorPaisAproximado();
        }

        private void ConsultaPorPaisAproximado()
        {
            var elPaisAproximado = "po";
            var elServicio = new Sakila.Model.BL.Logica.AccesoBD.Customer();
            var elResultado = elServicio.BuscarPorNombreAproximadoDeCity_Country(elPaisAproximado);
            ImprimirCustomers(elResultado);
        }

        private void ImprimirCustomers(IList<Sakila.Model.ModelSakila.Customer> elResultado)
        {
            if (elResultado == null)
            {
                System.Console.WriteLine("Lista sin elementos");
                return;
            }
            foreach (var customer in elResultado)
            {
                System.Console.WriteLine($"ID: {customer.CustomerId} - Nombre Completo: {customer.FirstName + " " +customer.LastName}");
                System.Console.WriteLine("Direccion:");
                System.Console.WriteLine($"   - City: {customer.Address} - Country: {customer.Address} ");
            }
        }
    }
}
