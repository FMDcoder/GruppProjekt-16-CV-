using System.Xml.Serialization;

namespace GruppProjekt_Grupp16_CV.ExportModels
{
	[Serializable]
	public class ExportUser
    {
        public string Name { get; set; }
        public string Adress { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
		public List<ExportedEducation> Educations { get; set; } = new List<ExportedEducation>();
		public List<ExportedExperience> Experience { get; set; } = new List<ExportedExperience>();
		public List<ExportedSkills> Skills { get; set; } = new List<ExportedSkills>();
		public List<ExportedProject> CollabratorProjects { get; set; } = new List<ExportedProject>();
		public List<ExportedProject> CreatedProjects { get; set; } = new List<ExportedProject>();
	}
}
