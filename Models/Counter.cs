using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Counters.Models
{
    public class Counter : INotifyPropertyChanged
    {
        public string Name { get; set; } = string.Empty;
        public int Value
        {
            get => _value;
            set
            {
                _value = value;
                NotifyPropertyChanged();
            }
        }
        public int InitialValue { get; set; }
        public string Color { get; set; } = "Red";

        private int _value = 0;

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public string IncrementButtonLabel => "Increment";
        public string DecrementButtonLabel => "Decrement";
        public string ResetButtonLabel => "Reset";
        public string DeleteButtonLabel => "Delete";
        public Microsoft.Maui.Graphics.Color BackgroundColor
        {
            get
            {
                return Color switch
                {
                    "Red" => Colors.Red,
                    "Blue" => Colors.Blue,
                    "Green" => Colors.Green,
                    _ => Colors.White,
                };
            }
        }
    }
}
