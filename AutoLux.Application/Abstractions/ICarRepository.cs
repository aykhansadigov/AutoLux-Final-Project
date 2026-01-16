using AutoLux.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLux.Application.Abstractions
{
    public interface ICarRepository : IGenericRepository<Car>
    {
        //bura sonralarda mashina aid xususi methodlar yazacagam
    }
}
