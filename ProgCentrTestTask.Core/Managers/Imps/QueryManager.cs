using ProgCentrTestTask.Core.Context;
using ProgCentrTestTask.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgCentrTestTask.Core.Managers
{
    public class QueryManager : IQueryManager
    {
        public Query Add(Query newQuery)
        {
            using (QueriesContext context = new QueriesContext())
            {
                newQuery.CreationDate = DateTime.Now;
                var query = context.Queries.Add(newQuery);
                context.SaveChanges();
                return query;
            }
        }
        
        public Query Get(int id)
        {
            using (QueriesContext context = new QueriesContext())
            {
                var query = context.Queries.Find(id);
                return query;
            }
        }

        public ICollection<Query> GetAll()
        {
            using (QueriesContext context = new QueriesContext())
            {
                var query = context.Queries;
                return query.ToList();
            }
        }

        public ICollection<Query> GetAllExecuted()
        {
            using (QueriesContext context = new QueriesContext())
            {
                var query = context.Queries.Where(q=>q.IsExecuted==true);
                return query.ToList();
            }
        }

        public ICollection<Query> GetAllForUser(int userId)
        {
            using (QueriesContext context = new QueriesContext())
            {
                var query = context.Queries.Where(u => u.Users.Where(q => q.Id == userId).FirstOrDefault() != null);
                return query.ToList();
            }
        }

        public ICollection<Query> GetAllForUser()
        {
            throw new NotImplementedException();
        }

        public ICollection<Query> GetAllNotExecuted()
        {
            using (QueriesContext context = new QueriesContext())
            {
                var query = context.Queries.Where(q => q.IsExecuted == false);
                return query.ToList();
            }
        }

        public ICollection<Query> Search(Func<Query, bool> predicate)
        {
            using (QueriesContext context = new QueriesContext())
            {
                var query = context.Queries.Where(predicate).ToList();
                return query;
            }
        }

        public Query SetExecuted(Query query)
        {
            using (QueriesContext context = new QueriesContext())
            {
                context.Queries.Attach(query); 
                query.IsExecuted=true;
                context.SaveChanges();
                return query;
            }
        }
    }
}
