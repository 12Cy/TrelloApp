using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TrelloApp.ViewModels;
using Xamarin.Forms;

namespace GUI
{
	public class NewItemModel : BaseViewModel
	{
		public ICommand ButtonSpeech { get; set; }
		public string SpeechText { get; set; }

		public NewItemModel()
		{
			ButtonSpeech = new Command(OnButtonSpeech);
		}

		public void OnButtonSpeech()
		{
			//Spracheingabe Aktivieren
			System.Console.WriteLine("ButtonPressed");
		}

		public void Released()
		{
			var result = RecorderSingleton.GetInstance().SpeechRecorder.EndRecording();
			SpeechText = result;
			OnPropertyChanged(nameof(SpeechText));
		}

		public void Clicked()
		{
			RecorderSingleton.GetInstance().SpeechRecorder.StartRecording();
		}
	}
}
