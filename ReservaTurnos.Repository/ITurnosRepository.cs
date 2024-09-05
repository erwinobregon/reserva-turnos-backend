using ReservaTurnos.Models;

namespace ReservaTurnos.Repository
{
    public interface ITurnosRepository : IRepository<Turnos>
    {
        List<Turnos> CrearTurnos (TurnosRequest turnos);
        bool ValidarTurnos(TurnosRequest turnos);
    }
}
