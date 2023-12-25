using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GruppProjekt_Grupp16_CV.Models
{
	public class VisitedCV
	{
		[Key, Column(Order = 0)]
		public string VisitorUserId { get; set; }

		[Key, Column(Order = 1)]
		public string OwnerUserId { get; set; }

		[ForeignKey(nameof(VisitorUserId))]
		public virtual User VisitorUserObject { get; set; }

		[ForeignKey(nameof(OwnerUserId))]
		public virtual User OwnerUserObject { get; set; }
	}
}
