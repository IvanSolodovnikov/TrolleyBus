using System.ComponentModel;
using System.Reflection;
using System.Windows.Threading;
using TrolleybusApp.Models;

namespace TrolleybusApp.ViewModels
{
    public class TrolleybusViewModel : INotifyPropertyChanged
    {
        public Trolleybus Model { get; }

        private string _status = "Готов";
        public string Status
        {
            get => _status;
            set { _status = value; OnPropertyChanged(nameof(Status)); }
        }

        private double _position;
        public double Position
        {
            get => _position;
            set { _position = value; OnPropertyChanged(nameof(Position)); }
        }

        private readonly Driver _driver = new Driver();
        private readonly IRepairService _service = new RepairService();

        public TrolleybusViewModel()
        {
            Model = new Trolleybus();

            Model.OnStateChanged += s => Status = s;

            Model.OnBroken += async () =>
            {
                Status = "Аварийка едет...";
                await _service.Repair(Model);
                Model.Continue();
            };

            Model.OnPoleOff += async () =>
            {
                Status = "Водитель чинит...";
                await _driver.FixPoles(Model);
                Model.Continue();
            };

            var timer = new DispatcherTimer();
            timer.Interval = System.TimeSpan.FromMilliseconds(200);
            timer.Tick += (s, e) =>
            {
                var prop = typeof(Trolleybus).GetProperty("Position", BindingFlags.Public | BindingFlags.Instance);
                Position = (double)prop!.GetValue(Model)!;
            };
            timer.Start();
        }

        public void Start() => Model.Start();

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string name)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}