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
    internal class ProductViewModel : INotifyPropertyChanged
    {
        private Product _product;
        private SoftPlusContext _dbContext;
        private RelayCommand addCommand;
        public List<string> ProductTypeComboboxList { get; set; } = new List<string> { "Подписка", "Лицензия" };
        public List<string> SubscriptionPeriodComboboxList { get; set; } = new List<string> { "нет", "Месяц", "Квартал", "Год" };
        public ProductViewModel()
        {
            _dbContext = new SoftPlusContext();
            SelectedProduct = new Product();
        }
        public RelayCommand AddCommand
        {
            get { return addCommand ?? (addCommand = new RelayCommand(obj => DataManager.AddData<Product>(obj))); } 
        }
        public Product SelectedProduct { get { return _product; } set { _product = value; OnPropertyChanged("SelectedProduct"); } }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
