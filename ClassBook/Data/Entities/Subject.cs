using System;
using System.ComponentModel.DataAnnotations;

namespace ClassBook.Data.Entities
{
	public class Subject
	{
		
		[Key]
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

