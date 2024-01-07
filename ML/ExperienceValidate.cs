using System.ComponentModel.DataAnnotations;

namespace Models
{
	public class ExperienceValidate
	{
		public int id { get; set; } = 0;

		[Required(ErrorMessage = "Varje företag måste ha ett namn!")]
		[StringLength(100, ErrorMessage = "Namnet på företaget får inte vara längre än 100 karaktärer!")]
		public string companyTitle { get; set; } = "";

		[Required(ErrorMessage = "Varje jobb måste ha en titel!")]
		[StringLength(100, ErrorMessage = "Titeln på jobbet får inte vara längre än 100 karaktärer!")]
		public string jobTitle { get; set; } = "";

		[Required(ErrorMessage="Du måste ha jobbat en viss tid!")]
		[RegularExpression(@"^\d+$", ErrorMessage = "Det antal år du har jobbat måste vara ett heltal!")]
		public int time {  get; set; }
	}
}
