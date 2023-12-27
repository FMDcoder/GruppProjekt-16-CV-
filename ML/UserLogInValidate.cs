﻿using System.ComponentModel.DataAnnotations;

namespace Models
{
	public class UserLogInValidate
	{
		[Required(ErrorMessage = "Du kan inte logga in utan att ha skrivit ett namn!")]
		public string UserName { get; set; }

		[DataType(DataType.Password)]
		[Required(ErrorMessage = "Du kan inte logga in utan att ha skrivit in ett lösenord!")]
		public string PasswordHash { get; set; }

		public bool RememberMe { get; set; }
	}
}
