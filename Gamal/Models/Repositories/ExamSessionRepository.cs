﻿using Gamal.Models.Domain;
using Gamal.Models.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gamal.Models.Repositories
{
    public class ExamSessionRepository : Repository<ExamSession>, IExamSessionRepository
    {
        public ExamSessionRepository(AppDbContext context)
           : base(context)
        {
        }
       public IEnumerable<ExamSession> GetDollyVideoByCourse()
		 {
          return AppContext.ExamSessions.ToList();
		 }


      public AppDbContext AppContext
      {
         get { return Context as AppDbContext; }
      }
   }
}
