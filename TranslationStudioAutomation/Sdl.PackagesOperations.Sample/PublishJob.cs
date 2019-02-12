using Sdl.Desktop.IntegrationApi;

namespace Sdl.PackagesOperations.Sample
{
    /// <summary>
    /// 
    /// </summary>
    public class PublishJob : IRelayJob
    {
        private object _jobData;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="jobData"></param>
        public PublishJob(object jobData)
        {
            _jobData = jobData;
        }

        /// <summary>
        /// 
        /// </summary>
        public object JobData
        {
            get => _jobData;
            set => _jobData = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Execute()
        {
            System.Threading.Thread.Sleep(5000);

            var data = (string)JobData;
            return "Publish event executed -> " + data;
        }
    }
}
