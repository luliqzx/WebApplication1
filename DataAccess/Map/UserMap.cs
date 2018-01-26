using FluentNHibernate.Mapping;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Map
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(x => x.ID).GeneratedBy.Assigned();
            Map(x => x.Name).Not.Nullable().Length(100);
            Map(x => x.Username).Unique().Not.Nullable().Length(25);
        }
    }
}
