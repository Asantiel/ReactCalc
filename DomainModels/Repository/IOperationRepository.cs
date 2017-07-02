﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModels.Models;

namespace DomainModels.Repository
{
    public interface IOperationRepository
    {
        Operation Get(long id);

        IEnumerable<Operation> GetAll();
    }
}
