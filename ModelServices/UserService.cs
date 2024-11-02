using AutoMapper;
using MyApp.Models;
using MyApp.Models.DomainModels;
using MyApp.Models.ViewModels;

namespace MyApp.ModelServices
{
    public class UserService
    {
        private readonly MyAppDbContext _context;
        private readonly IMapper _mapper;

        public UserService(MyAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateUserAsync(RegisterUserViewModel registerUserViewModel)
        {
            var user = _mapper.Map<User>(registerUserViewModel);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }
    }
}
