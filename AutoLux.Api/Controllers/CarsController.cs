using AutoLux.Application;
using AutoLux.Application.Abstractions;
using AutoLux.Application.DTOs;
using AutoLux.Domain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoLux.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CarsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCars()
        {
            // 1. Bazadan maşınları çəkmək üçün
            var cars = await _unitOfWork.Cars.GetAll().ToListAsync();

            // 2. Maşınları CarDto formatına çevirmək üçün
            var carDtos = _mapper.Map<List<CarDto>>(cars);

            // 3. Nəticəni JSON olaraq göndərmek üçün
            return Ok(carDtos);
        }

        // 1. Yeni Maşın Əlavə Etmək üçün (POST)
        [HttpPost]
        public async Task<IActionResult> CreateCar(CarDto carDto)
        {
            var car = _mapper.Map<Car>(carDto);
            await _unitOfWork.Cars.AddAsync(car);
            await _unitOfWork.SaveAsync(); //
            return Ok(new { message = "Maşın uğurla əlavə edildi!" });
        }

        // 2. Maşın Məlumatlarını Yeniləmək (PUT)
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CarDto carDto)
        {
            var existCar = await _unitOfWork.Cars.GetByIdAsync(id);
            if (existCar == null) return NotFound("Maşın tapılmadı");

            _mapper.Map(carDto, existCar); // DTO-dan gələn datanı köhnənin üzərinə yazır
            _unitOfWork.Cars.Update(existCar);
            await _unitOfWork.SaveAsync();
            return Ok(new { message = "Məlumatlar yeniləndi" });
        }

        // 3. Maşını Sil (DELETE)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            var car = await _unitOfWork.Cars.GetByIdAsync(id);
            if (car == null) return NotFound("Maşın tapılmadı");

            _unitOfWork.Cars.Delete(car);
            await _unitOfWork.SaveAsync();
            return Ok(new { message = "Maşın bazadan silindi" });
        }
    }
}