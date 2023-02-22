namespace Mirea_Andreea_Proiect;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"there are {count} stars in the sky";
		else
			CounterBtn.Text = $"there are {count} stars in the sky";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}
}

