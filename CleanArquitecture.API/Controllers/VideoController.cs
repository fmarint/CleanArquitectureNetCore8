using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Net;
using CleanArquitecture.Application.Features.Videos.Queries.GetVideosList;

namespace CleanArquitecture.API.Controllers
{
   [Route("api/v1/[controller]")]
   [ApiController]
   public class VideoController : ControllerBase
   {

      private readonly IMediator _mediator;

      public VideoController(IMediator mediator)
      {
         this._mediator = mediator;
      }

      [HttpGet("{username}", Name = "GetVideo")]
      [ProducesResponseType(typeof(IEnumerable<VideosVm>), (int)HttpStatusCode.OK)]
      public async Task<ActionResult<IEnumerable<VideosVm>>> GetVideoByUserName(string username)
      {
         var query = new GetVideosListQuery(username);
         var videos = await _mediator.Send(query);

         return Ok(videos);
      }
   }
}
