﻿using System.ComponentModel;
using System.Windows;
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
