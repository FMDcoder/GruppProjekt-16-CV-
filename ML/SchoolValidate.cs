using System.ComponentModel.DataAnnotations;

namespace Models
{
	public class SchoolValidate
	{
		[Required(ErrorMessage = "Varje Skola måste ha ett namn!")]
		[StringLength(100, ErrorMessage = "Skolans namn får inte vara längre än 100 karaktärer!")]
		public string Title { get; set; }
	}
}
