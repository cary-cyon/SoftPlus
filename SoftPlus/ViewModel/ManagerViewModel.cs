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
    internal class ManagerViewModel : INotifyPropertyChanged
    {
        private Manager manager;
        private RelayCommand addCommand;
        public List<Client> Clients { get; set; }
        public RelayCommand AddCommand
        {
            get { return addCommand ?? (addCommand = new RelayCommand(obj => DataManager.AddData<Manager>(obj))); }
        }
        public Manager SelectedManager
        {
            get { return manager; }
            set { manager = value; OnPropertyChanged("SelectedManager"); }
        
        }
        public ManagerViewModel()
        {
            SelectedManager = new Manager();
            Clients = SelectedManager.Clients;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}

