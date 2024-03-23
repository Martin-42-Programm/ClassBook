using System;
using Microsoft.AspNetCore.Identity;

namespace ClassBook.Data.Entities
{
	public class User : IdentityUser
	{
		public string Name { set; get; }


		public User(string id, string email, string userName)
		{
			Id = id;
			Email = email;
			Name = userName;
			UserName = userName;
		
		}
	}
}

