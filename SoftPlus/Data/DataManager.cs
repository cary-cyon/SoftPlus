using SoftPlus.Model;
using SoftPlus.ViewModel;
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

                var p = new Product();
                db.Products.Add(p);
                db.SaveChanges();
                ApplicationViewModel app = ApplicationViewModel.getInstance();
                app.Update();
                return "Ok";
            }
            catch
            {
                return "Error";
            }

        }
        public static string RemoveDataProduct(object obj)
        {
            try
            {
                var db = new SoftPlusContext();
                var p = obj as Product;
                db.Products.Remove(p);
                db.SaveChanges ();
                var app = ApplicationViewModel.getInstance();
                app.Update ();
                return "Ок";
            }
            catch 
            {
                return "Error";
            }
        }
        public static string EditDataProduct(object obj)
        {
            try
            {
                var db = new SoftPlusContext();
                var p = obj as Product;
                var new_p = db.Products.FirstOrDefault(p1 => p1.Id == p.Id);
                new_p.Name = p.Name;
                new_p.SubscriptionPeriod = p.SubscriptionPeriod;
                new_p.TypeProduct = p.TypeProduct;
                new_p.Price = p.Price;
                db.SaveChanges();
                var app = ApplicationViewModel.getInstance();
                app.Update();
                return "Ок";
            }
            catch
            {
                return "Error";
            }
        }

        public static string SelectValue(object obj)
        {
            var app = ApplicationViewModel.getInstance();
            app.SelectedProduct = obj as Product;
            return "Ok";
        }
    }
}
