using SoftPlus.Command;
using SoftPlus.Data;
using SoftPlus.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SoftPlus.ViewModel
{
    internal class ClientViewModel : BaseViewModel
    {
        private Client client;
        private RelayCommand addCommand;
        private RelayCommand editCommand;

        public List<string> ClientStatusesComboBoxList { get; set; } = new List<string>() { "Ключевой", "Обычный" };
        public List<Manager> ManagersComboboxList { get; set; }
        public List<Product> ProductsComboboxList { get; set; }
        public Product ProductComboboxListSelect{get; set;} 
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ?? (addCommand =
                  new RelayCommand(
                        obj => {
                            var c = obj as Client;
                            DataManager.AddData<Client>(c);
                        },
                        obj => Validator.ValideteClient(obj))
                      ); 
            }
        }
        public RelayCommand EditCommand
        {
            get
            {
                return editCommand ?? (editCommand =
                  new RelayCommand(
                      obj => DataManager.EditData<Client>(obj),
                      obj => Validator.ValideteClient(obj))
                  );
            }
        }
        public Client SelectedClient
        {
            get { return client; }
            set { client = value;OnPropertyChanged("SelectedClient"); }
        }
        public ClientViewModel(Client c = null)
        {
            if(c == null)
                SelectedClient = new Client();
            else
                SelectedClient = c;
            var context = new SoftPlusContext();
            ManagersComboboxList = context.Managers.ToList();
            ProductsComboboxList = context.Products.ToList();
        }
    }
}
