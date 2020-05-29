using ProgCentrTestTask.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgCentrTestTask.Core.Managers
{
    public interface IQueryManager
    {
        Query Add(Query newQuery);
        
        Query Get(int Id);

        ICollection<Query> GetAll();

        ICollection<Query> GetAllForUser(int userId);

        ICollection<Query> GetAllExecuted();

        ICollection<Query> GetAllNotExecuted();

        ICollection<Query> Search(Func<Query, bool> predicate);

        Query SetExecuted(Query query);
    }
}