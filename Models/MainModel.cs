using System.Collections.ObjectModel;
using System.Xml.Linq;

namespace Counters.Models
{
    public class MainModel
    {
        public ObservableCollection<Counter> Counters { get; } = [];

        public void LoadCounters()
        {
            Counters.Clear();

            if (!File.Exists(_filePath))
                return;

            var doc = XDocument.Load(_filePath);

            foreach (var el in doc.Root!.Elements("counter"))
            {
                Counters.Add(new Counter()
                {
                    Name = el.Element("name")!.Value,
                    Color = el.Element("color")!.Value,
                    InitialValue = int.Parse(el.Element("initial-value")!.Value),
                    Value = int.Parse(el.Element("value")!.Value),
                });
            }
        }

        public void AddCounter(string name, string color, int initialValue)
        {
            Counters.Add(new Models.Counter()
            {
                Name = name.Trim(),
                Color = color,
                InitialValue = initialValue,
                Value = initialValue,
            });

            SaveCounter();
        }

        public void SaveCounter()
        {
            XDocument doc = new(
                new XElement("counters",
                    Counters.Select(counter => new XElement("counter",
                        new XElement("name", counter.Name),
                        new XElement("color", counter.Color),
                        new XElement("initial-value", counter.InitialValue),
                        new XElement("value", counter.Value)))));

            doc.Save(_filePath);
        }

        public void DeleteCounter(Counter counter)
        {
            Counters.Remove(counter);
            SaveCounter();
        }

        private static readonly string _filePath = Path.Combine(FileSystem.AppDataDirectory, "counters.xml");


        public string Title => "Counters";
        public string AddCounterLabel => "Add new counter";
        public string NoCountersLabel => "No counters. To add one, click the button above.";
    }
}
