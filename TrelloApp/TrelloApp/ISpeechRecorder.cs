using System;
using System.Collections.Generic;
using System.Text;

namespace TrelloApp
{
	public interface ISpeechRecorder
	{
		void StartRecording();
		string EndRecording();
	}
}
