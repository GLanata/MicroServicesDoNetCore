using Microservices.Data;
using Microservices.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microservices.Logic.Interfaces
{
    public interface IGetEvents
    {
        Task<IEnumerable<Event>> GetEventsAsync(ApplicationDbContext dbContext);
    }
}
