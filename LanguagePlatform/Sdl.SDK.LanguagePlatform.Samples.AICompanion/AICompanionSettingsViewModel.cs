using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace Sdl.SDK.LanguagePlatform.Samples.AICompanion
{
    internal class AICompanionSettingsViewModel : INotifyPropertyChanged
    {
        private readonly Window _window;
        private bool _autoTranslate;
        private ICommand _saveCommand;

        public AICompanionSettingsViewModel(Window window)
        {
            _window = window;
        }

        public bool AutoTranslate 
        { 
            get => _autoTranslate; 
            set
            {
                if (_autoTranslate == value)
                {
                    return;
                }

                _autoTranslate = value;
                OnPropertyChanged();
            }
        }

        public string SettingsDescription => PluginResources.Text_Add_Your_Settings_Here;

        public ICommand SaveCommand => _saveCommand ?? (_saveCommand = new CommandHandler(SaveChanges));

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void SaveChanges(object parameter)
        {
            _window.DialogResult = true;
            _window.Close();
        }
    }
}
