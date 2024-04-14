using Core.Interfaces;
using Core.Models;
using Services.DTOs;
using Services.IServices;

namespace Services.Services
{
    public class UserServ : IUserServ
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserServ(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<bool> AddUser(RegistrationDto model)
        {
            var isAdded = _unitOfWork.User.AddUser(new User()
            {
                Email = model.email,
                Password = model.password,
                Name = model.name,
                Role = false
            });

            return isAdded;
        }

        public async Task<bool> AuthenticateAsync(string email, string password)
        {
                return await _unitOfWork.User.VerifyLoginAsync(email, password);
        }

        public async Task<bool> AuthenticateClienttAsync(string email, string password)
        {
            return await _unitOfWork.User.VerifyLoginClientAsync(email, password);
        }
    }
}
