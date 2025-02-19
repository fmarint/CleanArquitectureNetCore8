using MediatR;

namespace CleanArquitecture.Application.Features.Videos.Queries.GetVideosList
{
  public  class GetVideosListQuery :IRequest<List<VideosVm>>
    {
      public GetVideosListQuery( string username)
      {
         UserName = username ?? throw new ArgumentNullException(nameof(username));
      }

      public string? UserName { get; set; }

   }


}
