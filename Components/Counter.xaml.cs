namespace Counters.Components;

public partial class Counter : ContentView
{
    public event EventHandler ValueChanged;
    public event EventHandler DeleteClicked;

    public Counter()
	{
		InitializeComponent();
        BindingContext = new Models.Counter();
    }

    private void OnIncrementClicked(object sender, EventArgs e)
    {
        ChangeValue(counter => counter.Value += 1);
    }

    private void OnDecrementClick(object sender, EventArgs e)
    {
        ChangeValue(counter => counter.Value -= 1);
    }

    private void OnResetClicked(object sender, EventArgs e)
    {
        ChangeValue(counter => counter.Value = counter.InitialValue);
    }

    private void OnDeleteClick(object sender, EventArgs e)
        => DeleteClicked?.Invoke(this, e);

    private void ChangeValue(Action<Models.Counter> changeFn)
    {
        if (BindingContext is Models.Counter counter)
        {
            changeFn(counter);
            ValueChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}