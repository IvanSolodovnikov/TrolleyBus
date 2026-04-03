using System.Collections.ObjectModel;

namespace TrolleybusApp.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<TrolleybusViewModel> Items { get; }
            = new ObservableCollection<TrolleybusViewModel>();

        public void Add()
        {
            var tb = new TrolleybusViewModel();
            Items.Add(tb);
            tb.Start();
        }
    }
}