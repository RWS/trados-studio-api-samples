namespace Sdl.ProjectAutomation.ProjectOperations.Logic
{
    public class SelectedLanguage
    {
        public SelectedLanguage(string displayName, string name)
        {
            DisplayName = displayName;
            Name = name;
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
            return DisplayName;
        }
    }
}
