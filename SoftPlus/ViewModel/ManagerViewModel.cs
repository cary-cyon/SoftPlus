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
    internal class ManagerViewModel : BaseViewModel
    {
        private Manager manager;
        private RelayCommand addCommand;
        private RelayCommand editCommand;
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
        public RelayCommand EditCommand
        {
            get
            {
                return editCommand ?? (editCommand = 
                    new RelayCommand(
                        obj => DataManager.EditData<Manager>(obj))
                    );
            }
        }
        public ManagerViewModel(Manager m = null)
        {
            if(m == null)
                SelectedManager = new Manager();
            else
                SelectedManager = m;
            Clients = SelectedManager.Clients;
        }
    }
}

