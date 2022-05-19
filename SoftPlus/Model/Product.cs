using System.Collections.Generic;


namespace SoftPlus.Model
{
    internal class Product
    {
        public int Id { get; set; } 
        public string Name { get; set; }

        public int Price { get; set; }

        public string TypeProduct { get; set; }

        public string SubscriptionPeriod { get; set; }
        public List<ClientProduct> ClientProducts { get; set; }

    }
}
