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
    internal class ClientViewModel : INotifyPropertyChanged
    {
        private Client client;
        private RelayCommand addCommand;

        public List<string> ClientStatusesComboBoxList { get; set; } = new List<string>() { "Ключевой", "Обычный" };
        public List<Manager> ManagersComboboxList { get; set; }
        public RelayCommand AddCommand
        {
            get 
            {
                return addCommand ??(addCommand =
                  new RelayCommand(
                        obj => DataManager.AddData<Client>(obj))
                      ); 
            }
        }
        public Client SelectedClient
        {
            get { return client; }
            set { client = value;OnPropertyChanged("SelectedClient"); }
        }
        public ClientViewModel()
        {
            SelectedClient = new Client();
            var context = new SoftPlusContext();
            ManagersComboboxList = context.Managers.ToList();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
