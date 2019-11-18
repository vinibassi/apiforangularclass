
using System.Collections.Generic;
using System.Linq;

namespace DAL.User
{
    public class UserRepository : RepositorioBaseEF<User>, IUserRepository  
    {
        private readonly ApiForAngularContext context;
        public UserRepository(ApiForAngularContext context) : base(context)
        {
            this.context = context;
        }

        public IEnumerable<User> GetList()
        {
            return context.Users.Select(u => u).ToList();
        }
    }

    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<User> GetList();
    }

}
