using System.Windows;
using Beridze_2.ViewModels;

namespace Beridze_2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new PersonViewModel();
        }
    }
}