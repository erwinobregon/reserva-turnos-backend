using Dapper;
using ReservaTurnos.Models;
using ReservaTurnos.Repository;
using System.Data;
using System.Data.SqlClient;

namespace ReservaTurnos.DataAccess
{
    public class TurnosRepository : Repository<Turnos>, ITurnosRepository
    {
        public TurnosRepository(string connectionString) : base(connectionString)
        {
        }

        public List<Turnos> CrearTurnos(TurnosRequest turnos)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IdServicio", turnos.IdServicio);
            parameters.Add("@FechaInicio", turnos.FechaInicio);
            parameters.Add("@FechaFin", turnos.FechaFin);
            List<Turnos> listTurnos = new List<Turnos>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var reader = connection.ExecuteReader("dbo.sp_ReservaTurnos",
                    parameters, commandType: CommandType.StoredProcedure))
                {
                    while (reader.Read())
                    {
                        Turnos turno = new Turnos();
                        turno.IdTurno = (int)reader["IdTurno"];
                        turno.IdServicio = (int)reader["IdServicio"];
                        turno.FechaTurno = (DateTime)reader["FechaTurno"];
                        turno.HoraInicio = (TimeSpan)reader["HoraInicio"];
                        turno.HoraFin = (TimeSpan)reader["HoraFin"];
                        turno.Estado = (string)reader["Estado"];
                        listTurnos.Add(turno);
                    }

                }
                return listTurnos;
            }


        }

        public bool ValidarTurnos(TurnosRequest turnos)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IdServicio", turnos.IdServicio);
            parameters.Add("@FechaInicio", turnos.FechaInicio);
            parameters.Add("@FechaFin", turnos.FechaFin);
            using (var connection = new SqlConnection(connectionString))
            {
                return connection.ExecuteScalar<bool>("dbo.sp_ValidaTurnosReservados",
                    parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
