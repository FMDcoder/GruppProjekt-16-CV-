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

		[XmlArrayItem("Educations", typeof(ExportedEducation))]
		public List<ExportedEducation> Educations { get; set; } = new List<ExportedEducation>();

		[XmlArrayItem("Experience", typeof(ExportedExperience))]
		public List<ExportedExperience> Experience { get; set; } = new List<ExportedExperience>();

		[XmlArrayItem("Skills", typeof(ExportedSkills))]
		public List<ExportedSkills> Skills { get; set; } = new List<ExportedSkills>();

		[XmlArrayItem("CollabratorProjects", typeof(ExportedProject))]
		public List<ExportedProject> CollabratorProjects { get; set; } = new List<ExportedProject>();

		[XmlArrayItem("CreatedProjects", typeof(ExportedProject))]
		public List<ExportedProject> CreatedProjects { get; set; } = new List<ExportedProject>();
	}
}
