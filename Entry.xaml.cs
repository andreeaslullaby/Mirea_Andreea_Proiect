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
		var slist = (SecretList)BindingContext;
		slist.Date = DateTime.UtcNow;
		await App.Database.SaveSecretListAsync(slist);
		await Navigation.PopAsync();
	}

    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (SecretList)BindingContext;
        await App.Database.DeleteSecretListAsync(slist);
        await Navigation.PopAsync();
    }
}