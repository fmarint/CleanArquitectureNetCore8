
using AutoMapper;
using CleanArquitecture.Application.Contracts.Persistence;
using CleanArquitecture.Application.Exceptions;
using CleanArquitecture.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArquitecture.Application.Features.Streamers.Commands.DeleteStreamer
{
   public class DeleteStreamerCommandHandler : IRequestHandler<DeleteStreamerCommand, Unit>
   {

      private readonly IStreamerRepository _streamerRepository;
      private readonly ILogger<DeleteStreamerCommand> _logger;
      private readonly Mapper _mapper;

      public DeleteStreamerCommandHandler(IStreamerRepository streamerRepository, ILogger<DeleteStreamerCommand> logger, Mapper mapper)
      {
         _streamerRepository = streamerRepository;
         _logger = logger;
         _mapper = mapper;
      }

      public async Task<Unit> Handle(DeleteStreamerCommand request, CancellationToken cancellationToken)
      {

         var streamerToDelete = await _streamerRepository.GetByIdAsync(request.Id);

         if (streamerToDelete == null)
         {
            _logger.LogError($"{request.Id} streamer no existe en el sistema");
            throw new NotFoundException(nameof(Streamer), request.Id);
         }

         await _streamerRepository.DeleteAsync(streamerToDelete);
         _logger.LogInformation($"El {request.Id} fue eliminado con exito");

         return Unit.Value;
      }
   }
}
