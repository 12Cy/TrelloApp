using System;
using GUI;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TrelloApp.Services;
using TrelloApp.Views;

namespace TrelloApp
{
	public partial class App : Application
	{

		public App(ISpeechRecorder recorder)
		{
			RecorderSingleton.RegisterInstance(recorder);
			InitializeComponent();

			DependencyService.Register<TrelloDataStore>();
			MainPage = new MainPage();
		}

		protected override void OnStart()
		{
		}

		protected override void OnSleep()
		{
		}

		protected override void OnResume()
		{
		}
	}
}
