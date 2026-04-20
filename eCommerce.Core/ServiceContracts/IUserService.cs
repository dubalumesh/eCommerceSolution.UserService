using eCommerce.Core.DTOs;

namespace eCommerce.Core.ServiceContracts
{
    /// <summary>
    /// Interface for user-related services, providing methods for user authentication and management.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// method to Authenticate a user based on the provided login credentials. It takes a LoginRequest object containing the user's email and password, and returns an AuthenticationResponse object that includes the user's ID, email, authentication
        /// </summary>
        /// <param name="loginRequest"></param>
        /// <returns></returns>
        Task<AuthenticationResponse?> Login(LoginRequest loginRequest);
        /// <summary>
        /// method to register a new user based on the provided registration details. It takes a RegisterRequest object containing the user's information, and returns an AuthenticationResponse object that includes the user's ID, email, authentication token, and token expiration.
        /// </summary>
        /// <param name="registerRequest"></param>
        /// <returns></returns>
        Task<AuthenticationResponse?> Register(RegisterRequest registerRequest);
    }
}
