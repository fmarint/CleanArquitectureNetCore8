﻿using CleanArquitecture.Domain.Common;

namespace CleanArquitecture.Domain
{
   public class Video:BaseDomainModel
    {

      public string? Nombre { get; set; }

      public int StreamerId { get; set; }

      public virtual Streamer? streamer { get; set; }

   }


}
