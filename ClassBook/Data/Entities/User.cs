using System;
using Microsoft.AspNetCore.Identity;

namespace ClassBook.Data.Entities
{
	public class User : IdentityUser
	{
		public string Name { set; get; }
	}
}

