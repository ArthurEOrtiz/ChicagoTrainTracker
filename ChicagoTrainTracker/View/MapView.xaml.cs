using System.Windows.Controls;


namespace ChicagoTrainTracker.View
{
	/// <summary>
	/// Interaction logic for MapView.xaml
	/// </summary>
	public partial class MapView : UserControl
	{
		public MapView()
		{
			InitializeComponent();
		}

		private void myMap_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			e.Handled = true;
		}
	}
}
