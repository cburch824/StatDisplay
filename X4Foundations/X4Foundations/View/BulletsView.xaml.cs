using System.Windows.Controls;
using X4Foundations.FrontEnd.Wpf.ViewModel;

namespace X4Foundations.FrontEnd.Wpf.View
{
	/// <summary>
	/// Interaction logic for EnginesView.xaml
	/// </summary>
	public partial class EnginesView : UserControl
	{
		public EnginesView()
		{
			InitializeComponent();
			EnginesViewModel enginesViewModel = new EnginesViewModel();
			DataContext = enginesViewModel;
		}
	}
}
