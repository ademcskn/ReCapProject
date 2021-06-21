using ReCapProject;
using ReCapProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReCapProject.DataAccess
{
    public interface ICarDal
    {
        List<Car> GetAll();
        Car GetById(int id);
        void Add(Car car);
        void Delete(Car car);
        void Update(Car car);
    }
}
