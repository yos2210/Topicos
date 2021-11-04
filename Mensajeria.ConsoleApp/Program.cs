using System;

namespace Mensajeria.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            GenerarMensaje();
        }

        private static void GenerarMensaje()
        {
            var mensaje = new LogicaPrincipal();
            mensaje.HagaLaMagia();
            //mensaje.GenerarMensaje();
        }
    }
}
