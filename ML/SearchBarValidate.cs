using System.ComponentModel.DataAnnotations;

namespace Models
{
	public class SearchBarValidate
	{
		[Required(ErrorMessage = "Du måste skriva in något innan du kan söka")]
		public string search { get; set; } = "";
	}
}
