using Core.Interfaces;
using Core.Models;
using Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class ContactServ : IContactServ
    {
        private readonly IUnitOfWork _unitOfWork;

        public ContactServ(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(Contact contact)
        {
            await _unitOfWork.Contact.AddAsync(contact);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var pageToDelete = await _unitOfWork.Contact.GetByIdAsync(id);
            if (pageToDelete != null)
            {
                _unitOfWork.Contact.Delete(pageToDelete);
                await _unitOfWork.CompleteAsync();
            }
        }

        public async Task<IEnumerable<Contact>> GetAllAsync()
        {
            return await _unitOfWork.Contact.GetContactAsync();
        }

        public async Task<Contact> GetByIdAsync(int id)
        {
            return await _unitOfWork.Contact.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Contact contact)
        {
            _unitOfWork.Contact.Update(contact);
            await _unitOfWork.CompleteAsync();
        }

		public async Task<IEnumerable<Contact>> GetEnglishDataAsync()
		{
			return await _unitOfWork.Contact.GetEnglishDataAsync();
		}

		public async Task<IEnumerable<Contact>> GetArabicDataAsync()
		{
			return await _unitOfWork.Contact.GetArabicDataAsync();
		}
	}
}
