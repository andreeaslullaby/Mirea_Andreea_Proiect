using Mirea_Andreea_Proiect.Models;
using System.Diagnostics.Tracing;

namespace Mirea_Andreea_Proiect;

public partial class SignPage : ContentPage
{
	SignList sl;
	public SignPage(SignList slist)
	{
		InitializeComponent();
		sl = slist;
	}

	async void OnSaveButtonClicked(object sender, EventArgs e)
	{
		var sign = (Sign)BindingContext;
		await App.Database.SaveSignAsync(sign);
		listView.ItemsSource = await App.Database.GetSignsAsync();
	}
	async void OnDeleteButtonClicked(object sender, EventArgs e)
	{
		var sign = (Sign)BindingContext;
		await App.Database.DeleteSignAsync(sign);
		listView.ItemsSource = await App.Database.GetSignsAsync();
	}
	protected override async void OnAppearing()
	{
		base.OnAppearing();
		listView.ItemsSource = await App.Database.GetSignsAsync();
	}

	async void OnAddButtonClicked(object sender, EventArgs e)
	{
		Sign s;
		if (listView.SelectedItem != null)
		{
			s = listView.SelectedItem as Sign;
			var ls = new ListSign()
			{
				SignListID = sl.ID,
				SignID = s.ID
			};
			await App.Database.SaveListSignAsync(ls);
			s.ListSign = new List<ListSign> { ls };

			await Navigation.PopAsync();
		}
	}
}