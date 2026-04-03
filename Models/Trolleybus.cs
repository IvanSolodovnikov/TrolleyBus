using System;
using System.Threading.Tasks;

namespace TrolleybusApp.Models
{
    public class Trolleybus
    {
        private readonly Random _rnd = new Random();

        public double Position { get; private set; }
        public double Speed { get; private set; }
        public bool IsRunning { get; private set; }

        public event Action<string>? OnStateChanged;
        public event Action? OnBroken;
        public event Action? OnPoleOff;

        public async void Start()
        {
            IsRunning = true;
            Speed = 2;

            while (IsRunning)
            {
                await Task.Delay(500);

                Position += Speed;
                OnStateChanged?.Invoke($"Едет: {Math.Round(Position,1)}");

                if (_rnd.NextDouble() < 0.01)
                {
                    IsRunning = false;
                    OnBroken?.Invoke();
                    OnStateChanged?.Invoke("Сломался");
                }
                else if (_rnd.NextDouble() < 0.05)
                {
                    IsRunning = false;
                    OnPoleOff?.Invoke();
                    OnStateChanged?.Invoke("Слетели штанги");
                }
            }
        }

        public void Fix()
        {
            Speed = 0;
            OnStateChanged?.Invoke("Починен");
        }

        public void Continue() => Start();
    }
}