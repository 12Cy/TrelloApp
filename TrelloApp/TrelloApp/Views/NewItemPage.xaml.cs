using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Speech.Recognition;
using System.Threading;
using GUI;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TrelloApp.Models;
using TrelloApp.ViewModels;
using Xamarin.Forms.PlatformConfiguration;

namespace TrelloApp.Views
{
	// Learn more about making custom code visible in the Xamarin.Forms previewer
	// by visiting https://aka.ms/xamarinforms-previewer
	[DesignTimeVisible(false)]
	public partial class NewItemPage : ContentPage
	{
		public Item Item { get; set; }
		NewItemModel viewModel;

		public NewItemPage(NewItemModel viewModel)
		{
			InitializeComponent();

			Item = new Item
			{
				Text = "Item name",
				Description = "This is an item description."
			};
			BindingContext = this.viewModel = viewModel;
		}

		async void Save_Clicked(object sender, EventArgs e)
		{
			MessagingCenter.Send(this, "AddItem", Item);
			await Navigation.PopModalAsync();
		}

		async void Cancel_Clicked(object sender, EventArgs e)
		{
			await Navigation.PopModalAsync();
		}

		private void Button_OnClicked(object sender, EventArgs e)
		{
			viewModel.Clicked();
		}

		private void Button_OnReleased(object sender, EventArgs e)
		{
			viewModel.Released();
			
		}

		

	}
}