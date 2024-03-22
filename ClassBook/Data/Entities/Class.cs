using System;
using System.ComponentModel.DataAnnotations;

namespace ClassBook.Data.Entities
{
	public class Class
	{
		[Key]
		public string Id { get; set; }

		[Required]
		public List<Student> Students { get; set; }


		public Class(string className, List<Student> students)
		{
			this.Id = className;
			this.Students = students;
		}
	}
}

