using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBoard.Models
{
    internal interface IUserRepository
    {
        bool CreateUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(int id);
        User BrowseUser(int id);
    }
}
