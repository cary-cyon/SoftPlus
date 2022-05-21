using Microsoft.EntityFrameworkCore;
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

        public static string AddData<ModelType>(object obj) where ModelType : new() 
        {
            try
            {
                var db = new SoftPlusContext();
                var p = new ModelType();
                AddToDbSet(typeof(ModelType), db);
                ApplicationViewModel app = ApplicationViewModel.getInstance();
                app.Update();
                return "Ok";
            }
            catch
            {
                return "Error";
            }

        }
        public static string RemoveData<ModelType>(object obj)
        {
            try
            {
                var db = new SoftPlusContext();
                RemoveFromDbSet(typeof(ModelType), db, obj);
                var app = ApplicationViewModel.getInstance();
                app.Update();
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
        public static bool CanRemoveData(object obj)
        {
            return obj != null ? true : false;
        }

        private static void AddToDbSet(Type type, SoftPlusContext context)
        {
            if(type == typeof(Client))
            {
                context.Clients.Add(new Client());
            }
            if(type == typeof(Product))
            {
                context.Products.Add(new Product());
            }
            if(type == typeof(Manager))
            {
                context.Managers.Add(new Manager());
            }
            context.SaveChanges();
        }
        private static void RemoveFromDbSet(Type type, SoftPlusContext context, object obj)
        {
            if (type == typeof(Client))
            {
                Client cl = obj as Client;
                context.Clients.Remove(cl);
            }
            if (type == typeof(Product))
            {
                Product cl = obj as Product;
                context.Products.Remove(cl);
            }
            if (type == typeof(Manager))
            {
                Manager cl = obj as Manager;
                context.Managers.Remove(cl);
            }
            context.SaveChanges();

        }

    }
}
