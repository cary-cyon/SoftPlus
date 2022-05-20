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
    internal class ApplicationViewModel : INotifyPropertyChanged
    {
        
        private Product selectedProduct;
        private Manager selectedManager;
        private Client selectedClient;
        
        private RelayCommand addCommand;
        private RelayCommand removeCommand;
        private RelayCommand editCommand;
        private SoftPlusContext _dbContext;
        private List<Product> products;
        private List<Client> clients;
        private List<Manager> managers;
        private List<ClientStatus> clientStatuses;

        private static ApplicationViewModel _instance;


        public List<string> ProductTypeComboboxList { get; set; } = new List<string> { "Подписка", "Лицензия" };
        public List<string> SubscriptionPeriodComboboxList { get; set; } = new List<string> { "нет", "Месяц", "Квартал", "Год" };
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
        public List<Client> Clients
        {
            get { return clients; }
            set { clients = value; OnPropertyChanged("Clients"); }
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
        public Manager SelectedManager
        {
            get { return selectedManager; }
            set { selectedManager = value; OnPropertyChanged("SelectedManager"); }
        }
        public Client SelectedClient
        {
            get { return selectedClient; }
            set { selectedClient = value; OnPropertyChanged("SelectedClient"); }
        }
        public List<ClientStatus> ClientStatuses
        {
            get { return clientStatuses; }
            set { clientStatuses = value; OnPropertyChanged("ClientStatuses"); }
        }
        public List<Manager> Managers
        {
            get { return managers; }
            set { managers = value; OnPropertyChanged("Managers"); }
        }
        private ApplicationViewModel()
        {
            _dbContext =new SoftPlusContext();
            Products = _dbContext.Products.Include(p => p.ClientProducts).ThenInclude(cp => cp.Client).ToList();
            Clients = _dbContext.Clients.Include(c => c.Status).Include(c => c.Manager).ToList();
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
