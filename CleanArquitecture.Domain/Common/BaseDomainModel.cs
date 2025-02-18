﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArquitecture.Domain.Common
{
   public abstract class BaseDomainModel
   {
      public int Id { get; set; }
      public DateTime? CreateDate { get; set; }
      public string? CreatedBy { get; set; }
      public DateTime? LastModifiedDate { get; set; }
      public string? LastModifiedBy { get; set; }
   }
}
