﻿using ChicagoTrainTracker.ViewModel;
using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


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
