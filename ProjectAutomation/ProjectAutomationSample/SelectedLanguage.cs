namespace Sdl.ProjectAutomation.ProjectAutomationSample
{
    public class SelectedLanguage
    {
        public SelectedLanguage(string displayName, string name)
        {
            this.DisplayName = displayName;
            this.Name = name;
        }

        public string DisplayName
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public override string ToString()
        {
            return this.DisplayName;
        }
    }
}
