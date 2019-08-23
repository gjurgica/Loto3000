using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class WinnerModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Prizes Prize { get; set; }
        public List<TicketModel> WinningNumbers { get; set; } = new List<TicketModel>();
    }
}
