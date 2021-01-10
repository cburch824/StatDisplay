using System.Collections.Generic;
using System.Windows.Input;
using X4Foundations.DataAccess.DataAccess;
using X4Foundations.DataAccess.Model.Engine;

namespace X4Foundations.FrontEnd.Wpf.ViewModel
{
	class EnginesViewModel
	{
		public IList<EngineModel> Engines { get; set; }
		public ICommand UpdateCommand { get; set; } = new Updater();

		public EnginesViewModel()
		{
			const string engineFolderPath = @"C:\Program Files (x86)\Steam\steamapps\common\X4 Foundations\unpacked\assets\props\Engines\macros";
			Engines = new EngineGetter(engineFolderPath).PopulateEngines();
		}
	}
}
