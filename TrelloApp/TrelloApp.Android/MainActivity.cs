using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Speech;

namespace TrelloApp.Droid
{
    [Activity(Label = "TrelloApp", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity, ISpeechRecorder
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App(this));
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public void StartRecording()
        {
	        var voiceIntent = new Intent(RecognizerIntent.ActionRecognizeSpeech);
	        voiceIntent.PutExtra(RecognizerIntent.ExtraLanguageModel, RecognizerIntent.LanguageModelFreeForm);

	        // put a message on the modal dialog
	        voiceIntent.PutExtra(RecognizerIntent.ExtraPrompt, "Jetzt Sprechen");

	        // if there is more then 1.5s of silence, consider the speech over
	        voiceIntent.PutExtra(RecognizerIntent.ExtraSpeechInputCompleteSilenceLengthMillis, 1500);
	        voiceIntent.PutExtra(RecognizerIntent.ExtraSpeechInputPossiblyCompleteSilenceLengthMillis, 1500);
	        voiceIntent.PutExtra(RecognizerIntent.ExtraSpeechInputMinimumLengthMillis, 15000);
	        voiceIntent.PutExtra(RecognizerIntent.ExtraMaxResults, 1);

	        // you can specify other languages recognised here, for example
	        // voiceIntent.PutExtra(RecognizerIntent.ExtraLanguage, Java.Util.Locale.German);
	        // if you wish it to recognise the default Locale language and German
	        // if you do use another locale, regional dialects may not be recognised very well

	        voiceIntent.PutExtra(RecognizerIntent.ExtraLanguage, Java.Util.Locale.Default);
	        StartActivityForResult(voiceIntent,10);
        }

        public string EndRecording()
        {
			FinishActivity(10);
	        return Text;
        }

        private string Text = "";

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
	        base.OnActivityResult(requestCode, resultCode, data);
	        if (requestCode == 10)
	        {
		        if (resultCode == Result.Ok)
		        {
					
			        var matches = data.GetStringArrayListExtra(RecognizerIntent.ExtraResults);
			        if (matches.Count != 0)
			        {
				        string textInput = matches[0];

				        // limit the output to 500 characters
				        if (textInput.Length > 500)
				        {
					        textInput = textInput.Substring(0, 500);
				        }

				        Text = textInput;
			        }
			        else
			        {
				        Text = "No speech was recognised";
			        }

			        // change the text back on the button
					Text = "Start Recording";
		        }
		        else
		        {
			        Text = ":(";
				}
	        }

	        base.OnActivityResult(requestCode, resultCode, data);
        }
    }
}