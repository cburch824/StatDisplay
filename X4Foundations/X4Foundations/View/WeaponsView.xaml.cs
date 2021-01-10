using System.Windows.Controls;
using X4Foundations.FrontEnd.Wpf.ViewModel;

namespace X4Foundations.FrontEnd.Wpf.View
{
	/// <summary>
	/// Interaction logic for WeaponsView.xaml
	/// </summary>
	public partial class WeaponsView : UserControl
	{
		public WeaponsView()
		{
			InitializeComponent();
			WeaponsViewModel weaponsViewModel = new WeaponsViewModel();
			DataContext = weaponsViewModel;
		}
	}
}
