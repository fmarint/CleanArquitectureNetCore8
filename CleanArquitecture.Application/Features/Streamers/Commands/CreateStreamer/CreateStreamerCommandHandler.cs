
using AutoMapper;
using CleanArquitecture.Application.Contracts.Infrastructure;
using CleanArquitecture.Application.Contracts.Persistence;
using CleanArquitecture.Application.Models;
using CleanArquitecture.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArquitecture.Application.Features.Streamers.Commands.CreateStreamer
{
   public class CreateStreamerCommandHandler : IRequestHandler<CreateStreamerCommand, int>
   {

      private readonly IStreamerRepository _streamerRepository;
      private readonly IMapper _mapper;
      private readonly IEmailService _emailService;
      private readonly ILogger<CreateStreamerCommandHandler> _logger;

      public CreateStreamerCommandHandler(IStreamerRepository streamerRepository, IMapper mapper, IEmailService emailService, ILogger<CreateStreamerCommandHandler> logger)
      {
         _streamerRepository = streamerRepository;
         _mapper = mapper;
         _emailService = emailService;
         _logger = logger;
      }

      public async Task<int> Handle(CreateStreamerCommand request, CancellationToken cancellationToken)
      {
         var streamerEntity = _mapper.Map<Streamer>(request);
         var newStreamer = await _streamerRepository.AddAsync(streamerEntity);

         _logger.LogInformation($"Streamer {newStreamer.Id} fue creado exitosamente");

         await SendEmail(newStreamer);
         return newStreamer.Id;
      }

      private async Task SendEmail(Streamer streamer)
      {
         var email = new Email
         {
            To = "fmarin@gmail.com",
            Body = "La compañia se creo correctamente",
            Subjects = "Mensjae de alerta"
         };

         try
         {
            await _emailService.SendEmail(email);
         }
         catch (Exception ex)
         {
            _logger.LogError($"Errores al enviar el correo : {streamer.Id} ");
         }
      }
   }
}


