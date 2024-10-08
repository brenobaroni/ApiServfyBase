﻿using Api.Servfy.Base.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Api.Servfy.Base.Application.Services.Contracts
{
    public interface IUserService
    {
        Task<User> GetUserAsync(long id);
    }
}
