using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SoftPlus.Model
{
    internal class Client : INotifyPropertyChanged
    {
        private string name;
        private Manager manager;
        private ClientStatus status;
        private List<Product> products;
        public string Name { 
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }        
        }
        public Manager Manager
        {
            get { return manager; }
            set { manager = value; OnPropertyChanged("Manager"); }
        }
        public ClientStatus Status
        {
            get { return status; }
            set { status = value; OnPropertyChanged("Status"); }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }

}
