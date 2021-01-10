using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using X4Foundations.ViewModel;

namespace X4Foundations.View
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
