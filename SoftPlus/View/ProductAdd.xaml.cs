using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using SoftPlus.Interfaces;
using SoftPlus.ViewModel;

namespace SoftPlus.View
{
    /// <summary>
    /// Логика взаимодействия для ProductAdd.xaml
    /// </summary>
    public partial class ProductAdd : Window, IView
    {
        public ProductAdd()
        {
            InitializeComponent();

            DataContext =new ProductViewModel();
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
