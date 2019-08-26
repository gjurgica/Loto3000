using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class TicketModel
    {
        public int Id { get; set; }
        public List<int> Numbers { get; set; }
        public int UserId { get; set; }
        public int Session { get; set; }
    }
}
