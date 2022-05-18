using SoftPlus.Command;
using SoftPlus.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SoftPlus.ViewModel
{
    internal class ApplicationViewModel : INotifyPropertyChanged
    {
        
        private Product selectedProduct;
        private RelayCommand addCommand;
        private RelayCommand removeCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {
                      Product product = new Product() { TypeProduct = false, SubscriptionPeriod = null };
                      Products.Insert(0, product);
                      SelectedProduct = product;
                  }));
            }
        }
        public RelayCommand RemoveCommand
        {
            get
            {
                return removeCommand ?? (removeCommand = new RelayCommand(
                obj =>
                {
                    Products.Remove(SelectedProduct);
                },
                (obj) => 
                { 
                    return SelectedProduct != null; 
                }
                ));
            }
        }
        public ObservableCollection<Product> Products { get; set; }
        public Product SelectedProduct
        {
            get { return selectedProduct; }
            set { 
                selectedProduct = value; 
                OnPropertyChanged("SelectedProduct");
            }
        }
        public ApplicationViewModel()
        {
            Products = new ObservableCollection<Product>
            {
                new Product{ Name = "Win11Home", Price =200, TypeProduct = false},
                new Product{ Name ="Pycharm", Price = 100,  TypeProduct = true, SubscriptionPeriod = 30},
                new Product{ Name ="CharmPy", Price = 50,  TypeProduct = true, SubscriptionPeriod = 90},
                new Product{ Name ="PhotoVlad", Price = 90,  TypeProduct = true, SubscriptionPeriod = 361}
            };
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
