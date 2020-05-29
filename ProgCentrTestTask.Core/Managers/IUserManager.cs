using ProgCentrTestTask.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgCentrTestTask.Core.Managers
{
    public interface IUserManager
    {
        ICollection<User> Add(Query query, params User[] newUsers);

        User Get(int Id);

        User Get(Func<User,bool> predicate);

        ICollection<User> GetAll();

        ICollection<User> GetAllForQuery(int queryId);

        ICollection<User> Search(Func<User, bool> predicate);

    }
}
