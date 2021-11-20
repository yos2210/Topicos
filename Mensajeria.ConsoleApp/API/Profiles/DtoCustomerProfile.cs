using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mensajeria.ConsoleApp.API.Profiles
{
    public class DtoCustomerProfile : Profile
    {
        public DtoCustomerProfile()
        {
            CreateMap<NorthWnd.Model.MyModels.Customer, DTOModels.DtoCustomer>();
        }
    }
}
