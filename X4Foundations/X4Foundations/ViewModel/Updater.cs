using System;
using System.Windows.Input;

namespace X4Foundations.ViewModel
{
	public class Updater : ICommand
	{
		public bool CanExecute(object parameter)
		{
			return true;
		}

		public event EventHandler CanExecuteChanged;

		public void Execute(object parameter)
		{

		}
	}
}
