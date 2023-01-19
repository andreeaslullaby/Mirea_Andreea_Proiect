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
			CounterBtn.Text = $"you have {count} things on your mind";
		else
			CounterBtn.Text = $"you have {count} things on your mind";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}
}

