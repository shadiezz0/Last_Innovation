using Core.Interfaces.InterfacesPages;
using Core.Models;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.ReposPages
{
    public class UserRepos: IUser
    {
        private readonly InnovationDbContext _context;
        public UserRepos(InnovationDbContext context) 
        {
            _context = context;
        }

        public async Task<bool> AddUser(User model)
        {
            try
            {
                var searchedUser = _context.Users.Where(obj => obj.Email == model.Email).FirstOrDefault();

                if(searchedUser is not null)
                    return false;

                await _context.Users.AddAsync(model);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> VerifyLoginAsync(string email, string password)
        {
                var searchedUser = _context.Users.Where(obj => obj.Email == email && obj.Password == password && obj.Role).FirstOrDefault();
                if (searchedUser != null) 
                    return true;
                else
                    return false;
        }
        public async Task<bool> VerifyLoginClientAsync(string email, string password)
        {
            var searchedUser = _context.Users.Where(obj => obj.Email == email && obj.Password == password && !obj.Role).FirstOrDefault();
            if (searchedUser != null)
                return true;
            else
                return false;
        }
    }
}
