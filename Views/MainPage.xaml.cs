namespace Counters.Views;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
		BindingContext = new Models.MainModel();
	}

    protected override void OnAppearing()
    {
        ((Models.MainModel)BindingContext).LoadCounters();
    }

    private async void OnAddCounterClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(AddCounterPage), new Dictionary<string, object>
        {
            { "MainModel", BindingContext }
        });
    }

    private void OnCounterValueChange(object sender, EventArgs e)
    {
        if (BindingContext is Models.MainModel model)
        {
            model.SaveCounter();
        }
    }

    private void OnCounterDeleteClicked(object sender, EventArgs e)
    {
        if (
            BindingContext is Models.MainModel model
            && sender is Components.Counter counterView
            && counterView.BindingContext is Models.Counter counter)
        {
            model.DeleteCounter(counter);
        }
    }
}