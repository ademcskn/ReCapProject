using Business.Concrete;
using Concrete.InMemory;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Linq;

namespace ReCapProject.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            #region ColorMethods
            //ColorAdd();

            //ColorUpdate();

            //ColorDelete();

            //ColorsGetAll();

            //ColorGetById();
            #endregion

            #region BrandMethods
            //BrandAdd();

            //BrandUpdate();

            //BrandDelete();

            //BrandsGetAll();

            //BrandGetById();
            #endregion

            #region CarMethods
            //CarAdd();

            //CarUpdate();

            //CarDelete();

            //CarsGetAll();

            //CarGetById();

            GetCarDetails();
            #endregion

            #region RentalMethods
            //RentalAdd();

            //RentalsGetAll();
            #endregion

            Console.ReadLine();
        }

        #region ColorMethods


        private static void ColorAdd()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Add(new Color { Id = 5, Name = "Green" });
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.Name);
            }
        }
        private static void ColorUpdate()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Update(new Color { Id = 5, Name = "Dark Green" });
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.Name);
            }
        }
        private static void ColorDelete()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Delete(new Color { Id = 5 });
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.Name);
            }
        }
        private static void ColorsGetAll()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.Name);
            }
        }
        private static void ColorGetById()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            var result = colorManager.GetById(1).Data;
            Console.WriteLine(result.Name);
        }

        #endregion

        #region BrandMethods

        private static void BrandAdd()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand { Id = 5, Name = "Peugeot" });
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.Id + "/" + brand.Name);
            }
        }
        private static void BrandUpdate()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Update(new Brand { Id = 5, Name = "BMW" });
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.Name);
            }
        }
        private static void BrandDelete()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Delete(new Brand { Id = 5 });
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.Name);
            }
        }
        private static void BrandsGetAll()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            foreach (var color in brandManager.GetAll().Data)
            {
                Console.WriteLine(color.Name);
            }
        }
        private static void BrandGetById()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var result = brandManager.GetById(1).Data;
            Console.WriteLine(result.Name);
        }
        #endregion

        #region CarMethods
        private static void CarAdd()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car { Id = 5, BrandId = 5, ColorId = 3, DailyPrice = 249, Description = "Peugeot Minibüs", Name = "Peugeot Minibüs" });
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.Name);
            }
        }
        private static void CarUpdate()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Update(new Car { Id = 5, Name = "BMW", Description = "BMW 5.20", DailyPrice = 300 });
            foreach (var brand in carManager.GetAll().Data)
            {
                Console.WriteLine(brand.Name);
            }
        }
        private static void CarDelete()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Delete(new Car { Id = 5 });
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.Name);
            }
        }
        private static void CarsGetAll()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetAll();

            foreach (var car in result.Data)
            {
                Console.WriteLine(car.Name);
            }
            Console.WriteLine();
            Console.WriteLine(result.Message);
        }
        private static void CarGetById()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetById(1).Data;
            Console.WriteLine(result.Name);
        }
        private static void GetCarDetails()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarDetails();

            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine("{0} / {1} / {2} / {3}", car.CarName, car.BrandName, car.ColorName, car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
        #endregion

        #region RentalMethods

        private static void RentalAdd()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            rentalManager.Add(new Rental { Id = 1, CarId = 1, CustomerId = 1, RentDate = DateTime.Now, ReturnDate = DateTime.Now.AddDays(2) });
            foreach (var rental in rentalManager.GetAll().Data)
            {
                Console.WriteLine(rental.CarId);
            }
        }

        private static void RentalsGetAll()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.GetAll();

            foreach (var rental in result.Data)
            {
                Console.WriteLine(rental.Id + " - " + rental.RentDate);
            }
        }

        #endregion
    }
}
