using System;
using System.Windows.Input;
using TrelloApp.Models;
using Xamarin.Forms;

namespace TrelloApp.ViewModels
{
	public class ItemDetailViewModel : BaseViewModel
	{
		public Item Item { get; set; }

		public ItemDetailViewModel(Item item = null)
		{

			Title = item?.Text;
			Item = item;
		}


	}
}
