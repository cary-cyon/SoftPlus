using SoftPlus.ViewModel;
using System.Windows;


namespace SoftPlus
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            DataContext = ApplicationViewModel.getInstance();
        }
    }
}
