using System.ComponentModel.DataAnnotations;

namespace Models
{
	public class CompanyValidate
	{
		[Required(ErrorMessage = "Varje företag måste ha ett namn!")]
		[StringLength(100, ErrorMessage = "Namnet på företaget får inte vara längre än 100 karaktärer!")]
		public string Title { get; set; } = "";
	}
}
