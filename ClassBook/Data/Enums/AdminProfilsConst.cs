using System;
namespace ClassBook.Data.Enums
{
	public class AdminProfilsConst
	{


        public static string Id;

        public static string Email;

        public static string Name;
        public static string Password;


        public AdminProfilsConst()
        {
            Id = Guid.NewGuid().ToString();
            Email = "admin@gmail.com";
            Name = "Marti";
            Password = "Mart1";
        }

        

    }
}

