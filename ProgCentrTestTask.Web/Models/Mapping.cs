using AutoMapper;
using ProgCentrTestTask.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProgCentrTestTask.Web.Models
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<UserModel, UserDTO>();
            CreateMap<UserDTO, UserModel>();

            CreateMap<CreateQueryModel, QueryCreateDTO>();
            CreateMap<QueryDisplayDTO, DisplayQueryModel>();
        }
    }
}