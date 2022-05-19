using SoftPlus.Command;
using SoftPlus.Data;
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
        private RelayCommand editCommand;
        private SoftPlusContext _dbContext;
        private List<Product> products;
        private static ApplicationViewModel _instance;



        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj => DataManager.AddDataProduct(obj)));
            }
        }
        public RelayCommand RemoveCommand
        {
            get
            {
                return removeCommand ?? (removeCommand = new RelayCommand(obj => DataManager.RemoveDataProduct(obj)));
            }
        }
        public RelayCommand EditCommand
        {
            get
            {
                return editCommand ?? (editCommand = new RelayCommand(obj => DataManager.EditDataProduct(obj))); 
            }
        }
        public List<Product> Products
        {
            get
            {
                return products;
            }
            set 
            {
                products = value;
                OnPropertyChanged("Products");

            } 
        }
        public Product SelectedProduct
        {
            get { return selectedProduct; }
            set
            {
                selectedProduct = value;
                OnPropertyChanged("SelectedProduct");
            }
        }
        private ApplicationViewModel()
        {
            _dbContext =new SoftPlusContext();
            Products = _dbContext.Products.ToList();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        public static ApplicationViewModel getInstance()
        {
            if (_instance == null)
                _instance = new ApplicationViewModel();
            return _instance;
        }
        public void Update()
        {
            Products = _dbContext.Products.ToList();
        }
    }
}
