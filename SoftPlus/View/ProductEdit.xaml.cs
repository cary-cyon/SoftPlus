using SoftPlus.Interfaces;
using SoftPlus.Model;
using SoftPlus.ViewModel;
using System.ComponentModel;
using System.Windows;


namespace SoftPlus.View
{
    /// <summary>
    /// Логика взаимодействия для ProductEdit.xaml
    /// </summary>
    public partial class ProductEdit : Window, IView
    {
        public ProductEdit(object obj)
        {
            InitializeComponent();
            var p = obj as Product;
            DataContext =new ProductViewModel(p);
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
