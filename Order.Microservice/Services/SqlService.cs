using Microsoft.Data.SqlClient;
using RepoDb;
using Shared.Database;

namespace Order.Microservice.Services
{
    public class SqlService<T> : IGetById<T>, ICreate<T>, IUpdate<T> where T : class?
    {
        private readonly SqlConnection _sqlConnection;
        public async Task<T?> GetById(object id)
        {
            return (await _sqlConnection.QueryAsync<T>(id)).FirstOrDefault();
        }

        public async Task<T> Create(T model)
        {
            return (T)await _sqlConnection.InsertAsync(model);
        }

        public async Task<T> Update(T model)
        {
            await _sqlConnection.UpdateAsync(model);
            return model;
        }
    }
}
