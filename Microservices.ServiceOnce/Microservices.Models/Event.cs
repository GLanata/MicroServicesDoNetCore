using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

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
