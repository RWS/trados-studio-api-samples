using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StudioIntegrationApiSample
{
    class ContentConnector
    {
        public static readonly ContentConnector Instance = new ContentConnector();

        private ContentConnector()
        {
        }

        public List<ProjectRequest> ProjectRequests
        {
            get; private set;
        }

        public void Refresh()
        {
            ProjectRequests = new List<ProjectRequest>();

            string dropFolder = GetIncomingRequestsFolder();

            foreach (string directory in Directory.GetDirectories(dropFolder))
            {
                DirectoryInfo dirInfo = new DirectoryInfo(directory);
                ProjectRequests.Add(new ProjectRequest
                {
                    Name = dirInfo.Name,
                    Files = Directory.GetFiles(directory)
                });
            }
        }

        private static string GetIncomingRequestsFolder()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Studio 2015\\IncomingRequests");
        }

        private static string GetAcceptedRequestsFolder()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Studio 2015\\AcceptedRequests");
        }

        internal void RequestAccepted(ProjectRequest request)
        {
            Directory.CreateDirectory(GetAcceptedRequestsFolder());
            Directory.Move(Path.Combine(GetIncomingRequestsFolder(), request.Name), Path.Combine(GetAcceptedRequestsFolder(), request.Name));
        }
    }
}
