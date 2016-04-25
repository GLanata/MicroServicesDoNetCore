using Microservices.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microservices.Models;
using Microsoft.Data.Entity;
using Microservices.Data;

namespace Microservices.Logic
{
    public class EventData : IGetEvents, ICreateEvent
    {
        public async Task<bool> CreateEventAsync(Event createdEvent, ApplicationDbContext dbContext)
        {
            if (createdEvent.Date == DateTime.MinValue)
                return false;

            if (string.IsNullOrWhiteSpace(createdEvent.Name))
                return false;

            dbContext.Events.Add(createdEvent);

            var result = await dbContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<IEnumerable<Event>> GetEventsAsync(ApplicationDbContext dbContext)
        {
            return await dbContext
                .Events
                .ToArrayAsync();
        }
    }
}
