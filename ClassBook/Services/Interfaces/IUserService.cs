using System;
using ClassBook.Models.User;

namespace ClassBook.Services.Interfaces
{
	public interface IUserService
	{
        IEnumerable<UserViewModel> GetAll();

        Task<IEnumerable<UserViewModel>> GetAllAsync();
    }
}

