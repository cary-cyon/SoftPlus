using SoftPlus.Interfaces;
using SoftPlus.ViewModel;
using System.ComponentModel;
using System.Windows;


namespace SoftPlus.View
{
    /// <summary>
    /// Логика взаимодействия для ClientProductAdd.xaml
    /// </summary>
    public partial class ClientProductAdd : Window, IView
    {
        public ClientProductAdd()
        {
            InitializeComponent();
            DataContext =new ClientProductViewModel();
        }
        public bool? Open()
        {
            return this.ShowDialog();
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
            e.Cancel = true;

        }
    }
}
