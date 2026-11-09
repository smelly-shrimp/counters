using Counters.Models;

namespace Counters.Views;

[QueryProperty(nameof(MainModel), "MainModel")]
public partial class AddCounterPage : ContentPage
{
	public MainModel MainModel { get; set; }

	public AddCounterPage()
	{
		InitializeComponent();
		BindingContext = new Models.AddCounterModel();
	}

    private async void OnSubmitClicked(object sender, EventArgs e)
    {
		if (BindingContext is Models.AddCounterModel model)
		{
			MainModel.AddCounter(model.Name, model.Color, model.InitialValue);

			await Shell.Current.GoToAsync("..");
		}
    }
}