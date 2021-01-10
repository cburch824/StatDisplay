using System.Windows.Controls;
using X4Foundations.FrontEnd.Wpf.ViewModel;

namespace X4Foundations.FrontEnd.Wpf.View
{
	/// <summary>
	/// Interaction logic for ShipsView.xaml
	/// </summary>
	public partial class ShipsView : UserControl
	{
		public ShipsView()
		{
			InitializeComponent();
			ShipsViewModel shipsViewModel = new ShipsViewModel();
			DataContext = shipsViewModel;
		}
	}
}
