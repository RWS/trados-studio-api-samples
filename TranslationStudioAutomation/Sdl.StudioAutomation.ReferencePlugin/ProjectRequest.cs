using System.Collections.Generic;

namespace StudioIntegrationApiSample
{
    public class ProjectRequest
    {
        public string Name
        {
            get;
            set;
        }

        public List<string> Files
        {
            get; set;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
