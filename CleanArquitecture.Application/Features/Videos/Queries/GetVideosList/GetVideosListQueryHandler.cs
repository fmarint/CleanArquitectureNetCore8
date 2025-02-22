﻿using AutoMapper;
using CleanArquitecture.Application.Contracts.Persistence;
using MediatR;

namespace CleanArquitecture.Application.Features.Videos.Queries.GetVideosList
{
   public class GetVideosListQueryHandler : IRequestHandler<GetVideosListQuery, List<VideosVm>>
   {

      private readonly IVideoRepository _videoRepository;
      private readonly IMapper _mapper;

      public GetVideosListQueryHandler( IVideoRepository videoRepository, IMapper mapper )
      {
         _videoRepository = videoRepository;
         _mapper = mapper;
      }

      public Task<List<VideosVm>> Handle(GetVideosListQuery request, CancellationToken cancellationToken)
      {
         
         throw new NotImplementedException();


      }


   }
}
