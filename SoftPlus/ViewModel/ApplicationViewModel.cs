using Microsoft.EntityFrameworkCore;
using SoftPlus.Command;
using SoftPlus.Data;
using SoftPlus.Interfaces;
using SoftPlus.Model;
using SoftPlus.View;
using System.Collections.Generic;
using System.Linq;


namespace SoftPlus.ViewModel
{
    internal class ApplicationViewModel : BaseViewModel
    {
        
        private Product selectedProduct;
        private Manager selectedManager;
        private Client selectedClient;
        
        private RelayCommand addCommand;
        private RelayCommand removeCommand;
        private RelayCommand editCommand;
        private RelayCommand addClientCommand;
        private RelayCommand removeClientCommmand;
        private RelayCommand editClientCommand;
        private RelayCommand addManagerCommand;
        private RelayCommand editManagerCommand;
        private RelayCommand removeMangerCommmand;
        private RelayCommand addClientProductCommand;
        private SoftPlusContext _dbContext;
        private List<Product> products;
        private List<Client> clients;
        private List<Manager> managers;
        private List<ClientStatus> clientStatuses;

        private static ApplicationViewModel _instance;

        public List<string> ProductTypeComboboxList { get; set; } = new List<string> { "Подписка", "Лицензия" };
        public List<string> SubscriptionPeriodComboboxList { get; set; } = new List<string> { "нет", "Месяц", "Квартал", "Год" };
        #region Commands
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj => OpenWindow(new ProductAdd())));
            }
        }
        public RelayCommand RemoveCommand
        {
            get
            {
                return removeCommand ?? (removeCommand = 
                    new RelayCommand(
                        async obj =>await DataManager.RemoveData<Product>(obj),
                        obj => DataManager.CanRemoveData(obj))
                    );
            }
        }
        public RelayCommand EditCommand
        {
            get
            {
                return editCommand ?? (editCommand = 
                    new RelayCommand(
                        obj => OpenWindow(new ProductEdit(obj)),
                        obj => DataManager.CanRemoveData(obj))
                    ); 
            }
        }
        public RelayCommand AddClientCommand
        {
            get 
            { 
                return addClientCommand ?? (addClientCommand =
                    new RelayCommand(obj => OpenWindow(new ClientAdd()))
                    );
            }
        }
        public RelayCommand RemoveClientCommаnd
        {
            get
            {
                return removeClientCommmand ?? (removeClientCommmand = 
                    new RelayCommand(
                        async obj => await DataManager.RemoveData<Client>(obj),
                        obj => DataManager.CanRemoveData(obj))
                    );
            }
        }
        public RelayCommand EditClientCommand
        {
            get
            {
                return editClientCommand ?? (editClientCommand =
                    new RelayCommand(
                        obj => OpenWindow(new ClientEdit(obj)),
                        obj => DataManager.CanRemoveData(obj))
                    );
            }
        }
        public RelayCommand AddManagerCommand
        {
            get
            {
                return addManagerCommand ?? (addManagerCommand =
                    new RelayCommand(obj => OpenWindow(new ManagerAdd())));
            }
        }
        public RelayCommand RemoveManagerCommand
        {
            get
            {
                return removeMangerCommmand ?? (removeMangerCommmand = 
                    new RelayCommand(
                        async obj => await DataManager.RemoveData<Manager>(obj),
                        obj => DataManager.CanRemoveData(obj))
                    );
            }
        }
        public RelayCommand EditManagerCommand
        {
            get
            {
                return editManagerCommand ?? (editManagerCommand =
                    new RelayCommand(
                        obj => OpenWindow(new ManagerEdit(obj)),
                        obj => DataManager.CanRemoveData(obj))
                        );
            }
        }
        public RelayCommand AddClientProductCommand
        {
            get
            {
                return addClientProductCommand ?? (addClientProductCommand =
                    new RelayCommand(
                        obj =>
                        {
                            OpenWindow(new ClientProductAdd());
                        }
                        ));
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
        private ApplicationViewModel()
        {
            _dbContext =new SoftPlusContext();

            Update();
            
        }
        public void OpenWindow(IView view)
        {
            view.Open();
        }

        public static ApplicationViewModel getInstance()
        {
            if (_instance == null)
                _instance = new ApplicationViewModel();
            return _instance;
        }
        public void Update()
        {
            Products = _dbContext.Products.Include(p => p.ClientProducts).ThenInclude(cp => cp.Client).ToList();
            Clients = _dbContext.Clients.Include(c => c.Status).Include(c => c.Manager).ToList();
            Managers = _dbContext.Managers.Include(m => m.Clients).ToList();
        }
    }
}
