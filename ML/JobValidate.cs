using System.ComponentModel.DataAnnotations;

namespace Models
{
	public class JobValidate
	{
		[Required(ErrorMessage = "Varje jobb måste ha en titel!")]
		[StringLength(100, ErrorMessage = "Titeln på jobbet får inte vara längre än 100 karaktärer!")]
		public string Title { get; set; }
	}
}
