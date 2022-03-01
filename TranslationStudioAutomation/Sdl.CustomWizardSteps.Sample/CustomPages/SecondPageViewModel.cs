using Sdl.CustomWizardSteps.Sample.Mvvm;
using System;

namespace Sdl.CustomWizardSteps.Sample.CustomPages
{
    public class SecondPageViewModel : ViewModelBase
    {
        private DateTime _selectedDate;

        public DateTime SelectedDate
        {
            get { return _selectedDate; }
            set { SetProperty(ref _selectedDate, value); }
        }

    }
}
