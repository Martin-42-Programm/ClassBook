using System;
using System.ComponentModel.DataAnnotations;

namespace ClassBook.Data.Entities
{
	public class Subject
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }


		public Subject()
		{
		}

        public Subject(string name)
        {
			this.Name = name;
        }

		
    }
}

