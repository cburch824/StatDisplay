using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using X4Foundations.DataAccess;
using X4Foundations.Model.Engine;

namespace X4Foundations.ViewModel
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
