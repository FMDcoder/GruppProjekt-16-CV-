﻿using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Models
{
	public class UserRegisterValidate
	{
		[Required(ErrorMessage = "Varje användare måste ha en namn!")]
		[StringLength(100, ErrorMessage = "Namnet på användaren får inte vara längre än 100 karaktärer!")]
		[RegularExpression(@"^[a-zA-Z0-9åäöÅÄÖ]{3,}$", ErrorMessage = "Namnet får inte ha något special tecken och måste vara minst 3 karaktärer lång!")]
		public string UserName { get; set; }

		[Required(ErrorMessage = "Varje användare måste ha ett telefonnummer!")]
		[StringLength(100, ErrorMessage = "Telefonnumret på användaren får inte vara längre än 100 karaktärer!")]
		[RegularExpression(@"^[0-9]+$", ErrorMessage = "Telefonnummret får endast vara siffror!")]
		public string PhoneNumber { get; set; }

		[Required(ErrorMessage = "Varje användare måste ha en adress!")]
		[StringLength(100, ErrorMessage = "Adressen på användaren får inte vara längre än 100 karaktärer!")]
		public string Adress { get; set; }

		[Required(ErrorMessage = "Varje användare måste ha ett email!")]
		[StringLength(100, ErrorMessage = "Emailet på användaren får inte vara längre än 100 karaktärer!")]
		[EmailAddress(ErrorMessage = "Ogiltigt email!")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Du måste bekräfta email!")]
		[Compare(nameof(Email), ErrorMessage = "Emailen stämmer inte ihop!")]
		public string ConfirmEmail { get; set; }

		[DataType(DataType.Upload)]
		[Required(ErrorMessage = "Du måste ha en profil bild!")]
		public IFormFile ProfilePicture { get; set; }

		[DataType(DataType.Password)]
		[StringLength(100, ErrorMessage = "Lösenordet på användaren får inte vara längre än 100 karaktärer!")]
		[Required(ErrorMessage = "Varje användare måste ha ett lösenord!")]
		public string Password { get; set; }

		[DataType(DataType.Password)]
		[Required(ErrorMessage = "Du måste bekräfta lösenord!")]
		[Compare("Password", ErrorMessage = "Bekräftelse lösenordet måste matcha varandra")]
		public string ConfirmPassword { get; set; }

		public bool Status { get; set; }
	}
}
