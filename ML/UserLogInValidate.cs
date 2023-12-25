using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
	public class UserLogInValidate
	{
		[Required(ErrorMessage = "Du kan inte logga in utan att ha skrivit ett namn!")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Du kan inte logga in utan att ha skrivit in ett lösenord")]
		public string Password { get; set; }
	}
}
