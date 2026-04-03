using System.Windows;
using TrolleybusApp.ViewModels;

namespace TrolleybusApp.Views
{
    public partial class MainWindow : Window
    {
        private MainViewModel _vm;

        public MainWindow()
        {
            InitializeComponent();
            _vm = new MainViewModel();
            DataContext = _vm;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            _vm.Add();
        }
    }
}