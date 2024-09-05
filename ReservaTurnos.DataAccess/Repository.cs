using Dapper.Contrib.Extensions;
using ReservaTurnos.Repository;
using System.Data.SqlClient;

namespace ReservaTurnos.DataAccess
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected string connectionString;

        public Repository(string connectionString)
        {
            SqlMapperExtensions.TableNameMapper = (type) => { return $"{ type.Name }"; };
            this.connectionString = connectionString;
        }
        public bool Delete(T entity)
        {
            using var connection = new SqlConnection(connectionString);
            return connection.Delete(entity);
        }

        public T GetById(int id)
        {
            using var connection = new SqlConnection(connectionString);
            return connection.Get<T>(id);
        }

        public IEnumerable<T> GetList()
        {
            using var connection = new SqlConnection(connectionString);
            return connection.GetAll<T>();
        }

        public int Insert(T entity)
        {
            using var connection = new SqlConnection(connectionString);

            return (int)connection.Insert(entity);
        }


        public bool Update(T entity)
        {
            using var connection = new SqlConnection(connectionString);
            return connection.Update(entity);
        }
    }
}
