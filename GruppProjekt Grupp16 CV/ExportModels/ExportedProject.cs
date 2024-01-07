namespace GruppProjekt_Grupp16_CV.ExportModels
{
	[Serializable]
	public class ExportedProject
	{
		public string title { get; set; }
		public string description { get; set; }
		public string lastUpdated { get; set; }
		public List<string> collaborators { get; set; }
	}
}
