using ReCapProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReCapProject.Business
{
    public interface ICarService
    {
        List<Car> GetAll();
    }
}
