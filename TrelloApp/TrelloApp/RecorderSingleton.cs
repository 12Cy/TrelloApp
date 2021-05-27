using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TrelloApp;

namespace GUI
{
	public class RecorderSingleton
	{

		private static RecorderSingleton _instance;
		public ISpeechRecorder SpeechRecorder;

		private RecorderSingleton(ISpeechRecorder recorder)
		{
			SpeechRecorder = recorder;
		}

		public static RecorderSingleton GetInstance()
		{
			return _instance;
		}

		public static void RegisterInstance(ISpeechRecorder recorder)
		{
			if(_instance == null)
			{
				_instance = new RecorderSingleton(recorder);
			}
		}
	}
}
