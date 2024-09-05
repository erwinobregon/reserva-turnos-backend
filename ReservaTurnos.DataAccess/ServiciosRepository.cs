using ReservaTurnos.Models;
using ReservaTurnos.Repository;

namespace ReservaTurnos.DataAccess
{
    public class ServiciosRepository : Repository<Servicios>, IServiciosRepository
    {
        public ServiciosRepository(string connectionString) : base(connectionString)
        {
        }
    }
}
