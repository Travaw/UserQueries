using ProgCentrTestTask.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgCentrTestTask.Application.Services
{
    public interface IUserService
    {
        ICollection<UserDTO> Search(UserDTO search);

        ICollection<UserDTO> SearchForQuery(UserDTO search, int queryId);

        ICollection<UserDTO> GetAll();

        ICollection<UserDTO> GetAllForQuery(int queryId);
    }
}
