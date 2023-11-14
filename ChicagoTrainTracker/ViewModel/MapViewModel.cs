using Microsoft.Maps.MapControl.WPF;
using System.Collections.ObjectModel;
using System.Windows.Media;
using ConfigurationManager = System.Configuration.ConfigurationManager;

namespace ChicagoTrainTracker.ViewModel
{
	public class MapViewModel : ViewModelBase
	{
		private ObservableCollection<Pushpin> _pushpins;

		public ObservableCollection<Pushpin> Pushpins
		{
			get => _pushpins;
			set
			{
				_pushpins = value;
				OnPropertyChanged(nameof(Pushpins));
			}
		}
		
		public ApplicationIdCredentialsProvider BingMapsApiKey { get; }

		public MapViewModel()
		{
			BingMapsApiKey = new ApplicationIdCredentialsProvider( ConfigurationManager.AppSettings["BingMapsApiKey"]);

			Pushpins = new ObservableCollection<Pushpin>();
			AddPushPin(new Location(41.857908, -87.669147));
			AddPushPin(new Location(41.829353, -87.680622));
		}

		private void AddPushPin(Location location)
		{
			Pushpin pushpin = new Pushpin();

			pushpin.Location = location;
			pushpin.ToolTip = "18th Street";
			pushpin.Background = new SolidColorBrush(Colors.Pink);

			Pushpins.Add(pushpin);
		}
	}
}
