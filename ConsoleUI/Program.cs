using ReCapProject.Business;
using ReCapProject.DataAccess;
using System;

namespace ReCapProject
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }


            Console.ReadLine();
        }
    }
}
