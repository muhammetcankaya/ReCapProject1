using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.FileHelpers
{
    public class FileHelper
    {


        public static string SaveFile(int carId, IFormFile file)
        {
            // Ana klasör (RentACar/Photos) zaten mevcut
            string directoryPath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, "DataAccess", "Utilities", "FileCarImages");

            // Benzersiz GUID ile dosya adı oluşturulması, carId ile ilişkilendirilerek
            string fileName = $"Car_{carId}_{Guid.NewGuid()}" + Path.GetExtension(file.FileName);
            string filePath = Path.Combine(directoryPath, fileName);

            // Dosyanın kaydedilmesi
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            


            // Fotoğrafın kaydedilen yolunu döndürme
            return filePath;
        }
    }
}


