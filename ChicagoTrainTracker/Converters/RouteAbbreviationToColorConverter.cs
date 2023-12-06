using System;
using System.Globalization;
using System.Windows.Data;

namespace ChicagoTrainTracker.Converters
{
	public class RouteAbbreviationToColorConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is string routeAbbreviation)
			{
				switch (routeAbbreviation)
				{
					case "Brn":
						return "Brown";
					case "G":
						return "Green";
					case "Org":
						return "Orange";
					case "P":
						return "Purple";
					case "Y":
						return "Yellow";

				}
			}
			return value;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
