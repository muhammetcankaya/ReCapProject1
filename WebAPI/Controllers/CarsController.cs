using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarManager _carManager;
        public CarsController(ICarManager carManager)
        {
                _carManager = carManager;
        }

        [HttpPost("Add")]
        public IActionResult Add(Car car)
        {
            var result = _carManager.Add(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Update")]
        public IActionResult Update(Car car)
        {
            var result = _carManager.Update(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Delete")]
        public IActionResult Delete(Car car)
        {
            var result = _carManager.Delete(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _carManager.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _carManager.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetGetCarsByColorId")]
        public IActionResult GetGetCarsByColorId(int id)
        {
            var result = _carManager.GetGetCarsByColorId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetGetCarsByBrandId")]
        public IActionResult GetGetCarsByBrandId(int id)
        {
            var result = _carManager.GetGetCarsByBrandId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


    }
}
