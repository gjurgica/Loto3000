using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IUserService
    {
        UserModel Authenticate(string username, string password);
        void RegisterUser(RegisterModel model);
        void BuyTicket(TicketModel model,int userId);
    }
}
