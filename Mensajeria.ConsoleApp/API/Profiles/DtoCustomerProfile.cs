using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Topicos.Netcore.Api.AdventureWorks.Profiles
{
    public class DtoCustomerProfile : Profile
    {
        public DtoCustomerProfile()
        {
            CreateMap<NorthWnd.Model.MyModels.Customer, DTOModels.DtoCustomer>();
        }
    }
}
