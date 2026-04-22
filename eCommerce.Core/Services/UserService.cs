using AutoMapper;
using UserService.Core.DTOs;
using UserService.Core.Entities;
using UserService.Core.RepositoryContracts;
using UserService.Core.ServiceContracts;


namespace UserService.Core.Services
{
    internal class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        /// <summary>
        /// method to login user with email and password and return Authenticated response details          
        /// </summary>  
        /// <param name="loginRequest">The login request containing email and password.</param>
        /// <returns>An AuthenticationResponse containing user details and token if login is successful.</returns>
        public async Task<AuthenticationResponse?> Login(LoginRequest loginRequest)
        {
            ApplicationUser user = await _userRepository.GetUserByEmailAndPasswordAsync(loginRequest.Email, loginRequest.Password);
            if (user == null) { return null; }

            return _mapper.Map<ApplicationUser, AuthenticationResponse>(user) with { Token = "Token", Sucess = true };

        }
        /// <summary>
        /// method to register user with email, person name, password and return Authenticated response details
        /// </summary>
        /// <param name="registerRequest"></param>
        /// <returns></returns>
        public async Task<AuthenticationResponse?> Register(RegisterRequest registerRequest)
        {

            var applicationUser = _mapper.Map<RegisterRequest, ApplicationUser>(registerRequest);
            ApplicationUser registeredUser = await _userRepository.AddUserAsync(applicationUser);
            return _mapper.Map<ApplicationUser, AuthenticationResponse>(registeredUser) with { Token = "Token", Sucess = true };


        }
    }
}
