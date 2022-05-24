using SoftPlus.Command;
using SoftPlus.Data;
using SoftPlus.Model;
using System.Collections.Generic;
using System.Linq;

namespace SoftPlus.ViewModel
{
    internal class ClientProductViewModel : BaseViewModel
    {
        private Product product;
        private Client client;
        private ClientProduct clientProduct;
        private RelayCommand addClientProductCommand;
        private SoftPlusContext context;
        public List<Client> Clients { get; set; }
        public List<Product> Products { get; set; }
        public ClientProductViewModel()
        {
            context = new SoftPlusContext();
            SelectedClientProduct = new ClientProduct();
            Clients = context.Clients.ToList();
            Products = context.Products.ToList();
        }
        public Product SelectedProduct
        {
            get { return product; }
            set { product = value; SelectedClientProduct.Product = value; OnPropertyChanged("SelectedProduct");}
        }
        public Client SelectedClient
        {
            
            get { return client; }
            set { client = value; SelectedClientProduct.Client = value; OnPropertyChanged("SelectedClient");}
        }
        public ClientProduct SelectedClientProduct
        {
            get { return clientProduct; }
            set { clientProduct = value; OnPropertyChanged("SelectedClientProduct"); }
        }
        public RelayCommand AddClientProductCommand
        {
            get
            {
                return addClientProductCommand?? (addClientProductCommand = 
                    new RelayCommand(
                            obj=>
                            {
                                context.ClientProducts.Add(obj as ClientProduct);
                                context.SaveChanges();
                                ApplicationViewModel.getInstance().Update();
                            },
                            obj =>
                            {
                                var cp = obj as ClientProduct;
                                return cp != null && cp.Client != null && cp.Product != null;
                            }
                        ));
            }
        }

    }
}
