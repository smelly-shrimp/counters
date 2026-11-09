namespace Counters.Models
{
    public class AddCounterModel
    {
        public string Name { get; set; } = "";
        public int InitialValue { get; set; } = 0;
        public string Color { get; set; } = "Red";


        public string Title => "Add a new counter";
        public string NameLabel => "Name";
        public string InitialValueLabel => "Initial value";
        public string ColorLabel => "Color";
        public string SubmitLabel => "Submit data";

        public string[] AvailableColors => ["Red", "Blue", "Green"];
    }
}
