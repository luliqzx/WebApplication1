using DataAccess.Common;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repo
{
    public interface IUserRepo : IBaseRepo<User>
    {
    }

    public class UserRepo : BaseRepo<User>, IUserRepo
    {
        public UserRepo(ISessionProvider _SessionProvider) : base(_SessionProvider)
        {
            SessionProvider = _SessionProvider;
            SessionFactory = SessionProvider.GetSessionFactory();
            Session = SessionFactory.OpenSession();
        }
    }
}
