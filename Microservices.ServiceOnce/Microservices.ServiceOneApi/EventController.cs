using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microservices.Data;
using System.Collections;
using Microservices.Models;
using Microsoft.Data.Entity;

namespace Microservices.ServiceOneApi
{
    [Route("api/[controller]")]
    public class EventController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public EventController(
            ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("all")]
        public async Task<IEnumerable<Event>> GetAllEvents()
        {
            var events = await _dbContext.Events.ToArrayAsync();

            return events;
        }
    }
}
