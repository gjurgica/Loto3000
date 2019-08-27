using DataAccess;
using DataModels;
using Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public class AdminService : IAdminService
    {
        private readonly IRepository<TicketDbo> _ticketRepository;
        private readonly IRepository<SessionDbo> _sessionRepository;
        private readonly IRepository<UserDbo> _userRepository;
        public AdminService( IRepository<TicketDbo> ticketRepository, IRepository<SessionDbo> sessionRepository,IRepository<UserDbo> userRepository)
        {
            _ticketRepository = ticketRepository;
            _sessionRepository = sessionRepository;
            _userRepository = userRepository;
        }

        public void StartSession()
        {
            var newSession = new SessionDbo()
            {
                Date = DateTime.Now,
                Tickets = new List<TicketDbo>()
            };
            _sessionRepository.Add(newSession);
        }
        public List<WinnerModel> CheckWinners()
        {
            List<WinnerModel> winners = new List<WinnerModel>();
            var session = _sessionRepository.GetAll().LastOrDefault();
            var luckyNumbers = Draw();

            var numbers = _ticketRepository.GetAll()
                .Where(x => x.Session == session.Id)
                .Select(x => new TicketModel()
                {
                    UserId = x.UserId,
                    Session = x.Session,
                    Numbers = x.Numbers.Select(c => c - '0').ToList()
        });
            foreach(var num in numbers)
            {
                var check = num.Numbers.Intersect(luckyNumbers).ToList();
                if (check.Count == 3)
                {
                    WinnerModel model = new WinnerModel()
                    {
                        FirstName = _userRepository.GetAll().Where(x => x.Id == num.UserId).Select(x => x.FirstName).ToString(),
                        LastName = _userRepository.GetAll().Where(x => x.Id == num.UserId).Select(x => x.LastName).ToString(),
                        Prize = Prizes.GiftCard_50
                    };
                    winners.Add(model);
                }
                else if(check.Count == 4)
                {
                    WinnerModel model = new WinnerModel()
                    {
                        FirstName = _userRepository.GetAll().Where(x => x.Id == num.UserId).Select(x => x.FirstName).ToString(),
                        LastName = _userRepository.GetAll().Where(x => x.Id == num.UserId).Select(x => x.LastName).ToString(),
                        Prize = Prizes.GiftCard_100
                    };
                    winners.Add(model);
                }
                else if (check.Count == 5)
                {
                    WinnerModel model = new WinnerModel()
                    {
                        FirstName = _userRepository.GetAll().Where(x => x.Id == num.UserId).Select(x => x.FirstName).ToString(),
                        LastName = _userRepository.GetAll().Where(x => x.Id == num.UserId).Select(x => x.LastName).ToString(),
                        Prize = Prizes.TV
                    };
                    winners.Add(model);
                }
                else if (check.Count == 6)
                {
                    WinnerModel model = new WinnerModel()
                    {
                        FirstName = _userRepository.GetAll().Where(x => x.Id == num.UserId).Select(x => x.FirstName).ToString(),
                        LastName = _userRepository.GetAll().Where(x => x.Id == num.UserId).Select(x => x.LastName).ToString(),
                        Prize = Prizes.Vacation
                    };
                    winners.Add(model);
                }
                else if (check.Count == 7)
                {
                    WinnerModel model = new WinnerModel()
                    {
                        FirstName = _userRepository.GetAll().Where(x => x.Id == num.UserId).Select(x => x.FirstName).ToString(),
                        LastName = _userRepository.GetAll().Where(x => x.Id == num.UserId).Select(x => x.LastName).ToString(),
                        Prize = Prizes.Car
                    };
                    winners.Add(model);
                }
            }
            return winners;

        }
        private List<int> Draw()
        {
            List<int> numbers = new List<int>();
            Random rnd = new Random();
            int number;
            for(var i = 0; i < 9; i++)
            {
                number = rnd.Next(1, 39);
                if (!numbers.Contains(number))
                {
                    numbers.Add(number);
                }
            }
            return numbers;
        }
    }
}
