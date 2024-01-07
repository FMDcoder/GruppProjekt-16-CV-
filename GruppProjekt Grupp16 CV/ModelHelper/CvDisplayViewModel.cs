using GruppProjekt_Grupp16_CV.Models;
using Models;
using System.ComponentModel.DataAnnotations;

namespace GruppProjekt_Grupp16_CV.ModelHelper
{
	public class CvDisplayViewModel
	{
		public User user {  get; set; }
		public int Visited {  get; set; }
		public bool isOwner { get; set; }

		[RegularExpression("^[a-zA-Z0-9åäöÅÄÖ]+(,[a-zA-Z0-9åäöÅÄÖ]+)*$", ErrorMessage = "Du måste skriva användarenamn med endast nummer eller bokstäver med seperation av comma tecken!")]
		[Required(ErrorMessage = "Du måste skicka meddelandet till någon!")]
		public string SendTo { get; set; }

		[Required(ErrorMessage = "Du måste ha en titel!")]
		[StringLength(100, ErrorMessage = "Titeln får inte ha mer än 100 karaktärer!")]
		public string Title { get; set; }

		[RegularExpression("^[A-Za-zåäöÅÄÖ - ]*$", ErrorMessage = "Namnet får endast ha bokstäver, bindesträck och mellanslag!")]
		public string AnonymName { get; set; } = "";

		[Required(ErrorMessage = "Du måste skriva något som meddelande!")]
		[DataType(DataType.MultilineText)]
		[StringLength(1000, ErrorMessage = "Meddalandet får inte ha mer än 1000 karaktärer!")]
		public string Description { get; set; }

		public bool success { get; set; }
	}
}
