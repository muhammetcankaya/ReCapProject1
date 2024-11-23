using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.FileHelpers;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Core.Utilities.Results.Concrete.DataMessageSucces;
using Core.Utilities.Results.Concrete.MessageSucces;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageManager
    {
        ICarImageDal _carImagerDal;
        public CarImageManager(ICarImageDal carImagerDal)
        {
            _carImagerDal = carImagerDal;
        }
        
        public IResult Add(CarImage carImage,IFormFile file)
        {
            //CarImage carImage = new CarImage
            //{
            //    CarId = carId,
            //    ImagePath = filePath,
            //    Date = DateTime.Now
            //};
            IResult result = BusinessRules.Run(ChechImagesCountOfLimit(carImage.CarId));
            if (result != null){return result;}

            string imagepathstingversion = FileHelper.SaveFile(carImage.CarId,file);
            carImage.ImagePath= imagepathstingversion;
            _carImagerDal.Add(carImage);
            return new ResultSuccess("Fotoğraf başarıyla eklendi");
            
        }

        private IResult ChechImagesCountOfLimit(int carId)
        {
            int sayı = _carImagerDal.GetAll(p => p.CarId == carId).Count();
            if (sayı >4)
            {
                return new ResultError("5 fotoğraftan fazlasını ekleyemezsin");
            }
            return new ResultSuccess("Ekleme İşlemi başarılı");
        }

        public IResult Update(CarImage carImage,IFormFile file)
        {
            //bu kısımı farklı yerdde yazacam
            string oldımagepath = _carImagerDal.Get(p => p.Id == carImage.Id).ImagePath;
            File.Delete(oldımagepath);
            string newimagepathstingversion = FileHelper.SaveFile(carImage.CarId, file);
            carImage.ImagePath = newimagepathstingversion;
            _carImagerDal.Update(carImage);
            return new ResultSuccess("Fotoğraf başarıyla Güncellendi");
        }

        public IResult Delete(CarImage carImage)
        {
            string oldımagepath = _carImagerDal.Get(p => p.Id == carImage.Id).ImagePath;
            File.Delete(oldımagepath);
            _carImagerDal.Delete(carImage);
            return new ResultSuccess("Silme işlemi başarıyla gerçekleşti");
        }


        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {

            var result = _carImagerDal.GetAll(p => p.CarId == carId);
            if (result == null || !result.Any())
            {
                return new DataResultError<List<CarImage>>(result,"Bu araca ait resim bulunamadı.");
            }
            return new DataResultSuccess<List<CarImage>>(result, "Resimler başarıyla getirildi.");
        }


    }
}
