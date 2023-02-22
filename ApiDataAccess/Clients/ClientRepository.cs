using System;
using System.Data.SqlClient;
using ApiDataAccess.General;
using ApiModel.Clients;
using ApiRepositories.Clients;
using Dapper;

namespace ApiDataAccess.Clients
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        public ClientRepository(string connectionString) : base(connectionString)
        {
        }

        public Client LookClient(string documentNumber)
        {
            var parameters = new DynamicParameters(new
            {
                p_documentNumber = documentNumber
            });
            string sql = "SELECT * FROM Client WHERE clientDocumentNumber = @p_documentNumber";
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.QueryFirstOrDefault<Client>(
                    sql, parameters);
            }
        }
    }
}
