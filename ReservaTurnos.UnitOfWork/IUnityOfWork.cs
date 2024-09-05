using ReservaTurnos.Repository;

namespace ReservaTurnos.UnitOfWork
{
    public interface IUnityOfWork
    {
        //IComerciosRepository
        IComerciosRepository Comercios { get; set; }
        IServiciosRepository Servicios { get; set; }
        ITurnosRepository Turnos { get; }
    }
}
