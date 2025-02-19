using CleanArquitecture.Domain;

namespace CleanArquitecture.Application.Contracts.Persistence
{
   public interface IVideoRepository : IAsyncRepository<Video>
   {

      Task<Video> GetVideoByName(string nameVideo);

      Task<IEnumerable<Video>> GetVideoByUserName( string   userName);


   }

}
