using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class SessionModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public List<int> WinningNumbers { get; set; }
        public List<TicketModel> Tickets { get; set; }
    }
}
