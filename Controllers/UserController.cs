using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApp.Models;

namespace MyApp.Controllers
{
    public class UserController : Controller
    {
        private readonly MyAppDbContext _context;

        public UserController(MyAppDbContext context)
        {
            _context = context;
        }

        [HttpGet("UsersByCityAndState")]
        public async Task<IActionResult> UsersByCityAndState(int pageNumber = 1, int pageSize = 10)
        {
            var usersInCityAndState = await _context.Users
                .Where(u => u.Addresses.Any(a => a.City == a.State))
                .Select(u => new
                {
                    User = u.Username,
                    UserAddresses = u.Addresses
                })
                .OrderBy(u => u.User)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return View(usersInCityAndState);
        }

        [HttpGet("UserCountByState")]
        public async Task<IActionResult> UserCountByState()
        {
            var userCountByState = await _context.Users
                .GroupBy(u => u.Addresses.FirstOrDefault().State)
                .Select(g => new
                {
                    State = g.Key,
                    Count = g.Count()
                })
                .OrderBy(x => x.State)
                .ToListAsync();

            return View(userCountByState);
        }

        [HttpGet("LongestAddressUsers")]
        public async Task<IActionResult> LongestAddressUsers()
        {
            var usersWithAddress = await _context.Users
                .Select(u => new
                {
                    User = u.Username,
                    Address = u.Addresses.Select(a => (a.AddressLine1 + " " + a.AddressLine2 + " " + a.City + " " + a.State + " " + a.ZipCode)).FirstOrDefault()
                })
                .ToListAsync();

            var usersWithAddressLength = usersWithAddress
                .Select(u => new
                {
                    u.User,
                    u.Address,
                    AddressLength = u.Address?.Length
                })
                .OrderByDescending(x => x.AddressLength)
                .ToList();


            return View(usersWithAddressLength);
        }
    }
}