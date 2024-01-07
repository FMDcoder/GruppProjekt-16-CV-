using System.ComponentModel.DataAnnotations;

namespace Models
{
	public class EducationValidate
	{
		public int id { get; set; } = 0;

		[Required(ErrorMessage = "Varje Skola måste ha ett namn!")]
		[StringLength(100, ErrorMessage = "Skolans namn får inte vara längre än 100 karaktärer!")]
		public string schoolTitle { get; set; }

		[Required(ErrorMessage = "Det måste finnas en titel för utbildningen!")]
		[StringLength(100, ErrorMessage = "Titeln på utbildningen får inte vara längre än 100 karaktärer!")]
		public string professionTitle { get; set; } = "";

		[Range(0, 100, ErrorMessage = "Utbildningen kan inte vara mindre än 0 eller högre än 100!")]
		public int time { get; set; } = 0;
	}
}