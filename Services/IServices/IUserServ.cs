using Core.Models;
using Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices
{
    public interface IUserServ
    {
       Task<bool> AuthenticateAsync(string email, string password);
       Task<bool> AuthenticateClienttAsync(string email, string password);
        Task<bool> AddUser(RegistrationDto model);
    }
}
