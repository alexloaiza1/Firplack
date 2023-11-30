using AutoMapper;
using Firplak.Domain.DTOs;
using Firplak.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firplak.Infrastructure.Mappings
{
    public class AutoMapperProfile: Profile
    {

        public AutoMapperProfile()
        {

            CreateMap<Entrega, EntregaDto>().ReverseMap().ToString();
            CreateMap<EntregaDto, Entrega>().ToString();

            CreateMap<GuiaTransporte, GuiaTransporteDto>().ReverseMap().ToString();
            CreateMap<GuiaTransporteDto, GuiaTransporte>().ToString();

        }
      

    }
}
