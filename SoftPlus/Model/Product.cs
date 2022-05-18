using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SoftPlus.Model
{
    internal class Product : INotifyPropertyChanged
    {
        private string name;
        private int price;
        private bool typeProduct;
        private int? subscriptionPeriod;

        public string Name
        {
            get { return name; }
            set { name = value;
                OnPropertyChanged("Name");
            }
        }
        public int Price
        {
            get { return price; }
            set { price = value; OnPropertyChanged("Price"); }
        }
        public bool TypeProduct
        {
            get { return typeProduct; }
            set { typeProduct = value; OnPropertyChanged("TypeProduct"); }
        }
        public int? SubscriptionPeriod
        {
            get { return subscriptionPeriod; }
            set
            {
                if (typeProduct)
                {
                    subscriptionPeriod = value; 
                    OnPropertyChanged("SubscriptionPeriod");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
