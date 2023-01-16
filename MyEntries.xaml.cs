using Mirea_Andreea_Proiect.Models;

namespace Mirea_Andreea_Proiect;

public partial class MyEntries : ContentPage
{
	public MyEntries()
	{
		InitializeComponent();
	}
protected override async void OnAppearing()
	{
		base.OnAppearing();
		listView.ItemsSource = await App.Database.GetSecretListsAsync();
	}
	async void OnSecretListAddedClicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new Entry
		{
			BindingContext = new SecretList()
		});
	}
	async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
	{
		if (e.SelectedItem != null)
		{
			await Navigation.PushAsync(new Entry
			{
				BindingContext = e.SelectedItem as SecretList
			});
		}
	}

}