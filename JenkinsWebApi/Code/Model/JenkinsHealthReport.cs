using System.Xml.Serialization;

namespace JenkinsWebApi.Model
{
    // hudson.model.HealthReport
    public partial class JenkinsHealthReport
    {
        [XmlElement("description")]
        public string Description { get; set; }

        [XmlElement("iconClassName")]
        public string IconClassName { get; set; }

        [XmlElement("iconUrl")]
        public string IconUrl { get; set; }

        [XmlElement("score")]
        public int Score { get; set; }

        /// <summary>
        /// Jenkins Java class name.
        /// </summary>
        [XmlAttribute("_class")]
        public string Class { get; set; }
    }
}
