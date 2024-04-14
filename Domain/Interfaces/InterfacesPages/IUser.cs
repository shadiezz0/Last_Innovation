using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.InterfacesPages
{
    public interface IUser
    {
        Task<bool> VerifyLoginAsync(string email, string password);
        Task<bool> VerifyLoginClientAsync(string email, string password);
        Task<bool> AddUser(User model);
    }
}
