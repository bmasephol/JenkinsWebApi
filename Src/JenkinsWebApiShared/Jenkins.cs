using System;
using System.Net.Http;

namespace JenkinsWebApi
{
    /// <summary>
    /// Main class of the Jenkins server API
    /// </summary>
    public partial class Jenkins
    {
        /// <summary>
        /// JobRunAsync progress event.
        /// </summary>
        public event EventHandler<JenkinsRunProgress> RunProgress;

        private HttpClient httpClient { get; set; }

        private string prependUrlPath { get; set; }

        /// <summary>
        /// JobRunAsync global configuration.
        /// </summary>
        public JenkinsRunConfig RunConfig { get; set; }

        /// <summary>
        /// Initializes a new instance of the Jenkins class.
        /// </summary>
        /// <param name="host">Host URL of the Jenkins server.</param>
        public Jenkins(string host) : this(new Uri(host), null, null)
        { }

        /// <summary>
        /// Initializes a new instance of the Jenkins class.
        /// </summary>
        /// <param name="host">Host URL of the Jenkins server.</param>
        public Jenkins(Uri host) : this(host, null, null)
        { }

        /// <summary>
        /// Initializes a new instance of the Jenkins class.
        /// </summary>
        /// <param name="host">Host URL of the Jenkins server.</param>
        /// <param name="login">Login for the Jenkins server.</param>
        /// <param name="passwordOrToken">Password or API token for the Jenkins server.</param>
        public Jenkins(string host, string login, string passwordOrToken) : this(new Uri(host), login, passwordOrToken)
        { }

        /// <summary>
        /// Initializes a new instance of the Jenkins class.
        /// </summary>
        /// <param name="host">Host URL of the Jenkins server.</param>
        /// <param name="login">Login for the Jenkins server.</param>
        /// <param name="passwordOrToken">Password or API token for the Jenkins server.</param>
        public Jenkins(Uri host, string login, string passwordOrToken)
        {
            Connect(host, login, passwordOrToken);

            // init variables
            this.RunConfig = new JenkinsRunConfig();
        }

        /// <summary>
        /// Initializes a new instance of the Jenkins class.
        /// </summary>
        /// <param name="httpClient">HttpClient instance to be used by the Jenkins class.</param>
        /// <param name="prependUrlPath">URL to be prepended to all API requests.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public Jenkins(HttpClient httpClient, string prependUrlPath)
        {
            if (httpClient == null)
            {
                throw new ArgumentNullException(nameof(httpClient));
            }

            this.httpClient = httpClient;
            this.prependUrlPath = prependUrlPath;

            Connect(httpClient.BaseAddress, null, null);

            // init variables
            this.RunConfig = new JenkinsRunConfig();
        }

        /// <summary>
        /// Login to the Jenkins server.
        /// </summary>
        /// <param name="login">Login for the Jenkins server</param>
        /// <param name="passwordOrToken">Password or API token for the Jenkins server</param>
        /// <returns>true if login success; false if failed</returns>
        public bool Login(string login, string passwordOrToken)
        {
            if (string.IsNullOrEmpty(login))
            {
                throw new ArgumentNullException(nameof(login));
            }

            if (string.IsNullOrEmpty(passwordOrToken))
            {
                throw new ArgumentNullException(nameof(passwordOrToken));
            }

            // set authorization
            Authorize(login, passwordOrToken);

            return GetServerAsync().Result != null;
            // check if login success            
            // 
            //return GetCurrentUserAsync().Result != null;
        }
    }
}
