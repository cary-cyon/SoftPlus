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
    public partial class ManagerEdit : Window, IView
    {
        public ManagerEdit(object obj)
        {
            InitializeComponent();
            var m = obj as Manager;
            DataContext = new ManagerViewModel(m);
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