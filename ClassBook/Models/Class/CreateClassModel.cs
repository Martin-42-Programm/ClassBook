﻿using System;
namespace ClassBook.Models.Class
{
	public class CreateClassModel
	{
		public string Id { get; set; }

		public CreateClassModel()
		{ }


		public CreateClassModel(string id)
		{
			Id = id;
		}
	}
}

