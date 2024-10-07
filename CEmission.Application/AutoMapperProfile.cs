﻿using AutoMapper;
using CEmission.Companies;
using CEmission.Emissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEmission.Application {
    public class CEmissionApiProfile : Profile {
        public CEmissionApiProfile() {
            CreateMap<Company, CompanyDto>();
            CreateMap<Emission, EmissionDto>();
            CreateMap<EmissionCreateDto, Emission>();
            CreateMap<EmissionUpdateDto, Emission>();
        }
    }
}