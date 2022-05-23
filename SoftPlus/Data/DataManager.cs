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

        public static string AddData<ModelType>(object obj) where ModelType : class
        {
            try
            {
                var db = new SoftPlusContext();
                AddToDbSet(typeof(ModelType), db, obj);
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
        public static string EditData<ModelType>(object obj) where ModelType : class
        {
            try
            {
                var db = new SoftPlusContext();
                EditInDataSet(typeof(ModelType), db, obj);
                return "Ok";
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

        private static void AddToDbSet(Type type, SoftPlusContext context, object obj)
        {
            if(type == typeof(Client))
            {
                var c = obj as Client;
                if (c.Status.Status == "Ключевой")
                    c.StatusId = 1;
                c.ManagerId = c.Manager.Id;
                c.Manager = null;
                context.Clients.Add(c);

            }
            if (type == typeof(Product))
            {
                context.Products.Add(obj as Product);
            }
            if(type == typeof(Manager))
            {
                context.Managers.Add(obj as Manager);
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
        private static void EditInDataSet(Type type, SoftPlusContext context, object obj)
        {
            if(type == typeof(Client))
            {
                var c = obj as Client;
                var new_c = context.Clients.FirstOrDefault(c1 => c1.Id == c.Id);
                new_c.StatusId = c.StatusId;
                new_c.Name = c.Name;
                new_c.ManagerId = c.ManagerId;
                new_c.Manager = c.Manager;
                
            }
            if (type == typeof(Product))
            {
                var p = obj as Product;
                var new_p = context.Products.FirstOrDefault(p1 => p1.Id == p.Id);
                new_p.Name = p.Name;
                new_p.SubscriptionPeriod = p.SubscriptionPeriod;
                new_p.TypeProduct = p.TypeProduct;
                new_p.Price = p.Price;
                
            }
            if(type == typeof(Manager))
            {
                var m = obj as Manager;
                var new_m = context.Managers.FirstOrDefault(m1 => m1.Id == m.Id);
                new_m.Name= m.Name;
            }
            context.SaveChanges();
        }

    }
}
