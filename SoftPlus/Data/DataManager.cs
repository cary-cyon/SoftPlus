using SoftPlus.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftPlus.Data
{
    internal class DataManager
    {
        public static string AddDataProduct(object obj)
        {
            try
            {
                var db = new SoftPlusContext();

                var p = new Product() { Name = "Wind", Price = 100, TypeProduct = "Подписка", SubscriptionPeriod = "Месяц" };
                db.Products.Add(p);
                db.SaveChanges();
                return "Ok";
            }
            catch
            {
                return "Error";
            }

        }
    }
}
