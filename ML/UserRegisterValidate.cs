using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
	public class UserRegisterValidate
	{
		[Required(ErrorMessage = "Varje användare måste ha en namn!")]
		[StringLength(100, ErrorMessage = "Namnet på användaren får inte vara längre än 100 karaktärer!")]
		[RegularExpression(@"^[a-zA-Z0-9åäöÅÄÖ]{3,}$", ErrorMessage = "Namnet får inte ha något special tecken och måste vara minst 3 karaktärer lång!")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Varje användare måste ha ett telefonnummer!")]
		[StringLength(10, ErrorMessage = "Telefonnumret på användaren får inte vara längre än 100 karaktärer!")]
		[RegularExpression(@"^[0-9]+$", ErrorMessage = "Telefonnummret får endast vara siffror!")]
		public string PhoneNumber { get; set; }

		[Required(ErrorMessage = "Varje användare måste ha ett email!")]
		[StringLength(100, ErrorMessage = "Emailet på användaren får inte vara längre än 100 karaktärer!")]
		[EmailAddress(ErrorMessage = "Ogiltigt email!")]
		public string Email { get; set; }

		[RegularExpression(@"^(http(s?)://)?([\w-]+\.)+[\w-]+(/[\w- ;,./?%&=]*)?$", ErrorMessage = "Ogiltigt url för profil bild! Endast jpg eller png!")]
		public string? ProfilePicture { get; set; }

		[StringLength(100, ErrorMessage = "Lösenordet på användaren får inte vara längre än 100 karaktärer!")]
		[Required(ErrorMessage = "Varje användare måste ha ett lösenord!")]
		public string Password { get; set; }

		[Compare("Password", ErrorMessage = "Bekräftelse lösenordet måste matcha varandra")]
		public string ConfirmPassword { get; set; }

		public bool Status { get; set; }
	}
}
