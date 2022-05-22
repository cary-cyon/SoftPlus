using SoftPlus.Interfaces;
using System.ComponentModel;
using System.Windows;
using SoftPlus.ViewModel;

namespace SoftPlus.View
{
    /// <summary>
    /// Логика взаимодействия для ClientAdd.xaml
    /// </summary>
    public partial class ClientAdd : Window, IView
    {
        public ClientAdd()
        {
            InitializeComponent();
            DataContext = new ClientViewModel();
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
