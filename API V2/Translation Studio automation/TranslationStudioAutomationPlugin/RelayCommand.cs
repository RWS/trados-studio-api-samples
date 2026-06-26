using System;
using System.Diagnostics;
using System.Windows.Input;

namespace TranslationStudioAutomationPlugin
{
	public class RelayCommand : ICommand
	{
		private readonly Action _execute;
		private readonly Func<bool> _canExecute;

		public RelayCommand(Action execute)
			: this(execute, null)
		{
		}

		public RelayCommand(Action execute, Func<bool> canExecute)
		{
			_execute = execute ?? throw new ArgumentNullException("execute");
			_canExecute = canExecute;
		}

		[DebuggerStepThrough]
		public bool CanExecute(object parameter)
		{
			return _canExecute == null || _canExecute();
		}

		public event EventHandler CanExecuteChanged
		{
			add
			{
				if (_canExecute != null)
				{
					CommandManager.RequerySuggested += value;
				}
			}
			remove
			{
				if (_canExecute != null)
				{
					CommandManager.RequerySuggested -= value;
				}
			}
		}

		public void Execute(object parameter)
		{
			_execute();
		}
	}
}