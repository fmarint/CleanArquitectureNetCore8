﻿using MediatR;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using CleanArquitecture.Application.Features.Streamers.Commands.CreateStreamer;
using System.Threading.Tasks;
using CleanArquitecture.Application.Features.Streamers.Commands.UpdateStreamer;
using CleanArquitecture.Application.Features.Streamers.Commands.DeleteStreamer;


namespace CleanArquitecture.API.Controllers
{
   [Route("api/v1/[controller]")]
   [ApiController]
   public class StreamerController : ControllerBase
   {
      private readonly IMediator _mediator;

      public StreamerController(IMediator mediator)
      {
         this._mediator = mediator;
      }


      [HttpPost(Name = "CreateStreamer")]
      [ProducesResponseType((int)HttpStatusCode.OK)]
      public async Task<ActionResult<int>> CreateStreamer([FromBody] CreateStreamerCommand command)
      {
         return await _mediator.Send(command);
      }

      [HttpPut(Name = "UpdateStreamer")]
      [ProducesResponseType(StatusCodes.Status204NoContent)]
      [ProducesResponseType(StatusCodes.Status404NotFound)]
      [ProducesDefaultResponseType]
      public async Task<ActionResult> UpdateStreamer([FromBody] UpdateStreamerCommand command)
      {
         await _mediator.Send(command);
         return NoContent();
      }

      [HttpDelete("{id}", Name = "DeleteStreamer")]
      [ProducesResponseType(StatusCodes.Status204NoContent)]
      [ProducesResponseType(StatusCodes.Status404NotFound)]
      [ProducesDefaultResponseType]
      public async Task<ActionResult> DeleteStreamer(int id)
      {
         var command = new DeleteStreamerCommand { Id = id };
         await _mediator.Send(command);
         return NoContent();
      }


   }
}
