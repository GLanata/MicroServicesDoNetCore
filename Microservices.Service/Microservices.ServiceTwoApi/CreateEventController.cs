using Microservices.Data;
using Microservices.Logic.Interfaces;
using Microservices.Models;
using Microsoft.AspNet.Mvc;
using System.Threading.Tasks;

namespace Microservices.ServiceTwoApi
{
    [Route("api/[controller]")]
    public class CreateEventController : Controller
    {
        private ApplicationDbContext _dbContext;

        private ICreateEvent _events;

        public CreateEventController(
            ApplicationDbContext dbContext,
            ICreateEvent events)
        {
            _dbContext = dbContext;
            _events = events;
        }

        [HttpPost("create")]
        public async Task<bool> CreateEvent(Event createdEvent)
        {
            return await _events.CreateEventAsync(createdEvent, _dbContext);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_dbContext != null)
                {
                    _dbContext.Dispose();
                    _dbContext = null;
                }
            }

            base.Dispose(disposing);
        }
    }
}
