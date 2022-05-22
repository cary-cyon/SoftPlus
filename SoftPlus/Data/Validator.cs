
using SoftPlus.Model;

namespace SoftPlus.Data
{
    internal class Validator
    {
        public static bool ValidateProduct(object obj)
        {
            if(obj == null)
                return false;
            var p = obj as Product;
            if (p.TypeProduct == "Лицензия" && p.SubscriptionPeriod != "нет")
                return false;
            if (p.TypeProduct == "Подписка" && p.SubscriptionPeriod == "нет")
                return false;
            return true;
        }
    }
}
