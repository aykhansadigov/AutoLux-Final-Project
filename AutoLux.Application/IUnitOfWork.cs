using AutoLux.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLux.Application
{
    public interface IUnitOfWork
    {
        ICarRepository Cars { get; } // Mashin repository-si burada olacaq 
        Task<int> SaveAsync(); // Bütün ishleri bir defeye yadda saxlamaq uchun
    }
}
