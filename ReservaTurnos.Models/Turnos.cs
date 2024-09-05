using Dapper.Contrib.Extensions;

namespace ReservaTurnos.Models
{
    [Table("Turnos")]
    public class Turnos
    {
        [Key]
        public int IdTurno { get; set; }
        public int IdServicio { get; set; }
        public DateTime FechaTurno { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
        public string? Estado { get; set; }
    }
}
