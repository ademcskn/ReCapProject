﻿using Business.Concrete;
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

            foreach (var car in carManager.GetByDailyPrice(120,180))
            {
                Console.WriteLine(car.Description);
            }

            Console.ReadLine();
        }
    }
}
