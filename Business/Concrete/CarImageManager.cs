using Business.Abstract;
using Business.Constants;
using Core.Utilities.BusinessRule;
using Core.Utilities.Helper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }
        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRule.Run(CheckCarMaxImageLimit(carImage.CarId));

            var carImageResult = FileHelperManager.Upload(file);

            if (!carImageResult.Success)
            {
                return new ErrorResult(carImageResult.Message);
            }
            carImage.ImagePath = carImageResult.Message;
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Delete(CarImage carImage)
        {
            var image = _carImageDal.Get(c => c.Id == carImage.Id);
            if (image != null)
            {
                FileHelperManager.Delete(image.ImagePath);
                _carImageDal.Delete(carImage);
                return new SuccessResult(Messages.Deleted);
            }
            return new ErrorResult(Messages.Deleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.ProductListed);
        }

        public IDataResult<CarImage> GetById(int carImageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == carImageId), Messages.ProductListed);
        }

        public IDataResult<List<CarImage>> GetCarImageListByCarId(int carId)
        {
            IResult result = BusinessRule.Run(CarImageCheck(carId));
            if (result != null)
            {
                return new ErrorDataResult<List<CarImage>>(result.Message);
            }

            return new SuccessDataResult<List<CarImage>>(CarImageCheck(carId).Data, Messages.ProductsListed);
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            var image = _carImageDal.Get(c => c.Id == carImage.Id);
            if (image == null)
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            var updated = FileHelperManager.Update(file, image.ImagePath);
            if (!updated.Success)
            {
                return new ErrorResult(updated.Message);
            }
            carImage.ImagePath = updated.Message;
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.ProductUpdated);
        }

        private IResult CheckImageLimitExceeded(int carId)
        {
            var carImageCount = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (carImageCount >= 5)
            {
                return new ErrorResult(Messages.CarImageLimitExceeded);
            }
            return new SuccessResult();
        }

        private IDataResult<List<CarImage>> CheckIfCarImageNull(int id)
        {
            try
            {
                string path = @"\Uploads\Images\default.png";
                var result = _carImageDal.GetAll(c => c.CarId == id).Any();
                if (!result)
                {
                    List<CarImage> carImage = new List<CarImage>();
                    carImage.Add(new CarImage { CarId = id, ImagePath = path, Date = DateTime.Now });
                    return new SuccessDataResult<List<CarImage>>(carImage);
                }
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<CarImage>>(exception.Message);
            }

            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == id));
        }

        private IResult CheckCarMaxImageLimit(int id)
        {
            var result = _carImageDal.GetAll(c => c.CarId == id).Count;
            if (result > 5)
            {
                return new ErrorResult("Limit doldu.");
            }
            return new SuccessResult();
        }

        private IDataResult<List<CarImage>> CarImageCheck(int carId)
        {
            try
            {
                string path = @"\Uploads\Images\default.png";
                var result = _carImageDal.GetAll(c => c.CarId == carId).Any();

                if (!result)
                {
                    List<CarImage> carImage = new List<CarImage>();
                    carImage.Add(new CarImage { CarId = carId, ImagePath = path, Date = DateTime.Now });
                    return new SuccessDataResult<List<CarImage>>(carImage);
                }
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<CarImage>>(ex.Message);
            }

            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(p => p.CarId == carId).ToList());
        }
    }
}
