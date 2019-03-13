using System.Xml.Serialization;

namespace JenkinsWebApi.Model
{
    // hudson.scm.SCM
    public partial class JenkinsSCM
    {
        [XmlElement("browser")]
        public JenkinsRepositoryBrowser[] Browsers { get; set; }

        [XmlElement("type")]
        public string[] Types { get; set; }

        /// <summary>
        /// Jenkins Java class name.
        /// </summary>
        [XmlAttribute("_class")]
        public string Class { get; set; }
    }
}
