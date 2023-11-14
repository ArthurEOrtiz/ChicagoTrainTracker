using ChicagoTrainTracker.ViewModel;
using Microsoft.Maps.MapControl.WPF;
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

			myMap.CredentialsProvider = new ApplicationIdCredentialsProvider(new MapViewModel().BingMapsApiKey);
		}
	}
}
