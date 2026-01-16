using AutoLux.Application;
using AutoLux.Application.Abstractions;
using AutoLux.Application.DTOs;
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
            // 1. Bazadan maşınları chekmek ucun
            var cars = await _unitOfWork.Cars.GetAll().ToListAsync();

            // 2. Maşınları CarDto formatına çevirmek uchun
            var carDtos = _mapper.Map<List<CarDto>>(cars);

            // 3. Nəticəni JSON olaraq göndərmek uchun
            return Ok(carDtos);
        }
    }
}