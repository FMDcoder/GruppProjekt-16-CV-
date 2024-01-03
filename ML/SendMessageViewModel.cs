using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class SendMessageViewModel
    {
        [Required(ErrorMessage = "Du måste skicka meddelandet till någon!")]
        public string SendTo {  get; set; }

        [Required(ErrorMessage = "Du måste ha en titel!")]
        [StringLength(100, ErrorMessage = "Titeln får inte ha mer än 100 karaktärer!")]
        public string Title { get; set; }

		[DataType(DataType.MultilineText)]
		[StringLength(1000, ErrorMessage = "Meddalandet får inte ha mer än 1000 karaktärer!")]
        public string Description { get; set; }
    }
}
