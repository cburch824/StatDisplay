using System.Windows.Controls;
using X4Foundations.FrontEnd.Wpf.ViewModel;

namespace X4Foundations.FrontEnd.Wpf.View
{
	/// <summary>
	/// Interaction logic for TurretsView.xaml
	/// </summary>
	public partial class TurretsView : UserControl
	{
		public TurretsView()
		{
			InitializeComponent();
			TurretsViewModel turretsViewModel = new TurretsViewModel();
			DataContext = turretsViewModel;
		}
	}
}
