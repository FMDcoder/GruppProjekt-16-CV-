using System.ComponentModel.DataAnnotations;

namespace Models
{
	public class SkillsValidate
	{
		[Required(ErrorMessage = "Varje kompetens måste ha ett namn!")]
		[StringLength(100, ErrorMessage = "kompetens namn får inte vara längre än 100 karaktärer!")]
		public string Title { get; set; }
	}
}
