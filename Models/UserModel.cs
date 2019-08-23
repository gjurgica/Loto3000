using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Address { get; set; }
        public List<TicketModel> Numbers { get; set; } = new List<TicketModel>();
    }
}
