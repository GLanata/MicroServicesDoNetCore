using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microservices.Data;
using System.Collections;
using Microservices.Models;
using Microsoft.Data.Entity;
using Microservices.Logic.Interfaces;

namespace Microservices.ServiceOneApi
{
    [Route("api/[controller]")]
    public class EventController : Controller
    {
        private ApplicationDbContext _dbContext;

        private IGetEvents _events;

        public EventController(
            ApplicationDbContext dbContext,
            IGetEvents events)
        {
            _dbContext = dbContext;
            _events = events;
        }

        [HttpGet("all")]
        public async Task<IEnumerable<Event>> GetAllEvents()
        {
            return await _events.GetEventsAsync(_dbContext);
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
