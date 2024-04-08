﻿using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.InterfacesPages
{
    public interface IMyServices : IBaseRepository<MyServices>
    {
        Task<IEnumerable<MyServices>> GetServiceAsync();
    }
}