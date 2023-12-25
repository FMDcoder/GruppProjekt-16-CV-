using System.ComponentModel.DataAnnotations;

namespace Models
{
	public class ProjectValidate
	{
		[Required(ErrorMessage = "Projektet måste ha ett namn!")]
		[StringLength(100, ErrorMessage = "Projektets Titel får inte vara längre än 100 karaktärer!")]
		public string Title { get; set; }

		[StringLength(1000, ErrorMessage = "Projektets beskrivning får inte vara längre än 1000 karaktärer!")]
		public string? Description { get; set; }
	}
}
