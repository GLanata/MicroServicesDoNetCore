using Microservices.Data;
using Microservices.Models;
using System.Threading.Tasks;

namespace Microservices.Logic.Interfaces
{
    public interface ICreateEvent
    {
        Task<bool> CreateEventAsync(Event createdEvent, ApplicationDbContext dbContext);
    }
}
