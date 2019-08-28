using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IAdminService
    {
        void StartSession();
        List<WinnerModel> CheckWinners();
        List<int> Draw();
    }
}
