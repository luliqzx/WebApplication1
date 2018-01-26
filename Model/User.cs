using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class User : BaseTID<string>
    {
        public virtual string Username { get; set; }
        public virtual string Name { get; set; }
    }
}
