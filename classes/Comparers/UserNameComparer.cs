using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classes.Comparers
{
    public class UserNameComparer : IComparer<User>
    {
        public int Compare(User x, User y)
        {

            return x.Username.CompareTo(y.Username);
        }
    }
}
