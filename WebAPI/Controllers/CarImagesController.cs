using System.IO;
using Business.Abstract;
using Business.FileHelpers;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageManager _carImagerManager;
        
        public CarImagesController(ICarImageManager carImagerManager)
        {
            _carImagerManager = carImagerManager;
        }

       
        [HttpPost("Add")]
        public IActionResult Add(int carId,IFormFile file)
        {
            
            CarImage carImage = new CarImage() { CarId=carId};
            var result = _carImagerManager.Add(carImage,file);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Update")]
        public IActionResult Update(int Id,int carId, IFormFile file)
        {

            CarImage carImage = new CarImage() { Id=Id,CarId = carId };
            var result = _carImagerManager.Update(carImage, file);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Delete")]
        public IActionResult Delete(int Id, int carId)
        {

            CarImage carImage = new CarImage() { Id = Id, CarId = carId };
            var result = _carImagerManager.Delete(carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetByCarId")]
        public IActionResult GetByCarId(int carId)
        {
            // Veritabanından yolları çekiyoruz
            var result = _carImagerManager.GetByCarId(carId);

            if (!result.Success)
            {
                string patt = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, "DataAccess", "Utilities", "logo","ben.jpeg");
                var icerde = new List<byte[]>();
                var fileByes = System.IO.File.ReadAllBytes(patt); // Dosyayı byte[] olarak oku
                icerde.Add(fileByes);
                return Ok(icerde);
            }

            // ImagePath'leri liste olarak alıyoruz
            var imagePaths = result.Data.Select(c => c.ImagePath).ToList();

            // Fotoğrafları byte[] listesi olarak yükle
            var imageFiles = new List<byte[]>();
            foreach (var path in imagePaths)
            {
                if (System.IO.File.Exists(path))
                {
                    var fileBytes = System.IO.File.ReadAllBytes(path); // Dosyayı byte[] olarak oku
                    imageFiles.Add(fileBytes);
                }
            }

            // Fotoğrafları API'den döndür
            return Ok(imageFiles);
        }

    }
}
