using System.Collections.Generic;


namespace SoftPlus.Model
{
    internal class Product
    {
        public int Id { get; set; } 
        public string Name { get; set; }

        public int Price { get; set; }

        private string typeProduct;
        public string TypeProduct { 
            get 
            {
                return typeProduct;
            }
            set
            {
                typeProduct = value;
                if (value == "Лицензия")
                    SubscriptionPeriod = "нет";
            }
            }

        public string SubscriptionPeriod { get; set; }
        public List<ClientProduct> ClientProducts { get; set; }
        public Product()
        {
            TypeProduct = "Лицензия";
            SubscriptionPeriod = "Нет";
        }

    }
}
