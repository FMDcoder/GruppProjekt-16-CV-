using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class SendMessageViewModel
    {
        [RegularExpression("^[a-zA-Z0-9åäöÅÄÖ]+(,[a-zA-Z0-9åäöÅÄÖ]+)*$", ErrorMessage = "Du måste skriva användarenamn med endast nummer eller bokstäver med seperation av comma tecken!")]
        [Required(ErrorMessage = "Du måste skicka meddelandet till någon!")]
        public string SendTo {  get; set; }

        [Required(ErrorMessage = "Du måste ha en titel!")]
        [StringLength(100, ErrorMessage = "Titeln får inte ha mer än 100 karaktärer!")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Du måste skriva något som meddelande!")]
		[DataType(DataType.MultilineText)]
		[StringLength(1000, ErrorMessage = "Meddalandet får inte ha mer än 1000 karaktärer!")]
        public string Description { get; set; }

        public bool success { get; set; }
    }
}
