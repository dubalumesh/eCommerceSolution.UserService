using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserService.Infrastructure.DbContext
{
    public class DapperDbContext
    {
        private readonly IConfiguration _configuration;
        private readonly IDbConnection _dbDonction;

        public DapperDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            string? connectionString = _configuration.GetConnectionString("PostgresConnection");

            //create new NpgSql Connection

            _dbDonction = new Npgsql.NpgsqlConnection(connectionString);
        }
        // Expose the IDbConnection for use in repositories as property
        public IDbConnection Connection => _dbDonction;
    }
}
