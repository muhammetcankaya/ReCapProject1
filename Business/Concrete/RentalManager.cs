using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Core.Utilities.Results.Concrete.MessageSucces;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class RentalManager : IRentalManager
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        public IResult Add(Rentals rental)
        {
            if (_rentalDal.GetAll(r => r.CarId == rental.CarId).OrderByDescending(r => r.RentId).FirstOrDefault() == null)
            {
                Console.WriteLine("CAR İLK KEZ EKLENDİ");
                _rentalDal.Add(rental);
                return new ResultSuccess("Araba kiralama bilgisi eklendi");
            }
            else if (_rentalDal.GetAll(r=>r.CarId==rental.CarId).OrderByDescending(r => r.RentId).FirstOrDefault().ReturnDate==null)
            {
                Console.WriteLine("araba kiralanmış durumda");
                return new ResultError("Araba kiralama bilgisi eklendi");
            }
            else
            {
                Console.WriteLine("ARABA DAHA ÖNCE KİRALANMIŞ VE TESLİM EDİLMİŞ  O YÜZDEN KİRALAYABİLİRSİN");
                _rentalDal.Add(rental);
                return new ResultSuccess("Araba Kiralama bilgisi eklenmedi");
            }
        }

        public IResult Delete(Rentals rental)
        {
            _rentalDal.Delete(rental);
            return new ResultSuccess("Silme İşlemi başarıyla gerçekleişti");
        }

        public IDataResult<List<Rentals>> GetAll()
        {
            _rentalDal.GetAll();
            return new DataResult<List<Rentals>>(_rentalDal.GetAll(), true, "Bilgiler Getirildi");
        }

        public IDataResult<Rentals> GetById(int rentalId)
        {
            _rentalDal.Get(r=>r.RentId==rentalId);
            return new DataResult<Rentals>(_rentalDal.Get(r => r.RentId == rentalId), true, "Bilgiler Getirildi");
        }

        public IResult Update(Rentals rental)
        {
            _rentalDal.Delete(rental);
            return new ResultSuccess("Güncelleme İşlemi başarıyla gerçekleişti");
        }
    }
}
