using MediatR;


namespace CleanArquitecture.Application.Features.Streamers.Commands.DeleteStreamer
{
   public class DeleteStreamerCommand : IRequest<Unit>
   {

      public int Id { get; set; }
   }
}
