using SoftPlus.Interfaces;
using SoftPlus.Model;
using SoftPlus.ViewModel;
using System.ComponentModel;
using System.Windows;


namespace SoftPlus.View
{
    /// <summary>
    /// Логика взаимодействия для ClientEdit.xaml
    /// </summary>
    public partial class ClientEdit : Window, IView
    {
        public ClientEdit(object obj)
        {
            InitializeComponent();
            var c = obj as Client;
            DataContext = new ClientViewModel(c);
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
