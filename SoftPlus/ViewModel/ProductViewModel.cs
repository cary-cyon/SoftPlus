using Microsoft.EntityFrameworkCore;
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
using System.Windows.Data;

namespace SoftPlus.ViewModel
{
    internal class ProductViewModel : BaseViewModel
    {
        private Product _product;
        private SoftPlusContext _dbContext;
        private RelayCommand addCommand;
        private RelayCommand editCommand;
        public List<string> ProductTypeComboboxList { get; set; } = new List<string> { "Подписка", "Лицензия" };
        public List<string> SubscriptionPeriodComboboxList { get; set; } = new List<string> { "нет", "Месяц", "Квартал", "Год" };
        public ProductViewModel(Product p=null)
        {
            _dbContext = new SoftPlusContext();
            if(p == null)
                SelectedProduct = new Product();
            else
                SelectedProduct = p;
        }
        public RelayCommand AddCommand
        {
            get 
            { 
                return addCommand ?? (addCommand =
                    new RelayCommand(
                        obj => DataManager.AddData<Product>(obj),
                        obj => Validator.ValidateProduct(obj))
                    ); 
            } 
        }
        public RelayCommand EditCommand
        {
            get
            {
                return editCommand ?? (editCommand =
                    new RelayCommand(
                            obj => DataManager.EditData<Product>(obj),
                            obj => Validator.ValidateProduct(obj))
                        );
            }
        }
        public Product SelectedProduct { get { return _product; } set { _product = value; OnPropertyChanged("SelectedProduct"); } }
    }
}
