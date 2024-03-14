using Microsoft.AspNetCore.Identity;
using ShipInfo.DAL;


namespace ShipInfo.DOMAIN
{
    public class AccountService
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly JWTService _jwtService;

        public AccountService(UserManager<AppUser> userManager, JWTService jwtService)
        {
            _userManager = userManager;
            _jwtService = jwtService;
        }

        public async Task<UserRegisterResponse> RegisterUser(UserRegisterRequest model)
        {
            var email = model.Email.ToLower();

            var user = await _userManager.FindByEmailAsync(email);

            if (user != null)
                throw new ArgumentException("User is already exists.");

            var newUser = new AppUser
            {
                UserName = model.Email,
                Email = email,
                EmailConfirmed = true,
            };

            var userNew = await _userManager.CreateAsync(newUser, model.Password);

            if (!userNew.Succeeded)
            {
                throw new Exception(userNew.Errors?.FirstOrDefault()?.Description);
            }

            var userReg = new UserRegisterResponse
            {
                UserName = newUser.UserName,
                Email = newUser.Email
            };

            userNew = await _userManager.AddToRoleAsync(newUser, Roles.ADMIN);


            if (!userNew.Succeeded)
            {
                throw new Exception(userNew.Errors?.FirstOrDefault()?.Description);
            }

            return userReg;
        }


        public async Task<UserLogginResponse> Login(UserLogginRequest model)
        {
            var email = model.Email.ToLower();

            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
                throw new ArgumentException("Invalid input data");

            if (!await _userManager.CheckPasswordAsync(user, model.Password))
                throw new ArgumentException("Invalid input data");

            var token = await _jwtService.GenerateToken(user.Id, user.Email);

            return new UserLogginResponse
            {
                AccessToken = token,
                UserId = user.Id
            };

        }

    }
}
