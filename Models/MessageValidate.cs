using System.ComponentModel.DataAnnotations;

namespace Models
{
	public class MessageValidate
	{
		[Required(ErrorMessage = "Varje meddelande måste ha en titel!")]
		[StringLength(100, ErrorMessage = "Titeln på meddalandet får inte vara längre än 100 karaktärer!")]
		public string Title { get; set; }

		[StringLength(1000, ErrorMessage = "Meddelandet får inte ha mer än 1000 karaktärer!")]
		public string? Description { get; set; }
	}
}
