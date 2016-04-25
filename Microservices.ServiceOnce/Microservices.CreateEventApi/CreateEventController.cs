using Microservices.Data;
using Microservices.Models;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservices.CreateEventApi
{
    [Route("api/[controller]")]
    public class CreateEventController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public CreateEventController(
            ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("create")]
        public async Task<bool> CreateEvent(Event createdEvent)
        {
            if (createdEvent.Date == DateTime.MinValue)
                return false;

            if (string.IsNullOrWhiteSpace(createdEvent.Name))
                return false;

            _dbContext.Events.Add(createdEvent);

            var result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }
    }
}
