using Dapper;
using UserService.Core.DTOs;
using System.Collections.Generic;
using UserService.Core.Entities;
using UserService.Core.RepositoryContracts;
using UserService.Infrastructure.DbContext;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace UserService.Infrastructure.Repository
{
    internal class UserRepository(DapperDbContext _dapperDbContext) : IUserRepository
    {
        public async Task<ApplicationUser> AddUserAsync(ApplicationUser user)
        {
            try
            {
                user.UserId = Guid.NewGuid();


                // SQL Query to insert user data into the "Users" table.
                string query = "INSERT INTO public.\"Users\"(\"UserId\", \"Email\", \"PersonName\", \"Gender\", \"Password\") VALUES(@UserId, @Email, @PersonName, @Gender, @Password)";

                int rowCountAffected = await _dapperDbContext.Connection.ExecuteAsync(query, user);

                if (rowCountAffected > 0)
                    return user;
                else throw new Exception("User could not be added to database");
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<ApplicationUser> GetUserByEmailAndPasswordAsync(string? email, string? password)
        {

            string query = "SELECT * FROM public.\"Users\" WHERE \"Email\" = @Email AND \"Password\" = @Password";
            var user = await _dapperDbContext.Connection.QueryFirstOrDefaultAsync<ApplicationUser>(query, new { Email = email, Password = password });
            return user;
        }
    }
}
