using AutoLux.Application.Abstractions;
using AutoLux.Domain.Entities;
using AutoLux.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLux.Persistence.Repositories
{
    public class CarRepository : GenericRepository<Car>, ICarRepository
    {
        public CarRepository(AutoLuxDbContext context) : base(context)
        {
        }
    }
}
