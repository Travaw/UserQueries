using AutoMapper;
using ProgCentrTestTask.Application.DTOs;
using ProgCentrTestTask.Core.Managers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgCentrTestTask.Application.Services
{
    public class UserService:IUserService
    {

        private IQueryManager queryManager = new QueryManager();
        private IUserManager userManager = new UserManager();
        private IMapper mapper;
        public UserService(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public ICollection<UserDTO> Search(UserDTO search)
        {
            return null;
        }

        public ICollection<UserDTO> SearchForQuery(UserDTO search, int queryId)
        {
            return null;
        }

        public ICollection<UserDTO> GetAll()
        {
            return mapper.Map<ICollection<UserDTO>>(userManager.GetAll());
        }

        public ICollection<UserDTO> GetAllForQuery(int queryId)
        {
            return mapper.Map<ICollection<UserDTO>>(userManager.GetAllForQuery(queryId));
        }
    }
}
