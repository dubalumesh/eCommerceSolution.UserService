using eCommerce.Core.Entities;


namespace eCommerce.Core.RepositoryContracts
{
    public interface IUserRepository
    {
        /// <summary>
        /// method to add user to database
        /// </summary>
        /// <param name="user">The user entity to be added</param>
        /// <returns>The added user entity</returns>
        Task<ApplicationUser> AddUserAsync(ApplicationUser user);

        /// <summary>
        /// method to get user by email and password
        /// </summary>
        /// <param name="email">The email of the user</param>
        /// <param name="password">The password of the user</param>
        /// <returns>The user entity if found, otherwise null</returns>
        Task<ApplicationUser> GetUserByEmailAndPasswordAsync(string? email, string? password);
    }
}
