using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string ProductsListed = "Ürünler Listelendi";
        public static string ProductListed = "Ürün Listelendi";
        public static string ProductUpdated = "Ürün Güncellendi";
        public static string Deleted ="Silme başarılı";
        public static string VecihleError = "Araç Dolu";

        public static string CarImageLimitExceeded { get; internal set; }
    }
}
