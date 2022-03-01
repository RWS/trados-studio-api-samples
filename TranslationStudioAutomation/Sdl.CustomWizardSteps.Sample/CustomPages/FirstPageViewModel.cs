using Sdl.CustomWizardSteps.Sample.Mvvm;
using System;
using System.Windows.Input;

namespace Sdl.CustomWizardSteps.Sample.CustomPages
{
    public class FirstPageViewModel : ViewModelBase
    {
        private DateTime _currentDate;

        public FirstPageViewModel()
        {
            SetDate();
            UpDateCommand = new RelayCommand(ExecuteUpdateCommand);
        }

        public DateTime CurrentDate
        {
            get { return _currentDate; }
            set { SetProperty(ref _currentDate, value); }
        }

        public ICommand UpDateCommand { get; private set; }

        private void ExecuteUpdateCommand()
        {
            SetDate();
        }

        private void SetDate()
        {
            CurrentDate = DateTime.Now;
        }

    }
}
