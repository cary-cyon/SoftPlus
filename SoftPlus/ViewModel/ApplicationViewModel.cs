using Microsoft.EntityFrameworkCore;
using SoftPlus.Command;
using SoftPlus.Data;
using SoftPlus.Interfaces;
using SoftPlus.Model;
using SoftPlus.View;
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
        private RelayCommand addClientCommand;
        private RelayCommand removeClientCommmand;
        private RelayCommand addManagerCommand;
        private RelayCommand removeMangerCommmand;

        private SoftPlusContext _dbContext;
        private List<Product> products;
        private List<Client> clients;
        private List<Manager> managers;
        private List<ClientStatus> clientStatuses;

        private static ApplicationViewModel _instance;

        IView view;

        public List<string> ProductTypeComboboxList { get; set; } = new List<string> { "Подписка", "Лицензия" };
        public List<string> SubscriptionPeriodComboboxList { get; set; } = new List<string> { "нет", "Месяц", "Квартал", "Год" };
        #region Commands
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj => OpenWindowProduct()));
            }
        }
        public RelayCommand RemoveCommand
        {
            get
            {
                return removeCommand ?? (removeCommand = 
                    new RelayCommand(
                        obj => DataManager.RemoveData<Product>(obj),
                        obj => DataManager.CanRemoveData(obj))
                    );
            }
        }
        public RelayCommand EditCommand
        {
            get
            {
                return editCommand ?? (editCommand = new RelayCommand(obj => DataManager.EditDataProduct(obj))); 
            }
        }
        public RelayCommand AddClientCommand
        {
            get 
            { 
                return addClientCommand ?? (addClientCommand = 
                    new RelayCommand(
                        obj => DataManager.AddData<Client>(obj))
                    );
            }
        }
        public RelayCommand RemoveClientCommаnd
        {
            get
            {
                return removeClientCommmand ?? (removeClientCommmand = 
                    new RelayCommand(
                        obj => DataManager.RemoveData<Client>(obj),
                        obj => DataManager.CanRemoveData(obj))
                    );
            }
        }
        public RelayCommand AddManagerCommand
        {
            get
            {
                return addManagerCommand ?? (addManagerCommand = 
                    new RelayCommand(
                        obj => DataManager.AddData<Manager>(obj))
                    );
            }
        }
        public RelayCommand RemoveManagerCommand
        {
            get
            {
                return removeMangerCommmand ?? (removeMangerCommmand = 
                    new RelayCommand(
                        obj => DataManager.RemoveData<Manager>(obj),
                        obj => DataManager.CanRemoveData(obj))
                    );
            }
        }
        #endregion
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
        #region Select
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
        #endregion
        #region Lists
        public List<Client> Clients
        {
            get { return clients; }
            set { clients = value; OnPropertyChanged("Clients"); }
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
        #endregion
        private ApplicationViewModel(IView view)
        {
            _dbContext =new SoftPlusContext();
            this.view = view;
            Update();
            
        }
        public void OpenWindowProduct()
        {
            view.Open();
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
                _instance = new ApplicationViewModel(new ProductAdd());
            return _instance;
        }
        public void Update()
        {
            Products = _dbContext.Products.Include(p => p.ClientProducts).ThenInclude(cp => cp.Client).ToList();
            Clients = _dbContext.Clients.Include(c => c.Status).Include(c => c.Manager).ToList();
            Managers = _dbContext.Managers.ToList();
        }
    }
}
