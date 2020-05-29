using ProgCentrTestTask.Core.Context;
using ProgCentrTestTask.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgCentrTestTask.Core.Managers
{
    public class UserManager : IUserManager
    {       
        public ICollection<User> Add(Query query, params User[] newUsers)
        {
            using(QueriesContext context = new QueriesContext())
            {
                context.Queries.Attach(query);
                foreach(var newUser in newUsers)
                {
                    User userExistCheck = context.Users.Find(newUser.Id);
                    if (userExistCheck == null)
                    {
                        userExistCheck = newUser;
                        context.Users.Add(newUser);
                    }
                    userExistCheck.Queries.Add(query);
                    
                }
                context.SaveChanges();
            }
            return newUsers;
        }


        public User Get(int id)
        {
            using(QueriesContext context = new QueriesContext())
            {
                var user = context.Users.Find(id);
                return user;
            }
        }

        public User Get(Func<User, bool> predicate)
        {
            using (QueriesContext context = new QueriesContext())
            {
                var user = context.Users.Where(predicate).FirstOrDefault();
                return user;
            }            
        }

        public ICollection<User> GetAll()
        {
            using (QueriesContext context = new QueriesContext())
            {
                var users = context.Users.ToList();
                return users;
            }            
        }

        public ICollection<User> GetAllForQuery(int queryId)
        {
            using (QueriesContext context = new QueriesContext())
            {
                var users = context.Users.Where(u=>u.Queries.Where(q=>q.Id==queryId).FirstOrDefault()!=null).ToList();
                return users;
            }
            
        }

        public ICollection<User> Search(Func<User, bool> predicate)
        {            
            
            using (QueriesContext context = new QueriesContext())
            {                
                var users = context.Users.Where(predicate).ToList();
                return users;

            }
        }
    }
}
