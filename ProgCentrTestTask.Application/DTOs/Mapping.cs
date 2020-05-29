using AutoMapper;
using ProgCentrTestTask.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgCentrTestTask.Application.DTOs
{
    public class Mapping : Profile
    {
        /// <summary>
        /// Маппинг
        /// </summary>
        public Mapping()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>().ForMember(q => q.Queries, opt => opt.Ignore());

            CreateMap<QueryCreateDTO, Query>().ForMember(q=>q.Users, opt=>opt.Ignore());
            CreateMap<Query, QueryDisplayDTO>();

        }
    }
}
