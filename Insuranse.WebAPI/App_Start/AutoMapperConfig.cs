using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InsuranceSystem.BLL.DTO;
using Insuranse.WebAPI.Models;
using AutoMapper;
using InsuranceSystem.BLL.DTO.Catalogs;

namespace Insuranse.WebAPI.App_Start
{
    public static class AutoMapperConfig
    {
        public static void RegisterMapper()
        {
            Mapper.Initialize(conf => conf.CreateMap<FirmDTO, FirmModel>()
            .ReverseMap().ForSourceMember(prop => prop.DateCreate, c => c.Ignore()));
        }
    }
}