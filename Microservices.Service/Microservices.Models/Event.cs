using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Microservices.Models
{
    [Table("Events")]
    public class Event
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }
    }
}
