using System.Xml.Serialization;

namespace JenkinsWebApi.Model
{
    // hudson.model.labels.LabelAtomProperty
    public partial class JenkinsLabelAtomProperty
    {
        /// <summary>
        /// Jenkins Java class name.
        /// </summary>
        [XmlAttribute("_class")]
        public string Class { get; set; }
    }
}
