using System.ComponentModel.DataAnnotations;

namespace Models
{
	public class ProfessionValidate
	{
		[Required(ErrorMessage = "Det måste finnas en titel för utbildningen!")]
		[StringLength(100, ErrorMessage = "Titeln på utbildningen får inte vara längre än 100 karaktärer!")]
		public string Title { get; set; } = "";

		[Range(0, 100, ErrorMessage = "Utbildningen kan inte vara mindre än 0 eller högre än 100!")]
		public int Time { get; set; } = 0;
	}
}
