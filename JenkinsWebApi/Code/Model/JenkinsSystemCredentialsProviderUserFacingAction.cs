using System.Xml.Serialization;

namespace JenkinsWebApi.Model
{
    // com.cloudbees.plugins.credentials.SystemCredentialsProvider-UserFacingAction
    [XmlRoot("userFacingAction")]
    public partial class JenkinsSystemCredentialsProviderUserFacingAction : JenkinsCredentialsStoreAction
    {
        // empty
    }
}
