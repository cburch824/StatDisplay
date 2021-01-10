using System.Windows.Controls;
using X4Foundations.FrontEnd.Wpf.ViewModel;

namespace X4Foundations.FrontEnd.Wpf.View
{
	/// <summary>
	/// Interaction logic for BulletsView.xaml
	/// </summary>
	public partial class BulletsView : UserControl
	{
		public BulletsView()
		{
			InitializeComponent();
			BulletsViewModel bulletsViewModel = new BulletsViewModel();
			DataContext = bulletsViewModel;
		}
	}
}
