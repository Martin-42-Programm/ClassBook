using System;
using ClassBook.Models.User;

namespace ClassBook.Repository.Interfaces
{
	public interface IUserRepository
	{

        IEnumerable<UserViewModel> GetAll();
    }
}

