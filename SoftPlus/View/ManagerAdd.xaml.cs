using SoftPlus.Interfaces;
using SoftPlus.ViewModel;
using System.ComponentModel;
using System.Windows;

namespace SoftPlus.View
{
    /// <summary>
    /// Логика взаимодействия для ManagerAdd.xaml
    /// </summary>
    public partial class ManagerAdd : Window, IView
    {
        public ManagerAdd()
        {
            InitializeComponent();
            DataContext = new ManagerViewModel();
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
