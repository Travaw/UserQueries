using AutoMapper;
using ProgCentrTestTask.Application.DTOs;
using ProgCentrTestTask.Core.Entities;
using ProgCentrTestTask.Core.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProgCentrTestTask.Application.Helpers;

namespace ProgCentrTestTask.Application.Services
{
    public class QueryService:IQueryService
    {
        private IQueryManager queryManager = new QueryManager();
        private IUserManager userManager = new UserManager();
        private IMapper mapper;
        HttpClient httpClient = new HttpClient();
        public QueryService(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public void Add(QueryCreateDTO dto)
        {
            var entity = mapper.Map<Query>(dto);
            queryManager.Add(entity);
        }

        public ICollection<QueryDisplayDTO> GetAllForUser(int userId)
        {
            var entities = queryManager.GetAllForUser(userId);
            return mapper.Map<IEnumerable<QueryDisplayDTO>>(entities).ToList();
        }

        public ICollection<QueryDisplayDTO> GetAllExecuted()
        {
            var entities = queryManager.GetAllExecuted();
            return mapper.Map<IEnumerable<QueryDisplayDTO>>(entities).ToList();
        }

        public ICollection<QueryDisplayDTO> GetAllNotExecuted()
        {
            var entities = queryManager.GetAllNotExecuted();
            return mapper.Map<IEnumerable<QueryDisplayDTO>>(entities).ToList();
        }

        public ICollection<QueryDisplayDTO> Get(DateTime creationTime)
        {
            var entities = queryManager.GetAllNotExecuted();
            return mapper.Map<IEnumerable<QueryDisplayDTO>>(entities).ToList();
        }

        public async Task<ICollection<UserDTO>> Execute(int id, WebRequestHelper helper)
        {
            Query query = queryManager.Get(id);
            if (query == null)
            {
                return null;
            }
            ICollection<UserDTO> users;
            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(helper.CreateRequest(mapper.Map<QueryDisplayDTO>(query)));
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                users = await httpResponseMessage.Content.ReadAsAsync<ICollection<UserDTO>>();
                var entities = mapper.Map<IEnumerable<User>>(users);
                query = queryManager.SetExecuted(query);
                userManager.Add(query, entities.ToArray());
                return users;
            }
            return null;
        }
    }
}
