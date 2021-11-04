using System;
using System.Collections.Generic;
using System.Linq;
using Sakila.Model;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Sakila.Model.BL.Logica.AccesoBD
{
    public class Customer
    {
        private static ModelSakila.sakilaContext _elContexto = new ModelSakila.sakilaContext();
        //private static ModelSakila.sakilaContext elContexto = new Model.ModelSakila.AdventureWorksLT2019Context();

        public IList<Model.ModelSakila.Customer> BuscarPorNombreAproximadoDeCity_Country(string nombreAproximadoDelPais)
        {
            IList<ModelSakila.Customer> resultado;
            using (var _elContexto = new ModelSakila.sakilaContext())
            {
                var laConsulta = _elContexto.Customers.Include(a => a.Address).
                ThenInclude(cy => cy.City).
                Where(a => a.Address.City.City1.
                Contains(nombreAproximadoDelPais)).
                //Include(co => co.Address.City.Country).
               // Where(co => co.Address.City.Country.Country1.
               // Contains(nombreAproximadoDelPais)).
                OrderBy(c => c.CustomerId);
                resultado = laConsulta.ToList();
            }
            return resultado;
        }
    }
}
