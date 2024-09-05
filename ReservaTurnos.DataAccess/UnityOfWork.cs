using ReservaTurnos.Repository;
using ReservaTurnos.UnitOfWork;

namespace ReservaTurnos.DataAccess
{
    public class UnityOfWork : IUnityOfWork
    {
        public UnityOfWork(string connectionString)
        {
            Comercios = new ComerciosRepository(connectionString);
            Servicios = new ServiciosRepository(connectionString);
            Turnos = new TurnosRepository(connectionString);
        }
        public IComerciosRepository Comercios { get; set; }
        public IServiciosRepository Servicios { get ; set; }
        public ITurnosRepository Turnos { get; }
    }
}
