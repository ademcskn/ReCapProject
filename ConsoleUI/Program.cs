using Business.Concrete;
using Concrete.InMemory;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ReCapProject.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());

            foreach (var car in carManager.GetAllByDescription("Sedan"))
            {
                Console.WriteLine(car.Description);
            }

            foreach (var brand in brandManager.GetAllByBrandName("Opel"))
            {
                Console.WriteLine(brand.Name);
            }


            foreach (var color in colorManager.GetAllByColorName("Black"))
            {
                Console.WriteLine(color.Name);
            }

            Console.ReadLine();
        }
    }
}
