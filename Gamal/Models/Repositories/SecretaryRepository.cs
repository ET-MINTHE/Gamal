﻿using Gamal.Models.Domain;
using Gamal.Models.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gamal.Models.Repositories
{
    public class SecretaryRepository : Repository<Secretary>, ISecretaryRepository
    {
        public SecretaryRepository(AppDbContext context)
           : base(context)  
        {
        }
    }
}
