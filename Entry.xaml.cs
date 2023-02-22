using Mirea_Andreea_Proiect.Models;

namespace Mirea_Andreea_Proiect;

public partial class Entry : ContentPage
{
	public Entry()
	{
		InitializeComponent();
	}

	async void OnSaveButtonClicked(object sender, EventArgs e)
	{
		var slist = (SignList)BindingContext;
		slist.Date = DateTime.UtcNow;
		await App.Database.SaveSignListAsync(slist);
		await Navigation.PopAsync();
	}

    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (SignList)BindingContext;
        await App.Database.DeleteSecretListAsync(slist);
        await Navigation.PopAsync();
    }

	async void OnChooseButtonClicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new SignPage((SignList)this.BindingContext)
			{
			BindingContext = new Sign()
		});
	}
	protected override async void OnAppearing()
	{
		base.OnAppearing();
		var signl = (SignList)BindingContext;
		listView.ItemsSource = await App.Database.GetListSignsAsync(signl.ID);
	}
}