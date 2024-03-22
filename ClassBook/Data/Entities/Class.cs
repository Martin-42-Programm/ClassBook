using System;
using System.ComponentModel.DataAnnotations;

namespace ClassBook.Data.Entities
{
	public class Class
	{
		[Key]
		public string Id { get; set; }

		
		public Class()
		{

		}

		public Class(string className)
		{
			this.Id = className;
			
		}
	}
}

