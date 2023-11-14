﻿using ChicagoTrainTracker.ViewModel;
using System.Windows;

namespace ChicagoTrainTracker
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			MainWindow = new MainWindow()
			{
				DataContext = new MainWindowViewModel()
			};

			MainWindow.Show();

			base.OnStartup(e);
		}
	}
}
