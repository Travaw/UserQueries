using ProgCentrTestTask.Application.DTOs;
using ProgCentrTestTask.Application.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgCentrTestTask.Application.Services
{
    public interface IQueryService
    {
        void Add(QueryCreateDTO dto);

        ICollection<QueryDisplayDTO> GetAllExecuted();

        ICollection<QueryDisplayDTO> GetAllNotExecuted();

        ICollection<QueryDisplayDTO> GetAllForUser(int userId);

        ICollection<QueryDisplayDTO> Get(DateTime creationTime);

        Task<ICollection<UserDTO>> Execute(int id, WebRequestHelper helper);
    }
}
